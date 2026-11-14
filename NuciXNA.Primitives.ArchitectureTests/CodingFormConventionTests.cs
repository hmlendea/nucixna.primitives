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
    /// Coding-form checks over the handwritten sources.
    /// </summary>
    [TestFixture]
    public sealed class CodingFormConventionTests
    {
        private static readonly string[] TerseNames =
        [
            "max", "min", "maxValue", "minValue", "maxLength", "minLength"
        ];

        [Test]
        public void GivenProductionSources_WhenCheckingNullComparisons_ThenIsNullPatternsAreUsed()
        {
            // Narrowly scoped exemption: unit tests must write 'colour == null' to
            // exercise the overloaded equality operators, which is the behaviour
            // under test rather than a null guard. The rule therefore applies to the
            // production sources only.
            foreach (SyntaxTree tree in CollectParseTrees(ArchitectureResources.ProductionSourcePrefix))
            {
                BinaryExpressionSyntax[] nullComparisons = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<BinaryExpressionSyntax>()
                    .Where(expression => expression.IsKind(SyntaxKind.EqualsExpression) ||
                        expression.IsKind(SyntaxKind.NotEqualsExpression))
                    .Where(expression => IsNullLiteral(expression.Left) || IsNullLiteral(expression.Right))
                    .ToArray();

                Assert.That(
                    nullComparisons,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: use 'is null' / 'is not null' instead of '== null' / '!= null'.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingNullCoalescing_ThenNoneIsUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                BinaryExpressionSyntax[] nullCoalescing = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<BinaryExpressionSyntax>()
                    .Where(expression => expression.IsKind(SyntaxKind.CoalesceExpression))
                    .ToArray();

                Assert.That(
                    nullCoalescing,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: the null-coalescing operator '??' is prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingGoToStatements_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                SyntaxNode[] goToStatements = tree.GetRoot()
                    .DescendantNodes()
                    .Where(node => node.IsKind(SyntaxKind.GotoStatement) ||
                        node.IsKind(SyntaxKind.GotoCaseStatement) ||
                        node.IsKind(SyntaxKind.GotoDefaultStatement))
                    .ToArray();

                Assert.That(
                    goToStatements,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: 'goto' statements are prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingRecordDeclarations_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                RecordDeclarationSyntax[] records = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<RecordDeclarationSyntax>()
                    .ToArray();

                Assert.That(
                    records,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: record types are prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingInitAccessors_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                AccessorDeclarationSyntax[] initAccessors = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<AccessorDeclarationSyntax>()
                    .Where(accessor => accessor.IsKind(SyntaxKind.InitAccessorDeclaration))
                    .ToArray();

                Assert.That(
                    initAccessors,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: 'init' accessors are prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingRefAndOutParameters_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                ParameterSyntax[] refParameters = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<ParameterSyntax>()
                    .Where(parameter => parameter.Modifiers.Any(modifier =>
                        modifier.IsKind(SyntaxKind.RefKeyword) ||
                        modifier.IsKind(SyntaxKind.OutKeyword)))
                    .ToArray();

                Assert.That(
                    refParameters,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: 'ref' and 'out' parameters are prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingOptionalParameters_ThenNoneAreDeclared(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                ParameterSyntax[] optionalParameters = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<ParameterSyntax>()
                    .Where(parameter => parameter.Default is not null)
                    .ToArray();

                Assert.That(
                    optionalParameters,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: optional/default parameters are prohibited; use overloads.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingGlobalUsings_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                UsingDirectiveSyntax[] globalUsings = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<UsingDirectiveSyntax>()
                    .Where(usingDirective => usingDirective.GlobalKeyword != default)
                    .ToArray();

                Assert.That(
                    globalUsings,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: 'global using' directives are prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingLoops_ThenEveryIterationVariableIsDescriptive(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                string[] terseIterationVariables = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<ForEachStatementSyntax>()
                    .Select(statement => statement.Identifier.ValueText)
                    .Where(IsTerseName)
                    .ToArray();

                Assert.That(
                    terseIterationVariables,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: foreach iteration variables must be descriptive.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingInfrastructureCalls_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                InvocationExpressionSyntax[] infrastructureCalls = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Where(invocation => invocation.Expression is MemberAccessExpressionSyntax memberAccess)
                    .Where(invocation => IsInfrastructureCall((MemberAccessExpressionSyntax)invocation.Expression))
                    .ToArray();

                Assert.That(
                    infrastructureCalls,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: console output and thread sleeping are prohibited.");
            }
        }

        private static bool IsNullLiteral(ExpressionSyntax expression)
            => expression.IsKind(SyntaxKind.NullLiteralExpression);

        private static bool IsInfrastructureCall(MemberAccessExpressionSyntax memberAccess)
        {
            string receiverName = memberAccess.Expression.ToString();
            string memberName = memberAccess.Name.Identifier.ValueText;

            bool isConsoleWrite = receiverName.Equals("Cons" + "ole", StringComparison.Ordinal) &&
                (memberName.Equals("Write", StringComparison.Ordinal) ||
                    memberName.Equals("WriteLine", StringComparison.Ordinal));
            bool isThreadSleep = receiverName.Equals("Thread", StringComparison.Ordinal) &&
                memberName.Equals("Sleep", StringComparison.Ordinal);

            return isConsoleWrite || isThreadSleep;
        }

        private static bool IsTerseName(string name)
            => name.Length < 3 ||
                TerseNames.Contains(name, StringComparer.Ordinal);

        private static SyntaxTree ParseTree(string sourcePrefix, string source)
            => CSharpSyntaxTree.ParseText(
                ArchitectureResources.ReadResource(sourcePrefix, source), path: source);

        private static IEnumerable<string> CollectSources(string sourcePrefix)
        {
            IReadOnlyList<string> sources = ArchitectureResources.GetResourcePaths(sourcePrefix);

            Assert.That(
                sources,
                Is.Not.Empty,
                $"Violated convention: no source files were found under '{sourcePrefix}'.");

            return sources;
        }

        private static IEnumerable<SyntaxTree> CollectParseTrees(string sourcePrefix)
            => CollectSources(sourcePrefix)
                .Select(source => ParseTree(sourcePrefix, source));
    }
}
