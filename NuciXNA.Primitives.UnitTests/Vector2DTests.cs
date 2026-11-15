using System;

using Microsoft.Xna.Framework;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    [TestFixture]
    public sealed class Vector2DTests
    {
        [Test]
        public static void GivenXAndYValues_WhenConstructing_ThenPropertiesAreSet()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.X, Is.EqualTo(1.5f));
            Assert.That(vector.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public static void GivenPoint2D_WhenConstructing_ThenPropertiesMatchPointCoordinates()
        {
            Point2D point = new(3, 7);
            Vector2D vector = new(point);

            Assert.That(vector.X, Is.EqualTo(3f));
            Assert.That(vector.Y, Is.EqualTo(7f));
        }

        [Test]
        public static void GivenZeroValues_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Vector2D vector = new(0f, 0f);

            Assert.That(vector.IsEmpty);
        }

        [Test]
        public static void GivenNonZeroValues_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Vector2D vector = new(1.0f, 0f);

            Assert.That(vector.IsEmpty, Is.False);
        }

        [Test]
        public static void GivenZeroStatic_WhenCheckingValues_ThenBothAreZero()
        {
            Vector2D zero = Vector2D.Zero;

            Assert.That(zero.X, Is.EqualTo(0f));
            Assert.That(zero.Y, Is.EqualTo(0f));
        }

        [Test]
        public static void GivenOneStatic_WhenCheckingValues_ThenBothAreOne()
        {
            Vector2D one = Vector2D.One;

            Assert.That(one.X, Is.EqualTo(1f));
            Assert.That(one.Y, Is.EqualTo(1f));
        }

        [Test]
        public static void GivenTwoVectorsWithSameValues_WhenCheckingEquality_ThenReturnsTrue()
        {
            Vector2D firstVector = new(1.5f, 2.5f);
            Vector2D secondVector = new(1.5f, 2.5f);

            Assert.That(firstVector.Equals(secondVector));
        }

        [Test]
        public static void GivenTwoVectorsWithDifferentValues_WhenCheckingEquality_ThenReturnsFalse()
        {
            Vector2D firstVector = new(1.5f, 2.5f);
            Vector2D secondVector = new(1.5f, 2.6f);

            Assert.That(firstVector.Equals(secondVector), Is.False);
        }

        [Test]
        public static void GivenMatchingFloatValues_WhenCheckingEqualityWithXY_ThenReturnsTrue()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.Equals(1.5f, 2.5f));
        }

        [Test]
        public static void GivenNonMatchingValues_WhenCheckingEqualityWithXY_ThenReturnsFalse()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.Equals(1.5f, 9.9f), Is.False);
        }

        [Test]
        public static void GivenSameVectorBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.Equals((object)new Vector2D(1.5f, 2.5f)));
        }

        [Test]
        public static void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Vector2D vector = new(1.5f, 2.5f);

            Assert.That(vector.Equals((object)"Unrelated"), Is.False);
        }

        [Test]
        public static void GivenTwoVectorsWithSameValues_WhenGettingHashCode_ThenReturnSameHash()
        {
            Vector2D vector1 = new(1.5f, 2.5f);
            Vector2D vector2 = new(1.5f, 2.5f);

            Assert.That(vector1.GetHashCode(), Is.EqualTo(vector2.GetHashCode()));
        }

        [Test]
        public static void GivenTwoVectorsWithDifferentValues_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            Vector2D vector1 = new(1.5f, 2.5f);
            Vector2D vector2 = new(1.5f, 3.5f);

            Assert.That(vector1.GetHashCode(), Is.Not.EqualTo(vector2.GetHashCode()));
        }

        [Test]
        public static void GivenTwoVectors_WhenAdding_ThenReturnsCorrectSum()
        {
            Vector2D firstVector = new(1.0f, 2.0f);
            Vector2D secondVector = new(0.5f, 1.5f);

            Vector2D result = firstVector + secondVector;

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(3.5f));
        }

        [Test]
        public static void GivenTwoVectors_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Vector2D firstVector = new(5.0f, 8.0f);
            Vector2D secondVector = new(1.5f, 2.5f);

            Vector2D result = firstVector - secondVector;

            Assert.That(result.X, Is.EqualTo(3.5f));
            Assert.That(result.Y, Is.EqualTo(5.5f));
        }

        [Test]
        public static void GivenTwoVectors_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Vector2D firstVector = new(2.0f, 3.0f);
            Vector2D secondVector = new(4.0f, 5.0f);

            Vector2D result = firstVector * secondVector;

            Assert.That(result.X, Is.EqualTo(8.0f));
            Assert.That(result.Y, Is.EqualTo(15.0f));
        }

        [Test]
        public static void GivenTwoVectors_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Vector2D firstVector = new(10.0f, 20.0f);
            Vector2D secondVector = new(2.0f, 4.0f);

            Vector2D result = firstVector / secondVector;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(5.0f));
        }

        [Test]
        public static void GivenTwoEqualVectors_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Vector2D firstVector = new(1.5f, 2.5f);
            Vector2D secondVector = new(1.5f, 2.5f);

            Assert.That(firstVector == secondVector);
        }

        [Test]
        public static void GivenTwoDifferentVectors_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Vector2D firstVector = new(1.5f, 2.5f);
            Vector2D secondVector = new(1.5f, 2.6f);

            Assert.That(firstVector == secondVector, Is.False);
        }

        [Test]
        public static void GivenTwoDifferentVectors_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Vector2D firstVector = new(1.5f, 2.5f);
            Vector2D secondVector = new(1.5f, 2.6f);

            Assert.That(firstVector != secondVector);
        }

        [Test]
        public static void GivenTwoEqualVectors_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Vector2D firstVector = new(1.5f, 2.5f);
            Vector2D secondVector = new(1.5f, 2.5f);

            Assert.That(firstVector != secondVector, Is.False);
        }

        [Test]
        public static void GivenVector2D_WhenConvertingToXnaVector2_ThenValuesArePreserved()
        {
            Vector2D vector2D = new(1.5f, 2.5f);

            Vector2 xnaVector = vector2D;

            Assert.That(xnaVector.X, Is.EqualTo(1.5f));
            Assert.That(xnaVector.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public static void GivenXnaVector2_WhenConvertingToVector2D_ThenValuesArePreserved()
        {
            Vector2 xnaVector = new(1.5f, 2.5f);

            Vector2D vector2D = xnaVector;

            Assert.That(vector2D.X, Is.EqualTo(1.5f));
            Assert.That(vector2D.Y, Is.EqualTo(2.5f));
        }
    }
}
