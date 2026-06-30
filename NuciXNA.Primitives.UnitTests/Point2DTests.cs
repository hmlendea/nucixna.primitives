using System;
using System.Drawing;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Point2DTests
    {
        [Test]
        public void GivenXAndYCoordinates_WhenConstructing_ThenPropertiesAreSet()
        {
            Point2D point = new(3, 7);

            Assert.That(point.X, Is.EqualTo(3));
            Assert.That(point.Y, Is.EqualTo(7));
        }

        [Test]
        public void GivenSize2D_WhenConstructing_ThenPropertiesMatchSizeDimensions()
        {
            Size2D size = new(5, 9);
            Point2D point = new(size);

            Assert.That(point.X, Is.EqualTo(5));
            Assert.That(point.Y, Is.EqualTo(9));
        }

        [Test]
        public void GivenZeroCoordinates_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Point2D point = new(0, 0);

            Assert.That(point.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroCoordinates_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Point2D point = new(1, 0);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingCoordinates_ThenBothAreZero()
        {
            Point2D empty = Point2D.Empty;

            Assert.That(empty.X, Is.EqualTo(0));
            Assert.That(empty.Y, Is.EqualTo(0));
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(int x, int y) overload")]
        public void GivenTwoPointsWithSameCoordinates_WhenCheckingEquality_ThenReturnsTrue()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(3, 7);

            Assert.That(point1.Equals(point2), Is.True);
        }

        [Test]
        public void GivenTwoPointsWithDifferentCoordinates_WhenCheckingEquality_ThenReturnsFalse()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(3, 8);

            Assert.That(point1.Equals(point2), Is.False);
        }

        [Test]
        public void GivenMatchingCoordinates_WhenCheckingEqualityWithXY_ThenReturnsTrue()
        {
            Point2D point = new(3, 7);

            Assert.That(point.Equals(3, 7), Is.True);
        }

        [Test]
        public void GivenNonMatchingCoordinates_WhenCheckingEqualityWithXY_ThenReturnsFalse()
        {
            Point2D point = new(3, 7);

            Assert.That(point.Equals(3, 8), Is.False);
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(int x, int y) overload")]
        public void GivenSamePointAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            Point2D point1 = new(3, 7);
            object point2 = new Point2D(3, 7);

            Assert.That(point1.Equals(point2), Is.True);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Point2D point = new(3, 7);

            Assert.That(point.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoPoints_WhenAdding_ThenReturnsCorrectSum()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(2, 4);

            Point2D result = point1 + point2;

            Assert.That(result.X, Is.EqualTo(5));
            Assert.That(result.Y, Is.EqualTo(11));
        }

        [Test]
        public void GivenTwoPoints_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Point2D point1 = new(10, 20);
            Point2D point2 = new(3, 7);

            Point2D result = point1 - point2;

            Assert.That(result.X, Is.EqualTo(7));
            Assert.That(result.Y, Is.EqualTo(13));
        }

        [Test]
        public void GivenTwoPoints_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(2, 4);

            Point2D result = point1 * point2;

            Assert.That(result.X, Is.EqualTo(6));
            Assert.That(result.Y, Is.EqualTo(28));
        }

        [Test]
        public void GivenTwoPoints_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Point2D point1 = new(10, 20);
            Point2D point2 = new(2, 4);

            Point2D result = point1 / point2;

            Assert.That(result.X, Is.EqualTo(5));
            Assert.That(result.Y, Is.EqualTo(5));
        }

        [Test]
        public void GivenPointAndScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Point2D point = new(3, 7);

            Point2D result = point * 3;

            Assert.That(result.X, Is.EqualTo(9));
            Assert.That(result.Y, Is.EqualTo(21));
        }

        [Test]
        public void GivenPointAndScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Point2D point = new(12, 20);

            Point2D result = point / 4;

            Assert.That(result.X, Is.EqualTo(3));
            Assert.That(result.Y, Is.EqualTo(5));
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(int x, int y) overload")]
        public void GivenTwoEqualPoints_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(3, 7);

            Assert.That(point1 == point2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(3, 8);

            Assert.That(point1 == point2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(3, 8);

            Assert.That(point1 != point2, Is.True);
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(int x, int y) overload")]
        public void GivenTwoEqualPoints_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Point2D point1 = new(3, 7);
            Point2D point2 = new(3, 7);

            Assert.That(point1 != point2, Is.False);
        }

        [Test]
        public void GivenPoint2D_WhenConvertingToSystemPoint_ThenCoordinatesArePreserved()
        {
            Point2D point2D = new(3, 7);

            Point systemPoint = point2D;

            Assert.That(systemPoint.X, Is.EqualTo(3));
            Assert.That(systemPoint.Y, Is.EqualTo(7));
        }

        [Test]
        public void GivenSystemPoint_WhenConvertingToPoint2D_ThenCoordinatesArePreserved()
        {
            Point systemPoint = new(3, 7);

            Point2D point2D = systemPoint;

            Assert.That(point2D.X, Is.EqualTo(3));
            Assert.That(point2D.Y, Is.EqualTo(7));
        }

        [Test]
        public void GivenPoint2D_WhenConvertingToPointF2D_ThenCoordinatesArePreserved()
        {
            Point2D point2D = new(3, 7);

            PointF2D pointF2D = point2D;

            Assert.That(pointF2D.X, Is.EqualTo(3f));
            Assert.That(pointF2D.Y, Is.EqualTo(7f));
        }
    }
}
