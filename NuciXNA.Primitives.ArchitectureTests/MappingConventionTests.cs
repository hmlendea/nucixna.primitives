using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

namespace NuciXNA.Primitives.ArchitectureTests
{
    /// <summary>
    /// Mapping-extension placement and shape checks over the loaded production assembly.
    /// </summary>
    [TestFixture]
    public sealed class MappingConventionTests
    {
        private static readonly Type[] MappingTypes = ProductionArchitecture.ProductionAssembly
            .GetExportedTypes()
            .Where(type => type.Namespace is not null &&
                type.Namespace.Equals("NuciXNA.Primitives.Mapping", StringComparison.Ordinal))
            .ToArray();

        private static readonly Type[] MappingExtensionTypes = MappingTypes
            .Where(type => type.Name.EndsWith("MappingExtensions", StringComparison.Ordinal))
            .ToArray();

        [Test]
        public void GivenProductionAssembly_WhenSelectingMappingTypes_ThenAtLeastOneIsFound()
            => Assert.That(
                MappingTypes,
                Is.Not.Empty,
                "Vacuous-selector guard: no mapping types were found in the mapping namespace.");

        [Test]
        public void GivenProductionAssembly_WhenSelectingMappingExtensionTypes_ThenAtLeastOneIsFound()
            => Assert.That(
                MappingExtensionTypes,
                Is.Not.Empty,
                "Vacuous-selector guard: no mapping extension classes were found.");

        [Test]
        public void GivenMappingTypes_WhenCheckingNamespace_ThenAllResideInTheSingularMappingNamespace()
        {
            string[] unexpectedNamespaces = MappingTypes
                .Select(type => type.Namespace)
                .OfType<string>()
                .Where(name => !name.Equals("NuciXNA.Primitives.Mapping", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                unexpectedNamespaces,
                Is.Empty,
                "Violated convention: all mapping types must reside in the singular '.Mapping' namespace.");
        }

        [Test]
        public void GivenMappingExtensionTypes_WhenCheckingNaming_ThenEachEndsWithMappingExtensions()
        {
            string[] misnamedTypes = MappingExtensionTypes
                .Select(type => type.Name)
                .Where(name => !name.EndsWith("MappingExtensions", StringComparison.Ordinal))
                .ToArray();

            Assert.That(
                misnamedTypes,
                Is.Empty,
                "Violated convention: mapping extension classes must be named '<Noun>MappingExtensions'.");
        }

        [Test]
        public void GivenMappingExtensionTypes_WhenCheckingDeclaration_ThenEachIsAStaticClass()
        {
            Type[] nonStaticMappingTypes = MappingExtensionTypes
                .Where(type => !(type.IsAbstract && type.IsSealed))
                .ToArray();

            Assert.That(
                nonStaticMappingTypes,
                Is.Empty,
                "Violated convention: mapping extension classes must be static.");
        }

        [Test]
        public void GivenMappingExtensionMethods_WhenCheckingSignature_ThenEachUsesAnExtensionReceiver()
        {
            List<string> offenders = [];

            foreach (Type mappingType in MappingExtensionTypes)
            {
                MethodInfo[] declaredMethods = mappingType
                    .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

                foreach (MethodInfo method in declaredMethods)
                {
                    bool isExtensionMethod = method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false);

                    if (!isExtensionMethod)
                    {
                        offenders.Add(mappingType.Name + "." + method.Name);
                    }
                }
            }

            Assert.That(
                offenders,
                Is.Empty,
                "Violated convention: every method in a mapping extension class must be an extension method.");
        }

        [Test]
        public void GivenMappingExtensionMethods_WhenCheckingNaming_ThenTheyUseToPascalCaseNames()
        {
            string[] misnamedMethods = MappingExtensionTypes
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
                .Select(method => method.Name)
                .Where(name => !name.StartsWith("To", StringComparison.Ordinal) ||
                    name.Length < 3 ||
                    !char.IsUpper(name[2]))
                .ToArray();

            Assert.That(
                misnamedMethods,
                Is.Empty,
                "Violated convention: mapping extension methods must use the 'To<Noun>' conversion name.");
        }

        [Test]
        public void GivenProductionAssembly_WhenCheckingMappingPlacement_ThenNoMappingMethodExistsOutsideTheMappingNamespace()
        {
            string[] misplacedMappingMethods = ProductionArchitecture.ProductionAssembly
                .GetExportedTypes()
                .Where(type => type.Namespace is not null &&
                    !type.Namespace.Equals("NuciXNA.Primitives.Mapping", StringComparison.Ordinal))
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
                .Where(method => method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false))
                .Select(method => method.DeclaringType?.FullName + "." + method.Name)
                .OfType<string>()
                .ToArray();

            Assert.That(
                misplacedMappingMethods,
                Is.Empty,
                "Violated convention: conversion extension methods must exist only in the mapping namespace.");
        }
    }
}
