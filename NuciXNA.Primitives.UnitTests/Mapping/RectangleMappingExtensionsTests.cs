using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using SystemRectangle = System.Drawing.Rectangle;
using XnaRectangle = Microsoft.Xna.Framework.Rectangle;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    public class RectangleMappingExtensionsTests
    {
        [Test]
        public void GivenSystemRectangle_WhenConvertingToRectangle2D_ThenValuesArePreserved()
        {
            SystemRectangle source = new(1, 2, 10, 20);
            Rectangle2D result = source.ToRectangle2D();

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenXnaRectangle_WhenConvertingToRectangle2D_ThenValuesArePreserved()
        {
            XnaRectangle source = new(1, 2, 10, 20);
            Rectangle2D result = source.ToRectangle2D();

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenRectangle2D_WhenConvertingToSystemRectangle_ThenValuesArePreserved()
        {
            Rectangle2D source = new(1, 2, 10, 20);
            SystemRectangle result = source.ToSystemRectangle();

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenXnaRectangle_WhenConvertingToSystemRectangle_ThenValuesArePreserved()
        {
            XnaRectangle source = new(1, 2, 10, 20);
            SystemRectangle result = source.ToSystemRectangle();

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenRectangle2D_WhenConvertingToXnaRectangle_ThenValuesArePreserved()
        {
            Rectangle2D source = new(1, 2, 10, 20);
            XnaRectangle result = source.ToXnaRectangle();

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenSystemRectangle_WhenConvertingToXnaRectangle_ThenValuesArePreserved()
        {
            SystemRectangle source = new(1, 2, 10, 20);
            XnaRectangle result = source.ToXnaRectangle();

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }
    }
}
