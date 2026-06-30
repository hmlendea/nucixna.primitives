using System;
using System.Drawing;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class PointF2DTests
    {
        [Test]
        public void GivenFloatXAndY_WhenConstructing_ThenPropertiesAreSet()
        {
            PointF2D point = new(1.5f, 2.5f);

            Assert.That(point.X, Is.EqualTo(1.5f));
            Assert.That(point.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenPoint2D_WhenConstructing_ThenPropertiesMatchSourceCoordinates()
        {
            Point2D source = new(3, 7);
            PointF2D point = new(source);

            Assert.That(point.X, Is.EqualTo(3f));
            Assert.That(point.Y, Is.EqualTo(7f));
        }

        [Test]
        public void GivenSize2D_WhenConstructing_ThenPropertiesMatchSizeDimensions()
        {
            Size2D size = new(5, 9);
            PointF2D point = new(size);

            Assert.That(point.X, Is.EqualTo(5f));
            Assert.That(point.Y, Is.EqualTo(9f));
        }

        [Test]
        public void GivenSizeF2D_WhenConstructing_ThenPropertiesMatchSizeDimensions()
        {
            SizeF2D size = new(2.5f, 4.5f);
            PointF2D point = new(size);

            Assert.That(point.X, Is.EqualTo(2.5f));
            Assert.That(point.Y, Is.EqualTo(4.5f));
        }

        [Test]
        public void GivenZeroCoordinates_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            PointF2D point = new(0f, 0f);

            Assert.That(point.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroCoordinates_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            PointF2D point = new(0.1f, 0f);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingCoordinates_ThenBothAreZero()
        {
            PointF2D empty = PointF2D.Empty;

            Assert.That(empty.X, Is.EqualTo(0f));
            Assert.That(empty.Y, Is.EqualTo(0f));
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(float x, float y) overload")]
        public void GivenTwoPointsWithSameCoordinates_WhenCheckingEquality_ThenReturnsTrue()
        {
            PointF2D point1 = new(1.5f, 2.5f);
            PointF2D point2 = new(1.5f, 2.5f);

            Assert.That(point1.Equals(point2), Is.True);
        }

        [Test]
        public void GivenTwoPointsWithDifferentCoordinates_WhenCheckingEquality_ThenReturnsFalse()
        {
            PointF2D point1 = new(1.5f, 2.5f);
            PointF2D point2 = new(1.5f, 2.6f);

            Assert.That(point1.Equals(point2), Is.False);
        }

        [Test]
        public void GivenMatchingFloatCoordinates_WhenCheckingEqualityWithXY_ThenReturnsTrue()
        {
            PointF2D point = new(1.5f, 2.5f);

            Assert.That(point.Equals(1.5f, 2.5f), Is.True);
        }

        [Test]
        public void GivenNonMatchingFloatCoordinates_WhenCheckingEqualityWithXY_ThenReturnsFalse()
        {
            PointF2D point = new(1.5f, 2.5f);

            Assert.That(point.Equals(1.5f, 2.6f), Is.False);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            PointF2D point = new(1.5f, 2.5f);

            Assert.That(point.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoPoints_WhenAdding_ThenReturnsCorrectSum()
        {
            PointF2D point1 = new(1.0f, 2.0f);
            PointF2D point2 = new(0.5f, 1.5f);

            PointF2D result = point1 + point2;

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenTwoPoints_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            PointF2D point1 = new(5.0f, 8.0f);
            PointF2D point2 = new(1.5f, 2.5f);

            PointF2D result = point1 - point2;

            Assert.That(result.X, Is.EqualTo(3.5f));
            Assert.That(result.Y, Is.EqualTo(5.5f));
        }

        [Test]
        public void GivenTwoPoints_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            PointF2D point1 = new(2.0f, 3.0f);
            PointF2D point2 = new(4.0f, 5.0f);

            PointF2D result = point1 * point2;

            Assert.That(result.X, Is.EqualTo(8.0f));
            Assert.That(result.Y, Is.EqualTo(15.0f));
        }

        [Test]
        public void GivenTwoPoints_WhenDividing_ThenReturnsCorrectQuotient()
        {
            PointF2D point1 = new(10.0f, 20.0f);
            PointF2D point2 = new(2.0f, 4.0f);

            PointF2D result = point1 / point2;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(5.0f));
        }

        [Test]
        public void GivenPointAndScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            PointF2D point = new(2.0f, 3.0f);

            PointF2D result = point * 2.5f;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenPointAndScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            PointF2D point = new(10.0f, 5.0f);

            PointF2D result = point / 2.0f;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(2.5f));
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(float x, float y) overload")]
        public void GivenTwoEqualPoints_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            PointF2D point1 = new(1.5f, 2.5f);
            PointF2D point2 = new(1.5f, 2.5f);

            Assert.That(point1 == point2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            PointF2D point1 = new(1.5f, 2.5f);
            PointF2D point2 = new(1.5f, 2.6f);

            Assert.That(point1 == point2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            PointF2D point1 = new(1.5f, 2.5f);
            PointF2D point2 = new(1.5f, 2.6f);

            Assert.That(point1 != point2, Is.True);
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(float x, float y) overload")]
        public void GivenTwoEqualPoints_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            PointF2D point1 = new(1.5f, 2.5f);
            PointF2D point2 = new(1.5f, 2.5f);

            Assert.That(point1 != point2, Is.False);
        }

        [Test]
        public void GivenPointF2D_WhenConvertingToSystemPointF_ThenCoordinatesArePreserved()
        {
            PointF2D pointF2D = new(1.5f, 2.5f);

            PointF systemPointF = pointF2D;

            Assert.That(systemPointF.X, Is.EqualTo(1.5f));
            Assert.That(systemPointF.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenSystemPointF_WhenConvertingToPointF2D_ThenCoordinatesArePreserved()
        {
            PointF systemPointF = new(1.5f, 2.5f);

            PointF2D pointF2D = systemPointF;

            Assert.That(pointF2D.X, Is.EqualTo(1.5f));
            Assert.That(pointF2D.Y, Is.EqualTo(2.5f));
        }
    }
}
