using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using NUnit.Framework;

namespace NuciXNA.Primitives.ArchitectureTests
{
    /// <summary>
    /// Repository layout conventions over the embedded project and solution files.
    /// </summary>
    [TestFixture]
    public sealed class ProjectLayoutConventionTests
    {
        private static readonly string[] ProjectPaths =
        [
            "NuciXNA.Primitives/NuciXNA.Primitives.csproj",
            "NuciXNA.Primitives.ArchitectureTests/NuciXNA.Primitives.ArchitectureTests.csproj",
            "NuciXNA.Primitives.UnitTests/NuciXNA.Primitives.UnitTests.csproj"
        ];

        [Test]
        public void GivenSyntaxNoProjects_WhenCheckingLayout_ThenEveryProjectResidesInASiblingFolderOfTheSolution()
        {
            foreach (string projectPath in ProjectPaths)
            {
                string folder = projectPath.Split('/')[0];
                string fileName = projectPath.Split('/')[1];

                Assert.That(
                    fileName,
                    Is.EqualTo(folder + ".csproj"),
                    $"Violated convention: {projectPath} must reside in a folder named after the project.");
                Assert.That(
                    projectPath.StartsWith("src/", StringComparison.Ordinal),
                    Is.False,
                    $"Violated convention: {projectPath} must not be nested under a 'src' folder.");
            }
        }

        [Test]
        public void GivenProductionProject_WhenCheckingName_ThenItMatchesTheSolutionName()
        {
            XDocument productionProject = LoadProject("NuciXNA.Primitives/NuciXNA.Primitives.csproj");

            Assert.That(
                GetProperty(productionProject, "RootNamespace"),
                Is.EqualTo("NuciXNA.Primitives"),
                "Violated convention: the production RootNamespace must match the project name.");
        }

        [Test]
        public void GivenUnitTestProject_WhenCheckingName_ThenItFollowsTheMainProjectNamingConvention()
        {
            Assert.That(
                ProjectPaths.Where(path => path.Contains("UnitTests", StringComparison.Ordinal)),
                Is.EqualTo(["NuciXNA.Primitives.UnitTests/NuciXNA.Primitives.UnitTests.csproj"]),
                "Violated convention: the unit test project must be named '<MainProjectName>.UnitTests'.");
        }

        [Test]
        public void GivenSolutionFile_WhenCheckingProjectPaths_ThenNoProjectIsNestedUnderSrc()
        {
            XDocument solution = LoadSolution();

            string[] nestedProjectPaths = solution.Descendants()
                .Where(element => string.Equals(element.Name.LocalName, "Project", StringComparison.Ordinal))
                .Select(project => GetAttributeValue(project, "Path"))
                .Where(path => path.Contains("src/", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                nestedProjectPaths,
                Is.Empty,
                "Violated convention: projects must not be nested under a 'src' folder.");
        }

        [Test]
        public void GivenSolutionFile_WhenCheckingName_ThenItMatchesTheMainProject()
        {
            Assert.That(
                GetSolutionName(),
                Is.EqualTo("NuciXNA.slnx"),
                "Violated convention: the solution file must be named after the main project.");
        }

        [Test]
        public void GivenProjects_WhenCheckingType_ThenOnlyTheProductionProjectIsAPackage()
        {
            foreach (string projectPath in ProjectPaths)
            {
                XDocument project = LoadProject(projectPath);

                bool isPackable = string.Equals(GetProperty(project, "IsPackable"), "true", StringComparison.Ordinal);
                bool isProduction = projectPath.Equals("NuciXNA.Primitives/NuciXNA.Primitives.csproj", StringComparison.Ordinal);

                Assert.That(
                    isPackable,
                    Is.EqualTo(isProduction),
                    $"Violated convention: only the production project must be packable ({projectPath}).");
            }
        }

        [Test]
        public void GivenProjects_WhenCheckingProjectReferences_ThenEveryTestProjectReferencesTheProductionProject()
        {
            string[] testProjects =
            [
                "NuciXNA.Primitives.UnitTests/NuciXNA.Primitives.UnitTests.csproj",
                "NuciXNA.Primitives.ArchitectureTests/NuciXNA.Primitives.ArchitectureTests.csproj"
            ];

            foreach (string testProjectPath in testProjects)
            {
                string[] references = LoadProject(testProjectPath)
                    .Descendants("ProjectReference")
                    .Select(reference => GetAttributeValue(reference, "Include").Replace('\\', '/'))
                    .ToArray();

                Assert.That(
                    references,
                    Has.Some.EqualTo("../NuciXNA.Primitives/NuciXNA.Primitives.csproj"),
                    $"Violated convention: {testProjectPath} must reference the production project.");
            }
        }

        private static XDocument LoadProject(string relativePath)
            => XDocument.Parse(
                ArchitectureResources.ReadResource(
                    ArchitectureResources.ProjectFilePrefix,
                    relativePath));

        private static XDocument LoadSolution()
            => XDocument.Parse(
                ArchitectureResources.ReadResource(
                    ArchitectureResources.ProjectFilePrefix,
                    GetSolutionName()));

        private static string GetSolutionName()
            => "NuciXNA.slnx";

        private static string GetAttributeValue(XElement element, string attributeName)
        {
            XAttribute? attribute = element.Attribute(attributeName);

            if (attribute is null)
            {
                return string.Empty;
            }

            return attribute.Value;
        }

        private static string GetProperty(XDocument project, string name)
        {
            IEnumerable<XElement> elements = project.Descendants()
                .Where(element => string.Equals(element.Name.LocalName, name, StringComparison.Ordinal));

            XElement? firstElement = elements.FirstOrDefault();

            if (firstElement is null)
            {
                return string.Empty;
            }

            return firstElement.Value;
        }
    }
}
