using System.Drawing;

using Microsoft.Xna.Framework;

using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using SystemSize = System.Drawing.Size;
using XnaPoint = Microsoft.Xna.Framework.Point;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    [TestFixture]
    public sealed class SizeMappingExtensionsTests
    {
        [Test]
        public static void GivenSystemSize_WhenConvertingToSize2D_ThenDimensionsArePreserved()
        {
            SystemSize source = new(12, 34);
            Size2D result = source.ToSize2D();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public static void GivenXnaPoint_WhenConvertingToSize2D_ThenDimensionsArePreserved()
        {
            XnaPoint source = new(12, 34);
            Size2D result = source.ToSize2D();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public static void GivenSize2D_WhenConvertingToSystemSize_ThenDimensionsArePreserved()
        {
            Size2D source = new(12, 34);
            SystemSize result = source.ToSystemSize();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public static void GivenXnaPoint_WhenConvertingToSystemSize_ThenDimensionsArePreserved()
        {
            XnaPoint source = new(12, 34);
            SystemSize result = source.ToSystemSize();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public static void GivenSize2D_WhenConvertingToXnaPoint_ThenDimensionsArePreserved()
        {
            Size2D source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenSystemSize_WhenConvertingToXnaPoint_ThenDimensionsArePreserved()
        {
            SystemSize source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenSize2D_WhenRoundTrippingThroughSystemSize_ThenDimensionsArePreserved()
        {
            Size2D size = new(7, 13);
            Size2D result = size.ToSystemSize().ToSize2D();

            Assert.That(result, Is.EqualTo(size));
        }

        [Test]
        public static void GivenSize2D_WhenRoundTrippingThroughXnaPoint_ThenDimensionsArePreserved()
        {
            Size2D size = new(7, 13);
            Size2D result = size.ToXnaPoint().ToSize2D();

            Assert.That(result, Is.EqualTo(size));
        }
    }
}
