using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using NUnit.Framework;

namespace NuciXNA.Primitives.ArchitectureTests
{
    /// <summary>
    /// Structural checks over the loaded production assembly.
    /// </summary>
    [TestFixture]
    public sealed class ProductionStructureTests
    {
        private static readonly Type[] ProductionTypes = ProductionArchitecture.ProductionAssembly
            .GetTypes()
            .Where(type => !IsCompilerGenerated(type))
            .ToArray();

        [Test]
        public void GivenProductionAssembly_WhenSelectingTypes_ThenAtLeastOneTypeIsFound()
            => Assert.That(
                ProductionTypes,
                Is.Not.Empty,
                "Vacuous-selector guard: no production types were loaded.");

        [Test]
        public void GivenProductionTypes_WhenCheckingMutableStaticFields_ThenNoneAreDeclared()
        {
            FieldInfo[] mutableStaticFields = ProductionTypes
                .SelectMany(type => type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                .Where(field => !field.IsInitOnly)
                .Where(field => !field.IsDefined(typeof(CompilerGeneratedAttribute), false))
                .ToArray();

            Assert.That(
                mutableStaticFields,
                Is.Empty,
                "Violated convention: production types must not declare mutable static fields.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingInstanceFields_ThenTheyAreReadOnlyOrAutoBacked()
        {
            FieldInfo[] mutableInstanceFields = ProductionTypes
                .Where(type => !type.IsValueType)
                .SelectMany(type => type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                .Where(field => !field.IsInitOnly)
                .Where(field => !field.IsDefined(typeof(CompilerGeneratedAttribute), false))
                .ToArray();

            Assert.That(
                mutableInstanceFields,
                Is.Empty,
                "Violated convention: production reference types must not declare mutable instance fields.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingDisposability_ThenNoneImplementIDisposable()
        {
            Type[] disposableTypes = ProductionTypes
                .Where(type => typeof(IDisposable).IsAssignableFrom(type))
                .ToArray();

            Assert.That(
                disposableTypes,
                Is.Empty,
                "Violated convention: production types must not implement IDisposable.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingAsynchrony_ThenNoAsyncMembersAreExposed()
        {
            MethodInfo[] asyncMethods = ProductionTypes
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                .Where(method => typeof(System.Threading.Tasks.Task).IsAssignableFrom(method.ReturnType))
                .ToArray();

            Assert.That(
                asyncMethods,
                Is.Empty,
                "Violated convention: production code must remain synchronous.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingEqualityMembers_ThenValueTypesOverrideThem()
        {
            foreach (Type valueType in ProductionTypes.Where(type => type.IsValueType && type.IsPublic))
            {
                MethodInfo? equalsOverride = valueType.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, [typeof(object)]);
                MethodInfo? hashCodeOverride = valueType.GetMethod("GetHashCode", BindingFlags.Public | BindingFlags.Instance, Type.EmptyTypes);

                Assert.That(
                    equalsOverride?.DeclaringType,
                    Is.EqualTo(valueType),
                    $"Violated convention: {valueType.Name} must override Equals(object).");
                Assert.That(
                    hashCodeOverride?.DeclaringType,
                    Is.EqualTo(valueType),
                    $"Violated convention: {valueType.Name} must override GetHashCode().");
            }
        }

        [Test]
        public void GivenProductionValueTypes_WhenCheckingEqualityOperators_ThenEachDeclaresBothOperators()
        {
            foreach (Type valueType in ProductionTypes.Where(type => type.IsValueType && type.IsPublic))
            {
                MethodInfo? equalityOperator = valueType.GetMethod("op_Equality");
                MethodInfo? inequalityOperator = valueType.GetMethod("op_Inequality");

                Assert.That(
                    equalityOperator,
                    Is.Not.Null,
                    $"Violated convention: {valueType.Name} must declare the equality operator.");
                Assert.That(
                    inequalityOperator,
                    Is.Not.Null,
                    $"Violated convention: {valueType.Name} must declare the inequality operator.");
            }
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingNestedTypes_ThenOnlyCompilerGeneratedOnesExist()
        {
            Type[] handwrittenNestedTypes = ProductionTypes
                .SelectMany(type => type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
                .Where(nestedType => !IsCompilerGenerated(nestedType))
                .ToArray();

            Assert.That(
                handwrittenNestedTypes,
                Is.Empty,
                "Violated convention: handwritten nested types are prohibited; extract them to separate files.");
        }

        [Test]
        public void GivenProductionAssembly_WhenCheckingFriendAssemblies_ThenNoneAreDeclared()
        {
            InternalsVisibleToAttribute[] friendAssemblies = ProductionArchitecture.ProductionAssembly
                .GetCustomAttributes<InternalsVisibleToAttribute>()
                .ToArray();

            Assert.That(
                friendAssemblies,
                Is.Empty,
                "Violated convention: the production assembly must not expose internals to friends.");
        }

        [Test]
        public void GivenProductionTypes_WhenCheckingAccessibility_ThenEachIsPublicOrInternal()
        {
            Type[] nonPublicTypes = ProductionTypes
                .Where(type => !type.IsPublic && !type.IsNestedPublic && !type.IsNestedAssembly)
                .ToArray();

            Assert.That(
                nonPublicTypes,
                Is.Empty,
                "Violated convention: production types must be public or internal.");
        }

        private static bool IsCompilerGenerated(Type type)
            => type.Name.StartsWith('<') ||
                type.IsDefined(typeof(CompilerGeneratedAttribute), false) ||
                type.Name.Contains("<>", StringComparison.Ordinal);
    }
}
