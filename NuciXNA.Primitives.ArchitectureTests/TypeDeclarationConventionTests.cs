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
    /// Type and interface declaration checks over the handwritten sources.
    /// </summary>
    [TestFixture]
    public sealed class TypeDeclarationConventionTests
    {
        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingPartialDeclarations_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                TypeDeclarationSyntax[] partialTypes = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<TypeDeclarationSyntax>()
                    .Where(declaration => declaration.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword)))
                    .ToArray();

                Assert.That(
                    partialTypes,
                    Is.Empty,
                    "Violated convention: partial types are prohibited unless a framework contract requires them.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        public void GivenProductionSources_WhenCheckingSealing_ThenEachClassIsSealedOrAbstractOrStatic(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                ClassDeclarationSyntax[] nonSealedClasses = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(declaration => !declaration.Modifiers.Any(modifier =>
                        modifier.IsKind(SyntaxKind.SealedKeyword) ||
                        modifier.IsKind(SyntaxKind.StaticKeyword) ||
                        modifier.IsKind(SyntaxKind.AbstractKeyword)))
                    .ToArray();

                Assert.That(
                    nonSealedClasses,
                    Is.Empty,
                    "Violated convention: every non-static and non-abstract class must be sealed.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingInterfaces_ThenEachUsesTheIPrefix(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                string[] misnamedInterfaces = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<InterfaceDeclarationSyntax>()
                    .Select(declaration => declaration.Identifier.ValueText)
                    .Where(IsMisnamedInterface)
                    .ToArray();

                Assert.That(
                    misnamedInterfaces,
                    Is.Empty,
                    "Violated convention: each interface must use the 'I' prefix followed by PascalCase");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingEnumVariants_ThenEachHasExplicitNumericValue(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                EnumMemberDeclarationSyntax[] membersWithoutValue = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<EnumMemberDeclarationSyntax>()
                    .Where(member => member.EqualsValue is null)
                    .ToArray();

                Assert.That(
                    membersWithoutValue,
                    Is.Empty,
                    "Violated convention: each enum variant must declare an explicit numeric value");
            }
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

        private static bool IsMisnamedInterface(string name)
            => name.Length < 2 || name[0] != 'I' || !char.IsUpper(name[1]);
    }
}
