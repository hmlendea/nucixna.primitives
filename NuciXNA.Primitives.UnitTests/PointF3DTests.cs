using System;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class PointF3DTests
    {
        [Test]
        public void GivenFloatXYZ_WhenConstructing_ThenPropertiesAreSet()
        {
            PointF3D point = new(1.5f, 2.5f, 3.5f);

            Assert.That(point.X, Is.EqualTo(1.5f));
            Assert.That(point.Y, Is.EqualTo(2.5f));
            Assert.That(point.Z, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenPoint3D_WhenConstructing_ThenCoordinatesArePreserved()
        {
            Point3D source = new(2, 4, 6);
            PointF3D point = new(source);

            Assert.That(point.X, Is.EqualTo(2f));
            Assert.That(point.Y, Is.EqualTo(4f));
            Assert.That(point.Z, Is.EqualTo(6f));
        }

        [Test]
        public void GivenPointF2DAndIntZ_WhenConstructing_ThenAllPropertiesAreSet()
        {
            PointF2D point2D = new(1.5f, 2.5f);
            PointF3D point3D = new(point2D, 3);

            Assert.That(point3D.X, Is.EqualTo(1.5f));
            Assert.That(point3D.Y, Is.EqualTo(2.5f));
            Assert.That(point3D.Z, Is.EqualTo(3f));
        }

        [Test]
        public void GivenPointF2DAndFloatZ_WhenConstructing_ThenAllPropertiesAreSet()
        {
            PointF2D point2D = new(1.5f, 2.5f);
            PointF3D point3D = new(point2D, 3.5f);

            Assert.That(point3D.X, Is.EqualTo(1.5f));
            Assert.That(point3D.Y, Is.EqualTo(2.5f));
            Assert.That(point3D.Z, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenPoint2DAndIntZ_WhenConstructing_ThenAllPropertiesAreSet()
        {
            Point2D point2D = new(3, 7);
            PointF3D point3D = new(point2D, 11);

            Assert.That(point3D.X, Is.EqualTo(3f));
            Assert.That(point3D.Y, Is.EqualTo(7f));
            Assert.That(point3D.Z, Is.EqualTo(11f));
        }

        [Test]
        public void GivenPoint2DAndFloatZ_WhenConstructing_ThenAllPropertiesAreSet()
        {
            Point2D point2D = new(3, 7);
            PointF3D point3D = new(point2D, 11.5f);

            Assert.That(point3D.X, Is.EqualTo(3f));
            Assert.That(point3D.Y, Is.EqualTo(7f));
            Assert.That(point3D.Z, Is.EqualTo(11.5f));
        }

        [Test]
        public void GivenZeroCoordinates_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            PointF3D point = new(0f, 0f, 0f);

            Assert.That(point.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroXCoordinate_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            PointF3D point = new(1.0f, 0f, 0f);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenNonZeroYCoordinate_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            PointF3D point = new(0f, 1.0f, 0f);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenNonZeroZCoordinate_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            PointF3D point = new(0f, 0f, 1.0f);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingCoordinates_ThenAllAreZero()
        {
            PointF3D empty = PointF3D.Empty;

            Assert.That(empty.X, Is.EqualTo(0f));
            Assert.That(empty.Y, Is.EqualTo(0f));
            Assert.That(empty.Z, Is.EqualTo(0f));
        }

        [Test]
        public void GivenTwoPointsWithSameCoordinates_WhenCheckingEquality_ThenReturnsTrue()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(point1.Equals(point2), Is.True);
        }

        [Test]
        public void GivenTwoPointsWithDifferentZCoordinate_WhenCheckingEquality_ThenReturnsFalse()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.6f);

            Assert.That(point1.Equals(point2), Is.False);
        }

        [Test]
        public void GivenMatchingFloatCoordinates_WhenCheckingEqualityWithXYZ_ThenReturnsTrue()
        {
            PointF3D point = new(1.5f, 2.5f, 3.5f);

            Assert.That(point.Equals(1.5f, 2.5f, 3.5f), Is.True);
        }

        [Test]
        public void GivenNonMatchingFloatCoordinates_WhenCheckingEqualityWithXYZ_ThenReturnsFalse()
        {
            PointF3D point = new(1.5f, 2.5f, 3.5f);

            Assert.That(point.Equals(1.5f, 2.5f, 3.6f), Is.False);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            PointF3D point = new(1.5f, 2.5f, 3.5f);

            Assert.That(point.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoPoints_WhenAdding_ThenReturnsCorrectSum()
        {
            PointF3D point1 = new(1.0f, 2.0f, 3.0f);
            PointF3D point2 = new(0.5f, 1.5f, 2.5f);

            PointF3D result = point1 + point2;

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(3.5f));
            Assert.That(result.Z, Is.EqualTo(5.5f));
        }

        [Test]
        public void GivenTwoPoints_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            PointF3D point1 = new(5.0f, 8.0f, 11.0f);
            PointF3D point2 = new(1.5f, 2.5f, 3.5f);

            PointF3D result = point1 - point2;

            Assert.That(result.X, Is.EqualTo(3.5f));
            Assert.That(result.Y, Is.EqualTo(5.5f));
            Assert.That(result.Z, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenTwoPoints_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            PointF3D point1 = new(2.0f, 3.0f, 4.0f);
            PointF3D point2 = new(5.0f, 6.0f, 7.0f);

            PointF3D result = point1 * point2;

            Assert.That(result.X, Is.EqualTo(10.0f));
            Assert.That(result.Y, Is.EqualTo(18.0f));
            Assert.That(result.Z, Is.EqualTo(28.0f));
        }

        [Test]
        public void GivenTwoPoints_WhenDividing_ThenReturnsCorrectQuotient()
        {
            PointF3D point1 = new(10.0f, 20.0f, 30.0f);
            PointF3D point2 = new(2.0f, 4.0f, 5.0f);

            PointF3D result = point1 / point2;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(5.0f));
            Assert.That(result.Z, Is.EqualTo(6.0f));
        }

        [Test]
        public void GivenPointAndScalar_WhenMultiplying_ThenAllComponentsAreScaled()
        {
            PointF3D point = new(2.0f, 3.0f, 4.0f);

            PointF3D result = point * 2.0f;

            Assert.That(result.X, Is.EqualTo(4.0f));
            Assert.That(result.Y, Is.EqualTo(6.0f));
            Assert.That(result.Z, Is.EqualTo(8.0f));
        }

        [Test]
        public void GivenPointAndScalar_WhenDividing_ThenAllComponentsAreDivided()
        {
            PointF3D point = new(6.0f, 9.0f, 12.0f);

            PointF3D result = point / 3.0f;

            Assert.That(result.X, Is.EqualTo(2.0f));
            Assert.That(result.Y, Is.EqualTo(3.0f));
            Assert.That(result.Z, Is.EqualTo(4.0f));
        }

        [Test]
        public void GivenTwoEqualPoints_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(point1 == point2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.6f);

            Assert.That(point1 == point2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.6f);

            Assert.That(point1 != point2, Is.True);
        }

        [Test]
        public void GivenTwoEqualPoints_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(point1 != point2, Is.False);
        }

        [Test]
        public void GivenSamePointBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            PointF3D point = new(1.5f, 2.5f, 3.5f);

            Assert.That(point.Equals((object)new PointF3D(1.5f, 2.5f, 3.5f)), Is.True);
        }

        [Test]
        public void GivenTwoPointsWithSameCoordinates_WhenGettingHashCode_ThenReturnSameHash()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(point1.GetHashCode(), Is.EqualTo(point2.GetHashCode()));
        }

        [Test]
        public void GivenTwoPointsWithDifferentCoordinates_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            PointF3D point1 = new(1.5f, 2.5f, 3.5f);
            PointF3D point2 = new(1.5f, 2.5f, 4.5f);

            Assert.That(point1.GetHashCode(), Is.Not.EqualTo(point2.GetHashCode()));
        }
    }
}
