using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using SystemPoint = System.Drawing.Point;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using XnaPoint = Microsoft.Xna.Framework.Point;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    public class PointMappingExtensionsTests
    {
        [Test]
        public void GivenSystemPoint_WhenConvertingToPoint2D_ThenCoordinatesArePreserved()
        {
            SystemPoint source = new(12, 34);
            Point2D result = source.ToPoint2D();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenVector2_WhenConvertingToPoint2D_ThenCoordinatesAreTruncated()
        {
            Vector2 source = new(12.9f, 34.9f);
            Point2D result = source.ToPoint2D();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenXnaPoint_WhenConvertingToPoint2D_ThenCoordinatesArePreserved()
        {
            XnaPoint source = new(12, 34);
            Point2D result = source.ToPoint2D();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenPoint2D_WhenConvertingToSystemPoint_ThenCoordinatesArePreserved()
        {
            Point2D source = new(12, 34);
            SystemPoint result = source.ToSystemPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenVector2_WhenConvertingToSystemPoint_ThenCoordinatesAreTruncated()
        {
            Vector2 source = new(12.9f, 34.9f);
            SystemPoint result = source.ToSystemPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenXnaPoint_WhenConvertingToSystemPoint_ThenCoordinatesArePreserved()
        {
            XnaPoint source = new(12, 34);
            SystemPoint result = source.ToSystemPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenSystemPoint_WhenConvertingToXnaVector2_ThenCoordinatesArePreserved()
        {
            SystemPoint source = new(12, 34);
            Vector2 result = source.ToXnaVector2();

            Assert.That(result.X, Is.EqualTo(12f));
            Assert.That(result.Y, Is.EqualTo(34f));
        }

        [Test]
        public void GivenPoint2D_WhenConvertingToXnaVector2_ThenCoordinatesArePreserved()
        {
            Point2D source = new(12, 34);
            Vector2 result = source.ToXnaVector2();

            Assert.That(result.X, Is.EqualTo(12f));
            Assert.That(result.Y, Is.EqualTo(34f));
        }

        [Test]
        public void GivenPoint2D_WhenConvertingToXnaPoint_ThenCoordinatesArePreserved()
        {
            Point2D source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public void GivenSystemPoint_WhenConvertingToXnaPoint_ThenCoordinatesArePreserved()
        {
            SystemPoint source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }
    }
}
