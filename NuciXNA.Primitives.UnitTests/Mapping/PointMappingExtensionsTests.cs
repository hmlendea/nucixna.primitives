using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using SystemPoint = System.Drawing.Point;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using XnaPoint = Microsoft.Xna.Framework.Point;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    [TestFixture]
    public sealed class PointMappingExtensionsTests
    {
        [Test]
        public static void GivenSystemPoint_WhenConvertingToPoint2D_ThenCoordinatesArePreserved()
        {
            SystemPoint source = new(12, 34);
            Point2D result = source.ToPoint2D();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenVector2_WhenConvertingToPoint2D_ThenCoordinatesAreTruncated()
        {
            Vector2 source = new(12.9f, 34.9f);
            Point2D result = source.ToPoint2D();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenXnaPoint_WhenConvertingToPoint2D_ThenCoordinatesArePreserved()
        {
            XnaPoint source = new(12, 34);
            Point2D result = source.ToPoint2D();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenPoint2D_WhenConvertingToSystemPoint_ThenCoordinatesArePreserved()
        {
            Point2D source = new(12, 34);
            SystemPoint result = source.ToSystemPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenVector2_WhenConvertingToSystemPoint_ThenCoordinatesAreTruncated()
        {
            Vector2 source = new(12.9f, 34.9f);
            SystemPoint result = source.ToSystemPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenXnaPoint_WhenConvertingToSystemPoint_ThenCoordinatesArePreserved()
        {
            XnaPoint source = new(12, 34);
            SystemPoint result = source.ToSystemPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenSystemPoint_WhenConvertingToXnaVector2_ThenCoordinatesArePreserved()
        {
            SystemPoint source = new(12, 34);
            Vector2 result = source.ToXnaVector2();

            Assert.That(result.X, Is.EqualTo(12f));
            Assert.That(result.Y, Is.EqualTo(34f));
        }

        [Test]
        public static void GivenPoint2D_WhenConvertingToXnaVector2_ThenCoordinatesArePreserved()
        {
            Point2D source = new(12, 34);
            Vector2 result = source.ToXnaVector2();

            Assert.That(result.X, Is.EqualTo(12f));
            Assert.That(result.Y, Is.EqualTo(34f));
        }

        [Test]
        public static void GivenPoint2D_WhenConvertingToXnaPoint_ThenCoordinatesArePreserved()
        {
            Point2D source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenSystemPoint_WhenConvertingToXnaPoint_ThenCoordinatesArePreserved()
        {
            SystemPoint source = new(12, 34);
            XnaPoint result = source.ToXnaPoint();

            Assert.That(result.X, Is.EqualTo(12));
            Assert.That(result.Y, Is.EqualTo(34));
        }

        [Test]
        public static void GivenPoint2D_WhenRoundTrippingThroughXnaPoint_ThenCoordinatesArePreserved()
        {
            Point2D point = new(7, 13);
            Point2D result = point.ToXnaPoint().ToPoint2D();

            Assert.That(result, Is.EqualTo(point));
        }

        [Test]
        public static void GivenPoint2D_WhenRoundTrippingThroughSystemPoint_ThenCoordinatesArePreserved()
        {
            Point2D point = new(7, 13);
            Point2D result = point.ToSystemPoint().ToPoint2D();

            Assert.That(result, Is.EqualTo(point));
        }

        [Test]
        public static void GivenVector2_WhenRoundTrippingThroughPoint2D_ThenIntegerCoordinatesArePreserved()
        {
            Vector2 vector = new(7f, 13f);
            Vector2 result = vector.ToPoint2D().ToXnaVector2();

            Assert.That(result.X, Is.EqualTo(7f));
            Assert.That(result.Y, Is.EqualTo(13f));
        }
    }
}
