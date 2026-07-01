using System.Drawing;

using Microsoft.Xna.Framework;

using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using SystemSize = System.Drawing.Size;
using XnaPoint = Microsoft.Xna.Framework.Point;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    public class SizeMappingExtensionsTests
    {
        [Test]
        public void GivenSystemSize_WhenConvertingToSize2D_ThenDimensionsArePreserved()
        {
            SystemSize source = new(12, 34);
            Size2D result = source.ToSize2D();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public void GivenXnaPoint_WhenConvertingToSize2D_ThenDimensionsArePreserved()
        {
            XnaPoint source = new(12, 34);
            Size2D result = source.ToSize2D();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public void GivenSize2D_WhenConvertingToSystemSize_ThenDimensionsArePreserved()
        {
            Size2D source = new(12, 34);
            SystemSize result = source.ToSystemSize();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public void GivenXnaPoint_WhenConvertingToSystemSize_ThenDimensionsArePreserved()
        {
            XnaPoint source = new(12, 34);
            SystemSize result = source.ToSystemSize();

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(34));
        }

        [Test]
        public void GivenSize2D_WhenConvertingToXnaPoint_ThenDimensionsArePreserved()
        {
            Size2D source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenSystemSize_WhenConvertingToXnaPoint_ThenDimensionsArePreserved()
        {
            SystemSize source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }
    }
}
