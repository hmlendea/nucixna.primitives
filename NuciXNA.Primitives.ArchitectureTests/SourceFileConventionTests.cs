using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using NUnit.Framework;

namespace NuciXNA.Primitives.ArchitectureTests
{
    /// <summary>
    /// Roslyn-based source-file convention checks over the handwritten sources of NuciXNA.Primitives.
    /// </summary>
    [TestFixture]
    public sealed class SourceFileConventionTests
    {
        private const int MaxParameterCount = 7;

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingNamespaces_ThenEveryFileUsesABlockNamespace(string sourcePrefix)
        {
            foreach (string source in CollectSources(sourcePrefix))
            {
                SyntaxTree tree = ParseTree(sourcePrefix, source);

                Assert.That(
                    tree.GetRoot().DescendantNodes().OfType<BaseNamespaceDeclarationSyntax>(),
                    Is.Not.Empty,
                    $"Violated convention in {source}: every file must declare a block namespace.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingNullableDirectives_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (string source in CollectSources(sourcePrefix))
            {
                SyntaxTree tree = ParseTree(sourcePrefix, source);

                Assert.That(
                    tree.GetRoot().DescendantTrivia().Where(trivia => trivia.IsKind(SyntaxKind.NullableDirectiveTrivia)).ToArray(),
                    Is.Empty,
                    $"Violated convention in {source}: the '#nullable' directive is prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingRegions_ThenNoneAreUsed(string sourcePrefix)
        {
            foreach (string source in CollectSources(sourcePrefix))
            {
                SyntaxTree tree = ParseTree(sourcePrefix, source);

                Assert.That(
                    tree.GetRoot().DescendantTrivia().Where(trivia =>
                        trivia.IsKind(SyntaxKind.RegionDirectiveTrivia) ||
                        trivia.IsKind(SyntaxKind.EndRegionDirectiveTrivia)).ToArray(),
                    Is.Empty,
                    $"Violated convention in {source}: regions are prohibited.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingExplicitTypes_ThenNoVarKeywordIsUsed(string sourcePrefix)
        {
            foreach (string source in CollectSources(sourcePrefix))
            {
                SyntaxTree tree = ParseTree(sourcePrefix, source);
                VariableDeclarationSyntax[] varDeclarations = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<VariableDeclarationSyntax>()
                    .Where(declaration => declaration.Type.IsVar)
                    .ToArray();

                Assert.That(
                    varDeclarations,
                    Is.Empty,
                    $"Violated convention in {source}: the 'var' keyword must not be used.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingControlFlowBodies_ThenEveryBodyUsesBraces(string sourcePrefix)
        {
            foreach (string source in CollectSources(sourcePrefix))
            {
                SyntaxTree tree = ParseTree(sourcePrefix, source);
                SyntaxNode[] unbracedControlFlowBodies = tree.GetRoot()
                    .DescendantNodes()
                    .Where(node => node is IfStatementSyntax ifStatement && ifStatement.Statement is not BlockSyntax)
                    .ToArray();

                Assert.That(
                    unbracedControlFlowBodies,
                    Is.Empty,
                    $"Violated convention in {source}: every control-flow body must use braces.");
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingMethodParameters_ThenAtMostSevenAreUsed(string sourcePrefix)
        {
            foreach (string source in CollectSources(sourcePrefix))
            {
                SyntaxTree tree = ParseTree(sourcePrefix, source);
                SyntaxNode[] oversizedParameterLists = tree.GetRoot()
                    .DescendantNodes()
                    .Where(node => node is ParameterListSyntax parameterList && parameterList.Parameters.Count > MaxParameterCount)
                    .ToArray();

                Assert.That(
                    oversizedParameterLists,
                    Is.Empty,
                    $"Violated convention in {source}: methods must not exceed seven parameters.");
            }
        }

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
    }
}
