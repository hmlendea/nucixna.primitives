using ArchUnitNET.Domain;
using ArchUnitNET.Loader;

using static ArchUnitNET.Fluent.ArchRuleDefinition;

using Assembly = System.Reflection.Assembly;

using NuciXNA.Primitives;

namespace NuciXNA.Primitives.ArchitectureTests
{
    internal static class ProductionArchitecture
    {
        internal static Assembly ProductionAssembly { get; } = typeof(Point2D).Assembly;

        internal static Architecture Model { get; } = new ArchLoader()
            .LoadAssemblies(ProductionAssembly)
            .Build();

        internal static IObjectProvider<IType> ProductionTypes { get; } = Types()
            .That()
            .ResideInAssembly(ProductionAssembly)
            .As("NuciXNA.Primitives production types");
    }
}
