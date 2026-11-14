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
    /// Line-splitting and continuation-indentation checks over the handwritten sources.
    /// </summary>
    [TestFixture]
    public sealed class LineSplittingConventionTests
    {
        private const int ConditionalClauseLimit = 72;

        private const int ArgumentListLimit = 96;

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingMemberSignatures_ThenNoInlineParameterListExceedsTheLimit(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                string source = tree.FilePath;
                BaseParameterListSyntax[] singleLineParameterLists = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<BaseParameterListSyntax>()
                    .Where(parameterList => parameterList.Parameters.Count > 0)
                    .Where(parameterList => IsSingleLine(parameterList))
                    .ToArray();

                foreach (BaseParameterListSyntax parameterList in singleLineParameterLists)
                {
                    Assert.That(
                        parameterList.ToString().Length,
                        Is.LessThanOrEqualTo(ArgumentListLimit),
                        $"Violated convention in {source}: an inline parameter list exceeds {ArgumentListLimit} characters.");
                }
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingInvocationArguments_ThenNoInlineArgumentListExceedsTheLimit(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                string source = tree.FilePath;
                ArgumentListSyntax[] singleLineArgumentLists = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<ArgumentListSyntax>()
                    .Where(argumentList => argumentList.Arguments.Count > 1)
                    .Where(argumentList => IsSingleLine(argumentList))
                    .ToArray();

                foreach (ArgumentListSyntax argumentList in singleLineArgumentLists)
                {
                    Assert.That(
                        argumentList.ToString().Length,
                        Is.LessThanOrEqualTo(ArgumentListLimit),
                        $"Violated convention in {source}: an inline invocation argument list exceeds {ArgumentListLimit} characters.");
                }
            }
        }

        [TestCase(ArchitectureResources.ProductionSourcePrefix)]
        [TestCase(ArchitectureResources.UnitTestSourcePrefix)]
        [TestCase(ArchitectureResources.ArchitectureTestSourcePrefix)]
        public void GivenSources_WhenCheckingConditionalClauses_ThenEachClauseFitsInsideTheLimit(string sourcePrefix)
        {
            foreach (SyntaxTree tree in CollectParseTrees(sourcePrefix))
            {
                string source = tree.FilePath;
                IfStatementSyntax[] conditionalStatements = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<IfStatementSyntax>()
                    .ToArray();

                foreach (IfStatementSyntax conditionalStatement in conditionalStatements)
                {
                    string condition = conditionalStatement.Condition.ToString();
                    string[] clauses = condition.Split([" && ", " || "], StringSplitOptions.None);

                    foreach (string clause in clauses)
                    {
                        Assert.That(
                            clause.Trim().Length,
                            Is.LessThanOrEqualTo(ConditionalClauseLimit),
                            $"Violated convention in {source}: each conditional clause must fit inside {ConditionalClauseLimit} characters.");
                    }
                }
            }
        }

        private static bool IsSingleLine(SyntaxNode node)
            => node.GetLocation().GetLineSpan().StartLinePosition.Line ==
                node.GetLocation().GetLineSpan().EndLinePosition.Line;

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
