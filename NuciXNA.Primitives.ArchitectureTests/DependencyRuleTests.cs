using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;

using NUnit.Framework;

using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace NuciXNA.Primitives.ArchitectureTests
{
    /// <summary>
    /// Dependency and boundary checks over the loaded production architecture.
    /// </summary>
    [TestFixture]
    public sealed class DependencyRuleTests
    {
        private static readonly string[] ExpectedPrimitiveTypes =
        [
            "NuciXNA.Primitives.Colour",
            "NuciXNA.Primitives.Point2D",
            "NuciXNA.Primitives.Point3D",
            "NuciXNA.Primitives.PointF2D",
            "NuciXNA.Primitives.PointF3D",
            "NuciXNA.Primitives.Rectangle2D",
            "NuciXNA.Primitives.Scale2D",
            "NuciXNA.Primitives.Size2D",
            "NuciXNA.Primitives.SizeF2D",
            "NuciXNA.Primitives.Vector2D",
            "NuciXNA.Primitives.Vector3D"
        ];

        private static readonly string[] ExpectedMappingTypes =
        [
            "NuciXNA.Primitives.Mapping.ColourMappingExtensions",
            "NuciXNA.Primitives.Mapping.ColourTranslator",
            "NuciXNA.Primitives.Mapping.PointMappingExtensions",
            "NuciXNA.Primitives.Mapping.RectangleMappingExtensions",
            "NuciXNA.Primitives.Mapping.ScaleMappingExtensions",
            "NuciXNA.Primitives.Mapping.SizeMappingExtensions",
            "NuciXNA.Primitives.Mapping.VectorMappingExtensions"
        ];

        private static readonly string[] StructPrimitiveTypes =
        [
            "NuciXNA.Primitives.Point2D",
            "NuciXNA.Primitives.Point3D",
            "NuciXNA.Primitives.PointF2D",
            "NuciXNA.Primitives.PointF3D",
            "NuciXNA.Primitives.Rectangle2D",
            "NuciXNA.Primitives.Scale2D",
            "NuciXNA.Primitives.Size2D",
            "NuciXNA.Primitives.SizeF2D",
            "NuciXNA.Primitives.Vector2D",
            "NuciXNA.Primitives.Vector3D"
        ];

        [Test]
        public void GivenProductionArchitecture_WhenLoaded_ThenOnlyTheProductionAssemblyIsModelled()
        {
            string[] modelledAssemblies = ProductionArchitecture.Model.Assemblies
                .Select(assembly => assembly.Name)
                .OrderBy(name => name, StringComparer.Ordinal)
                .ToArray();

            Assert.That(
                modelledAssemblies,
                Is.EquivalentTo([ProductionArchitecture.ProductionAssembly.GetName().Name]),
                "Violated boundary: only the production assembly must be modelled.");
        }

        [Test]
        public void GivenProductionAssembly_WhenInspectingExportedTypes_ThenEveryDocumentedPrimitiveIsPresent()
        {
            string[] exportedTypes = GetExportedTypeNames();

            Assert.That(
                exportedTypes,
                Is.SupersetOf(ExpectedPrimitiveTypes),
                "Violated boundary: a documented primitive type is missing from the public surface.");
        }

        [Test]
        public void GivenProductionAssembly_WhenInspectingExportedTypes_ThenEveryDocumentedMappingTypeIsPresent()
        {
            string[] exportedTypes = GetExportedTypeNames();

            Assert.That(
                exportedTypes,
                Is.SupersetOf(ExpectedMappingTypes),
                "Violated boundary: a documented mapping type is missing from the public surface.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingNamespacePlacement_ThenAllResideInTheDocumentedNamespaces()
        {
            string[] unexpectedTypes = GetProductionTypeNames()
                .Where(name => !name.StartsWith("NuciXNA.Primitives.Mapping.", StringComparison.Ordinal)
                    && !name.StartsWith("NuciXNA.Primitives.", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                unexpectedTypes,
                Is.Empty,
                "Violated boundary: every production type must reside in NuciXNA.Primitives or NuciXNA.Primitives.Mapping.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingExternalDependencies_ThenNoPersistenceFrameworkIsUsed()
        {
            IArchRule noPersistenceRule = Types()
                .That()
                .Are(ProductionArchitecture.ProductionTypes)
                .Should()
                .NotDependOnAnyTypesThat()
                .ResideInNamespaceMatching(@"Microsoft\.EntityFrameworkCore\..*")
                .AndShould()
                .NotDependOnAnyTypesThat()
                .ResideInNamespaceMatching(@"Amazon\.DynamoDBv2\..*")
                .AndShould()
                .NotDependOnAnyTypesThat()
                .ResideInNamespaceMatching(@"Dapper\..*")
                .Because("the library provides primitives and must stay persistence-agnostic");

            AssertProductionTypesSelected();

            AssertNoViolations(noPersistenceRule);
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingExternalDependencies_ThenNoWebOrMessagingFrameworkIsUsed()
        {
            IArchRule noWebRule = Types()
                .That()
                .Are(ProductionArchitecture.ProductionTypes)
                .Should()
                .NotDependOnAnyTypesThat()
                .ResideInNamespaceMatching(@"Microsoft\.AspNetCore\..*")
                .AndShould()
                .NotDependOnAnyTypesThat()
                .ResideInNamespaceMatching(@"MediatR\..*")
                .Because("the library must stay framework-agnostic");

            AssertProductionTypesSelected();

            AssertNoViolations(noWebRule);
        }

        [TestCase("NUnit")]
        [TestCase("Moq")]
        [TestCase("ArchUnit")]
        public void GivenProductionAssembly_WhenCheckingReferences_ThenTestFrameworksAreNotReferenced(string testAssembly)
        {
            string[] references = ProductionArchitecture.ProductionAssembly
                .GetReferencedAssemblies()
                .Select(reference => reference.Name)
                .OfType<string>()
                .ToArray();

            Assert.That(references, Is.Not.Empty, "Violated boundary: the assembly references must be inspectable.");
            Assert.That(
                references.Where(reference => reference.Contains(testAssembly, StringComparison.OrdinalIgnoreCase)),
                Is.Empty,
                $"Violated boundary: the production assembly must not reference {testAssembly}.");
        }

        [Test]
        public void GivenProductionAssembly_WhenCheckingFriendAssemblies_ThenInternalsAreNotExposed()
        {
            InternalsVisibleToAttribute[] friendAssemblies = ProductionArchitecture.ProductionAssembly
                .GetCustomAttributes<InternalsVisibleToAttribute>()
                .ToArray();

            Assert.That(
                friendAssemblies,
                Is.Empty,
                "Violated boundary: production code must not declare InternalsVisibleTo.");
        }

        [Test]
        public void GivenPrimitiveStructs_WhenInspectingDeclarations_ThenEachIsAValueType()
        {
            foreach (string typeName in StructPrimitiveTypes)
            {
                Type primitiveType = GetProductionType(typeName);

                Assert.That(
                    primitiveType.IsValueType,
                    Is.True,
                    $"Violated boundary: {typeName} must remain a struct value type.");
            }
        }

        [Test]
        public void GivenColourType_WhenInspectingDeclaration_ThenItIsASealedClass()
        {
            Type colourType = GetProductionType("NuciXNA.Primitives.Colour");

            Assert.That(colourType.IsClass, Is.True, "Violated boundary: Colour must remain a reference type.");
            Assert.That(colourType.IsSealed, Is.True, "Violated boundary: Colour must remain sealed.");
        }

        [Test]
        public void GivenPrimitiveTypes_WhenInspectingDeclarations_ThenEachImplementsValueEquality()
        {
            foreach (string typeName in ExpectedPrimitiveTypes)
            {
                Type primitiveType = GetProductionType(typeName);
                bool implementsEquatable = primitiveType
                    .GetInterfaces()
                    .Any(interfaceType => interfaceType.IsGenericType
                        && interfaceType.GetGenericTypeDefinition() == typeof(IEquatable<>)
                        && interfaceType.GenericTypeArguments[0] == primitiveType);

                Assert.That(
                    implementsEquatable,
                    Is.True,
                    $"Violated boundary: {typeName} must implement IEquatable<{primitiveType.Name}>.");
            }
        }

        [Test]
        public void GivenMappingExtensionClasses_WhenInspectingDeclarations_ThenEachIsStatic()
        {
            foreach (string typeName in ExpectedMappingTypes.Where(name => name.EndsWith("MappingExtensions", StringComparison.Ordinal)))
            {
                Type mappingType = GetProductionType(typeName);

                Assert.That(
                    mappingType.IsAbstract && mappingType.IsSealed,
                    Is.True,
                    $"Violated boundary: {typeName} must be a static class.");
            }
        }

        [Test]
        public void GivenMappingExtensionMethods_WhenInspectingSignatures_ThenEachIsAnExtensionMethod()
        {
            foreach (string typeName in ExpectedMappingTypes.Where(name => name.EndsWith("MappingExtensions", StringComparison.Ordinal)))
            {
                Type mappingType = GetProductionType(typeName);
                MethodInfo[] nonExtensionMethods = mappingType
                    .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(method => !method.IsDefined(typeof(ExtensionAttribute), false))
                    .ToArray();

                Assert.That(
                    nonExtensionMethods,
                    Is.Empty,
                    $"Violated boundary: every method of {typeName} must be an extension method.");
            }
        }

        private static void AssertProductionTypesSelected()
            => Assert.That(
                ProductionArchitecture.ProductionTypes.GetObjects(ProductionArchitecture.Model),
                Is.Not.Empty,
                "Vacuous-selector guard: no production types were selected.");

        private static void AssertNoViolations(IArchRule archRule)
        {
            EvaluationResult[] failures = archRule
                .Evaluate(ProductionArchitecture.Model)
                .Where(result => !result.Passed)
                .ToArray();

            Assert.That(
                failures,
                Is.Empty,
                "Violated boundary: " + archRule.Description);
        }

        private static string[] GetExportedTypeNames()
            => ProductionArchitecture.ProductionAssembly
                .GetExportedTypes()
                .Select(type => type.FullName)
                .OfType<string>()
                .OrderBy(name => name, StringComparer.Ordinal)
                .ToArray();

        private static string[] GetProductionTypeNames()
            => ProductionArchitecture.ProductionAssembly
                .GetTypes()
                .Where(type => !IsCompilerGenerated(type))
                .Select(type => type.FullName)
                .OfType<string>()
                .OrderBy(name => name, StringComparer.Ordinal)
                .ToArray();

        private static Type GetProductionType(string fullName)
        {
            Type? productionType = ProductionArchitecture.ProductionAssembly.GetType(fullName);

            Assert.That(productionType, Is.Not.Null, $"Violated boundary: {fullName} is missing.");

            return productionType!;
        }

        private static bool IsCompilerGenerated(Type type)
            => type.Name.StartsWith('<') || type.GetCustomAttribute<CompilerGeneratedAttribute>() is not null;
    }
}
