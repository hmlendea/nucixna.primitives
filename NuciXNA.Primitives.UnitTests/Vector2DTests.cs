using System;

using Microsoft.Xna.Framework;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Vector2DTests
    {
        [Test]
        public void GivenXAndYValues_WhenConstructing_ThenPropertiesAreSet()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.X, Is.EqualTo(1.5f));
            Assert.That(vector.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenPoint2D_WhenConstructing_ThenPropertiesMatchPointCoordinates()
        {
            Point2D point = new(3, 7);
            Vector2D vector = new(point);

            Assert.That(vector.X, Is.EqualTo(3f));
            Assert.That(vector.Y, Is.EqualTo(7f));
        }

        [Test]
        public void GivenZeroValues_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Vector2D vector = new(0f, 0f);

            Assert.That(vector.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroValues_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Vector2D vector = new(1.0f, 0f);

            Assert.That(vector.IsEmpty, Is.False);
        }

        [Test]
        public void GivenZeroStatic_WhenCheckingValues_ThenBothAreZero()
        {
            Vector2D zero = Vector2D.Zero;

            Assert.That(zero.X, Is.EqualTo(0f));
            Assert.That(zero.Y, Is.EqualTo(0f));
        }

        [Test]
        public void GivenOneStatic_WhenCheckingValues_ThenBothAreOne()
        {
            Vector2D one = Vector2D.One;

            Assert.That(one.X, Is.EqualTo(1f));
            Assert.That(one.Y, Is.EqualTo(1f));
        }

        [Test]
        public void GivenTwoVectorsWithSameValues_WhenCheckingEquality_ThenReturnsTrue()
        {
            Vector2D v1 = new(1.5f, 2.5f);
            Vector2D v2 = new(1.5f, 2.5f);

            Assert.That(v1.Equals(v2), Is.True);
        }

        [Test]
        public void GivenTwoVectorsWithDifferentValues_WhenCheckingEquality_ThenReturnsFalse()
        {
            Vector2D v1 = new(1.5f, 2.5f);
            Vector2D v2 = new(1.5f, 2.6f);

            Assert.That(v1.Equals(v2), Is.False);
        }

        [Test]
        public void GivenMatchingFloatValues_WhenCheckingEqualityWithXY_ThenReturnsTrue()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.Equals(1.5f, 2.5f), Is.True);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoVectors_WhenAdding_ThenReturnsCorrectSum()
        {
            Vector2D v1 = new(1.0f, 2.0f);
            Vector2D v2 = new(0.5f, 1.5f);

            Vector2D result = v1 + v2;

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenTwoVectors_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Vector2D v1 = new(5.0f, 8.0f);
            Vector2D v2 = new(1.5f, 2.5f);

            Vector2D result = v1 - v2;

            Assert.That(result.X, Is.EqualTo(3.5f));
            Assert.That(result.Y, Is.EqualTo(5.5f));
        }

        [Test]
        public void GivenTwoVectors_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Vector2D v1 = new(2.0f, 3.0f);
            Vector2D v2 = new(4.0f, 5.0f);

            Vector2D result = v1 * v2;

            Assert.That(result.X, Is.EqualTo(8.0f));
            Assert.That(result.Y, Is.EqualTo(15.0f));
        }

        [Test]
        public void GivenTwoVectors_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Vector2D v1 = new(10.0f, 20.0f);
            Vector2D v2 = new(2.0f, 4.0f);

            Vector2D result = v1 / v2;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(5.0f));
        }

        [Test]
        public void GivenTwoEqualVectors_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Vector2D v1 = new(1.5f, 2.5f);
            Vector2D v2 = new(1.5f, 2.5f);

            Assert.That(v1 == v2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentVectors_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Vector2D v1 = new(1.5f, 2.5f);
            Vector2D v2 = new(1.5f, 2.6f);

            Assert.That(v1 == v2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentVectors_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Vector2D v1 = new(1.5f, 2.5f);
            Vector2D v2 = new(1.5f, 2.6f);

            Assert.That(v1 != v2, Is.True);
        }

        [Test]
        public void GivenTwoEqualVectors_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Vector2D v1 = new(1.5f, 2.5f);
            Vector2D v2 = new(1.5f, 2.5f);

            Assert.That(v1 != v2, Is.False);
        }

        [Test]
        public void GivenVector2D_WhenConvertingToXnaVector2_ThenValuesArePreserved()
        {
            Vector2D vector2D = new(1.5f, 2.5f);

            Vector2 xnaVector = vector2D;

            Assert.That(xnaVector.X, Is.EqualTo(1.5f));
            Assert.That(xnaVector.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenXnaVector2_WhenConvertingToVector2D_ThenValuesArePreserved()
        {
            Vector2 xnaVector = new(1.5f, 2.5f);

            Vector2D vector2D = xnaVector;

            Assert.That(vector2D.X, Is.EqualTo(1.5f));
            Assert.That(vector2D.Y, Is.EqualTo(2.5f));
        }
    }
}
