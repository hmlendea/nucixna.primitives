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
    /// Namespace and using-directive conventions over the handwritten production sources.
    /// </summary>
    [TestFixture]
    public sealed class NamespaceConventionTests
    {
        [Test]
        public void GivenProductionSources_WhenCheckingNamespaces_ThenEachIsABlockNamespace()
        {
            foreach (SyntaxTree tree in CollectProductionParseTrees())
            {
                FileScopedNamespaceDeclarationSyntax[] fileScopedNamespaces = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<FileScopedNamespaceDeclarationSyntax>()
                    .ToArray();

                Assert.That(
                    fileScopedNamespaces,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: file-scoped namespaces are prohibited.");
            }
        }

        [Test]
        public void GivenProductionSources_WhenCheckingNamespaces_ThenEachResidesInTheDocumentedNamespace()
        {
            foreach (SyntaxTree tree in CollectProductionParseTrees())
            {
                string[] namespaces = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<NamespaceDeclarationSyntax>()
                    .Select(namespaceDeclaration => namespaceDeclaration.Name.ToString())
                    .ToArray();

                Assert.That(
                    namespaces,
                    Is.Not.Empty,
                    $"Violated convention in {tree.FilePath}: every file must declare a namespace.");

                Assert.That(
                    namespaces.Where(name =>
                        !name.Equals("NuciXNA.Primitives", StringComparison.Ordinal) &&
                        !name.Equals("NuciXNA.Primitives.Mapping", StringComparison.Ordinal)),
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: production types must reside in a documented namespace.");
            }
        }

        [Test]
        public void GivenProductionSources_WhenCheckingMappingNamespace_ThenNoForbiddenNamespaceSuffixIsUsed()
        {
            foreach (SyntaxTree tree in CollectProductionParseTrees())
            {
                string[] namespaces = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<BaseNamespaceDeclarationSyntax>()
                    .Select(namespaceDeclaration => namespaceDeclaration.Name.ToString())
                    .ToArray();

                Assert.That(
                    namespaces.Where(name => name.EndsWith(".Interfaces", StringComparison.Ordinal) ||
                        name.EndsWith(".Enums", StringComparison.Ordinal) ||
                        name.EndsWith(".Enumerations", StringComparison.Ordinal)),
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: '.Interfaces', '.Enums', and '.Enumerations' namespaces are prohibited.");
            }
        }

        [Test]
        public void GivenProductionSources_WhenCheckingUsingDirectives_ThenAllAreOutsideTheNamespace()
        {
            foreach (SyntaxTree tree in CollectProductionParseTrees())
            {
                UsingDirectiveSyntax[] usingsInsideNamespace = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<NamespaceDeclarationSyntax>()
                    .SelectMany(namespaceDeclaration => namespaceDeclaration.Usings)
                    .ToArray();

                Assert.That(
                    usingsInsideNamespace,
                    Is.Empty,
                    $"Violated convention in {tree.FilePath}: all using directives must be outside the namespace.");
            }
        }

        [Test]
        public void GivenProductionSources_WhenCheckingUsingDirectives_ThenNoneAreInsideTheNamespaceBody()
        {
            foreach (SyntaxTree tree in CollectProductionParseTrees())
            {
                CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

                if (root.Usings.Count == 0)
                {
                    continue;
                }

                NamespaceDeclarationSyntax? namespaceDeclaration = root.DescendantNodes()
                    .OfType<NamespaceDeclarationSyntax>()
                    .FirstOrDefault();

                Assert.That(
                    namespaceDeclaration,
                    Is.Not.Null,
                    $"Violated convention in {tree.FilePath}: a namespace must be declared.");

                int lastUsingLine = root.Usings.Last().GetLocation().GetLineSpan().EndLinePosition.Line;
                int namespaceLine = namespaceDeclaration!.GetLocation().GetLineSpan().StartLinePosition.Line;

                Assert.That(
                    namespaceLine,
                    Is.GreaterThan(lastUsingLine),
                    $"Violated convention in {tree.FilePath}: using directives must precede the namespace.");
            }
        }

        [Test]
        public void GivenProductionSources_WhenCheckingMappingFiles_ThenEachDeclaresTheMappingNamespace()
        {
            foreach (SyntaxTree tree in CollectProductionParseTrees())
            {
                string filePath = tree.FilePath;

                if (!filePath.Contains("Mapping", StringComparison.Ordinal))
                {
                    continue;
                }

                string[] namespaces = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<BaseNamespaceDeclarationSyntax>()
                    .Select(namespaceDeclaration => namespaceDeclaration.Name.ToString())
                    .ToArray();

                Assert.That(
                    namespaces,
                    Has.All.EqualTo("NuciXNA.Primitives.Mapping"),
                    $"Violated convention in {filePath}: mapping files must reside in the singular '.Mapping' namespace.");
            }
        }

        private static IEnumerable<SyntaxTree> CollectProductionParseTrees()
        {
            IReadOnlyList<string> sources = ArchitectureResources.GetResourcePaths(ArchitectureResources.ProductionSourcePrefix);

            Assert.That(
                sources,
                Is.Not.Empty,
                "Violated convention: no production source files were found.");

            return sources
                .Select(source => CSharpSyntaxTree.ParseText(
                    ArchitectureResources.ReadResource(ArchitectureResources.ProductionSourcePrefix, source),
                    path: source));
        }
    }
}
