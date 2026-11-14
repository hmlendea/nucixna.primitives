using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using NUnit.Framework;

namespace NuciXNA.Primitives.ArchitectureTests
{
    /// <summary>
    /// Test-source conventions over the unit test project.
    /// </summary>
    [TestFixture]
    public sealed class TestSourceConventionTests
    {
        [Test]
        public void GivenUnitTests_WhenSelectingFixtures_ThenAtLeastOneFixtureIsFound()
        {
            ClassDeclarationSyntax[] fixtures = CollectUnitTestClasses();

            Assert.That(
                fixtures,
                Is.Not.Empty,
                "Vacuous-selector guard: no unit test fixtures were found.");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingAttributes_ThenEveryFixtureIsATestFixture()
        {
            ClassDeclarationSyntax[] fixtures = CollectUnitTestClasses()
                .Where(classDeclaration => !HasAttribute(classDeclaration, "TestFixture"))
                .ToArray();

            Assert.That(
                fixtures,
                Is.Empty,
                "Violated convention: every unit test class must be annotated with [TestFixture].");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingMethods_ThenEveryTestMethodHasATestOrTestCaseAttribute()
        {
            List<string> offenders = [];

            foreach (MethodDeclarationSyntax method in CollectUnitTestMethods())
            {
                if (!HasAttribute(method, "Test") && !HasAttribute(method, "TestCase"))
                {
                    offenders.Add(method.Identifier.ValueText);
                }
            }

            Assert.That(
                offenders,
                Is.Empty,
                "Violated convention: every unit test method must carry [Test] or [TestCase].");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingParameterisedMethods_ThenEachHasAtLeastTwoCases()
        {
            IEnumerable<MethodDeclarationSyntax> parameterisedMethods = CollectUnitTestMethods()
                .Where(method => HasAttribute(method, "TestCase"));

            foreach (MethodDeclarationSyntax method in parameterisedMethods)
            {
                int testCaseCount = method.AttributeLists
                    .SelectMany(attributeList => attributeList.Attributes)
                    .Count(attribute => attribute.Name.ToString().Equals("TestCase", StringComparison.Ordinal));

                Assert.That(
                    testCaseCount,
                    Is.GreaterThanOrEqualTo(2),
                    $"Violated convention: parameterised test {method.Identifier.ValueText} must declare at least two cases.");
            }
        }

        [Test]
        public void GivenUnitTests_WhenCheckingNames_ThenEveryTestMethodFollowsTheGivenWhenThenPattern()
        {
            string[] misnamedMethods = CollectUnitTestMethods()
                .Select(method => method.Identifier.ValueText)
                .Where(name => !IsGivenWhenThenName(name))
                .ToArray();

            Assert.That(
                misnamedMethods,
                Is.Empty,
                "Violated convention: unit test names must follow Given..._When..._Then....");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingClassNames_ThenEachEndsWithTests()
        {
            string[] misnamedClasses = CollectUnitTestClasses()
                .Select(classDeclaration => classDeclaration.Identifier.ValueText)
                .Where(name => !name.EndsWith("Tests", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                misnamedClasses,
                Is.Empty,
                "Violated convention: every unit test fixture name must end with 'Tests'.");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingAssertions_ThenNoLegacyAssertIsUsed()
        {
            foreach (SyntaxTree tree in CollectUnitTestTrees())
            {
                InvocationExpressionSyntax[] legacyAsserts = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Where(invocation => invocation.Expression is MemberAccessExpressionSyntax memberAccess)
                    .Where(invocation => IsLegacyAssert((MemberAccessExpressionSyntax)invocation.Expression))
                    .ToArray();

                Assert.That(
                    legacyAsserts,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: the NUnit constraint model (Assert.That) must be used.");
            }
        }

        [Test]
        public void GivenUnitTests_WhenCheckingArrangeAct_ThenNoneAreDeclared()
        {
            string[] arrangeActComments = CollectUnitTestTrees()
                .SelectMany(tree => tree.GetRoot().DescendantTrivia())
                .Where(trivia => trivia.IsKind(SyntaxKind.SingleLineCommentTrivia))
                .Select(trivia => trivia.ToString())
                .Where(comment => comment.Contains("Arrange", StringComparison.Ordinal) ||
                    comment.Contains("Act", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                arrangeActComments,
                Is.Empty,
                "Violated convention: Arrange/Act comments must not be used.");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingCommentBanners_ThenNoneAreUsed()
        {
            string[] bannerComments = CollectUnitTestTrees()
                .SelectMany(tree => tree.GetRoot().DescendantTrivia())
                .Where(trivia => trivia.IsKind(SyntaxKind.SingleLineCommentTrivia))
                .Select(trivia => trivia.ToString())
                .Where(comment => comment.Contains("---", StringComparison.Ordinal) ||
                    comment.Contains("===", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                bannerComments,
                Is.Empty,
                "Violated convention: comment banners must not be used.");
        }

        [Test]
        public void GivenUnitTests_WhenCheckingTimeDependencies_ThenNoClockIsRead()
        {
            foreach (SyntaxTree tree in CollectUnitTestTrees())
            {
                InvocationExpressionSyntax[] clockReads = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Where(invocation => invocation.Expression is MemberAccessExpressionSyntax memberAccess)
                    .Where(invocation => IsClockRead((MemberAccessExpressionSyntax)invocation.Expression))
                    .ToArray();

                Assert.That(
                    clockReads,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: tests must be deterministic and must not read the clock.");
            }
        }

        private static IEnumerable<SyntaxTree> CollectUnitTestTrees()
            => CollectParseTrees(ArchitectureResources.UnitTestSourcePrefix);

        private static ClassDeclarationSyntax[] CollectUnitTestClasses()
            => CollectUnitTestTrees()
                .SelectMany(tree => tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
                .ToArray();

        private static IEnumerable<MethodDeclarationSyntax> CollectUnitTestMethods()
            => CollectUnitTestTrees()
                .SelectMany(tree => tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>())
                .Where(method => method.Modifiers.Any(SyntaxKind.PublicKeyword));

        private static bool HasAttribute(MemberDeclarationSyntax member, string attributeName)
            => member.AttributeLists
                .SelectMany(attributeList => attributeList.Attributes)
                .Any(attribute => attribute.Name.ToString().Equals(attributeName, StringComparison.Ordinal));

        private static bool IsGivenWhenThenName(string name)
            => name.StartsWith("Given", StringComparison.Ordinal) &&
                name.Contains("_When", StringComparison.Ordinal) &&
                name.Contains("_Then", StringComparison.Ordinal);

        private static bool IsLegacyAssert(MemberAccessExpressionSyntax memberAccess)
        {
            bool isAssertReceiver = memberAccess.Expression.ToString().Equals("Assert", StringComparison.Ordinal);

            if (!isAssertReceiver)
            {
                return false;
            }

            string[] legacyMembers =
            [
                "AreEqual", "AreNotEqual", "IsTrue", "IsFalse",
                "IsNull", "IsNotNull", "IsEmpty", "IsNotEmpty",
                "Greater", "GreaterOrEqual", "Less", "LessOrEqual", "Contains"
            ];

            return legacyMembers.Contains(memberAccess.Name.Identifier.ValueText, StringComparer.Ordinal);
        }

        private static bool IsClockRead(MemberAccessExpressionSyntax memberAccess)
        {
            string receiver = memberAccess.Expression.ToString();
            string member = memberAccess.Name.Identifier.ValueText;

            return receiver.Equals("DateTime", StringComparison.Ordinal) &&
                (member.Equals("Now", StringComparison.Ordinal) ||
                    member.Equals("UtcNow", StringComparison.Ordinal) ||
                    member.Equals("Today", StringComparison.Ordinal));
        }

        private static IEnumerable<SyntaxTree> CollectParseTrees(string sourcePrefix)
        {
            IReadOnlyList<string> sources = ArchitectureResources.GetResourcePaths(sourcePrefix);

            Assert.That(
                sources,
                Is.Not.Empty,
                $"Violated convention: no source files were found under '{sourcePrefix}'.");

            return sources
                .Select(source => CSharpSyntaxTree.ParseText(
                    ArchitectureResources.ReadResource(sourcePrefix, source),
                    path: source));
        }
    }
}
