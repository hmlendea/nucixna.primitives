using System;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Point3DTests
    {
        [Test]
        public void GivenXYZCoordinates_WhenConstructing_ThenPropertiesAreSet()
        {
            Point3D point = new(3, 7, 11);

            Assert.That(point.X, Is.EqualTo(3));
            Assert.That(point.Y, Is.EqualTo(7));
            Assert.That(point.Z, Is.EqualTo(11));
        }

        [Test]
        public void GivenPoint2DAndZ_WhenConstructing_ThenPropertiesAreSet()
        {
            Point2D point2D = new(3, 7);
            Point3D point3D = new(point2D, 11);

            Assert.That(point3D.X, Is.EqualTo(3));
            Assert.That(point3D.Y, Is.EqualTo(7));
            Assert.That(point3D.Z, Is.EqualTo(11));
        }

        [Test]
        public void GivenZeroCoordinates_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Point3D point = new(0, 0, 0);

            Assert.That(point.IsEmpty);
        }

        [Test]
        public void GivenNonZeroXCoordinate_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Point3D point = new(1, 0, 0);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenNonZeroYCoordinate_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Point3D point = new(0, 1, 0);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenNonZeroZCoordinate_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Point3D point = new(0, 0, 1);

            Assert.That(point.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingCoordinates_ThenAllAreZero()
        {
            Point3D empty = Point3D.Empty;

            Assert.That(empty.X, Is.EqualTo(0));
            Assert.That(empty.Y, Is.EqualTo(0));
            Assert.That(empty.Z, Is.EqualTo(0));
        }

        [Test]
        public void GivenTwoPointsWithSameCoordinates_WhenCheckingEquality_ThenReturnsTrue()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 11);

            Assert.That(point1.Equals(point2));
        }

        [Test]
        public void GivenTwoPointsWithDifferentZCoordinate_WhenCheckingEquality_ThenReturnsFalse()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 12);

            Assert.That(point1.Equals(point2), Is.False);
        }

        [Test]
        public void GivenMatchingCoordinates_WhenCheckingEqualityWithXYZ_ThenReturnsTrue()
        {
            Point3D point = new(3, 7, 11);

            Assert.That(point.Equals(3, 7, 11));
        }

        [Test]
        public void GivenNonMatchingCoordinates_WhenCheckingEqualityWithXYZ_ThenReturnsFalse()
        {
            Point3D point = new(3, 7, 11);

            Assert.That(point.Equals(3, 7, 12), Is.False);
        }

        [Test]
        public void GivenSamePointBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            Point3D point = new(3, 7, 11);

            Assert.That(point.Equals((object)new Point3D(3, 7, 11)));
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Point3D point = new(3, 7, 11);

            Assert.That(point.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoPointsWithSameCoordinates_WhenGettingHashCode_ThenReturnSameHash()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 11);

            Assert.That(point1.GetHashCode(), Is.EqualTo(point2.GetHashCode()));
        }

        [Test]
        public void GivenTwoPointsWithDifferentCoordinates_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 12);

            Assert.That(point1.GetHashCode(), Is.Not.EqualTo(point2.GetHashCode()));
        }

        [Test]
        public void GivenTwoPoints_WhenAdding_ThenReturnsCorrectSum()
        {
            Point3D point1 = new(1, 2, 3);
            Point3D point2 = new(4, 5, 6);

            Point3D result = point1 + point2;

            Assert.That(result.X, Is.EqualTo(5));
            Assert.That(result.Y, Is.EqualTo(7));
            Assert.That(result.Z, Is.EqualTo(9));
        }

        [Test]
        public void GivenTwoPoints_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Point3D point1 = new(10, 20, 30);
            Point3D point2 = new(1, 2, 3);

            Point3D result = point1 - point2;

            Assert.That(result.X, Is.EqualTo(9));
            Assert.That(result.Y, Is.EqualTo(18));
            Assert.That(result.Z, Is.EqualTo(27));
        }

        [Test]
        public void GivenTwoPoints_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Point3D point1 = new(2, 3, 4);
            Point3D point2 = new(5, 6, 7);

            Point3D result = point1 * point2;

            Assert.That(result.X, Is.EqualTo(10));
            Assert.That(result.Y, Is.EqualTo(18));
            Assert.That(result.Z, Is.EqualTo(28));
        }

        [Test]
        public void GivenTwoPoints_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Point3D point1 = new(10, 20, 30);
            Point3D point2 = new(2, 4, 5);

            Point3D result = point1 / point2;

            Assert.That(result.X, Is.EqualTo(5));
            Assert.That(result.Y, Is.EqualTo(5));
            Assert.That(result.Z, Is.EqualTo(6));
        }

        [Test]
        public void GivenPointAndScalar_WhenMultiplying_ThenAllComponentsAreScaled()
        {
            Point3D point = new(2, 3, 4);

            Point3D result = point * 3;

            Assert.That(result.X, Is.EqualTo(6));
            Assert.That(result.Y, Is.EqualTo(9));
            Assert.That(result.Z, Is.EqualTo(12));
        }

        [Test]
        public void GivenPointAndScalar_WhenDividing_ThenAllComponentsAreDivided()
        {
            Point3D point = new(6, 9, 12);

            Point3D result = point / 3;

            Assert.That(result.X, Is.EqualTo(2));
            Assert.That(result.Y, Is.EqualTo(3));
            Assert.That(result.Z, Is.EqualTo(4));
        }

        [Test]
        public void GivenTwoEqualPoints_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 11);

            Assert.That(point1 == point2);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 12);

            Assert.That(point1 == point2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentPoints_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 12);

            Assert.That(point1 != point2);
        }

        [Test]
        public void GivenTwoEqualPoints_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Point3D point1 = new(3, 7, 11);
            Point3D point2 = new(3, 7, 11);

            Assert.That(point1 != point2, Is.False);
        }
    }
}
