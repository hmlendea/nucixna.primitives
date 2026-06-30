using System;

using Microsoft.Xna.Framework;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Vector3DTests
    {
        [Test]
        public void GivenXYZValues_WhenConstructing_ThenPropertiesAreSet()
        {
            Vector3D vector = new(1.5f, 2.5f, 3.5f);

            Assert.That(vector.X, Is.EqualTo(1.5f));
            Assert.That(vector.Y, Is.EqualTo(2.5f));
            Assert.That(vector.Z, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenZeroValues_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Vector3D vector = new(0f, 0f, 0f);

            Assert.That(vector.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroXValue_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Vector3D vector = new(1.0f, 0f, 0f);

            Assert.That(vector.IsEmpty, Is.False);
        }

        [Test]
        public void GivenZeroStatic_WhenCheckingValues_ThenAllAreZero()
        {
            Vector3D zero = Vector3D.Zero;

            Assert.That(zero.X, Is.EqualTo(0f));
            Assert.That(zero.Y, Is.EqualTo(0f));
            Assert.That(zero.Z, Is.EqualTo(0f));
        }

        [Test]
        public void GivenOneStatic_WhenCheckingValues_ThenAllAreOne()
        {
            Vector3D one = Vector3D.One;

            Assert.That(one.X, Is.EqualTo(1f));
            Assert.That(one.Y, Is.EqualTo(1f));
            Assert.That(one.Z, Is.EqualTo(1f));
        }

        [Test]
        public void GivenTwoVectorsWithSameValues_WhenCheckingEquality_ThenReturnsTrue()
        {
            Vector3D v1 = new(1.5f, 2.5f, 3.5f);
            Vector3D v2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(v1.Equals(v2), Is.True);
        }

        [Test]
        public void GivenTwoVectorsWithDifferentZValue_WhenCheckingEquality_ThenReturnsFalse()
        {
            Vector3D v1 = new(1.5f, 2.5f, 3.5f);
            Vector3D v2 = new(1.5f, 2.5f, 3.6f);

            Assert.That(v1.Equals(v2), Is.False);
        }

        [Test]
        public void GivenMatchingFloatValues_WhenCheckingEqualityWithXYZ_ThenReturnsTrue()
        {
            Vector3D vector = new(1.5f, 2.5f, 3.5f);

            Assert.That(vector.Equals(1.5f, 2.5f, 3.5f), Is.True);
        }

        [Test]
        public void GivenNonMatchingFloatValues_WhenCheckingEqualityWithXYZ_ThenReturnsFalse()
        {
            Vector3D vector = new(1.5f, 2.5f, 3.5f);

            Assert.That(vector.Equals(1.5f, 2.5f, 3.6f), Is.False);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Vector3D vector = new(1.5f, 2.5f, 3.5f);

            Assert.That(vector.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoVectors_WhenAdding_ThenReturnsCorrectSum()
        {
            Vector3D v1 = new(1.0f, 2.0f, 3.0f);
            Vector3D v2 = new(0.5f, 1.5f, 2.5f);

            Vector3D result = v1 + v2;

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(3.5f));
            Assert.That(result.Z, Is.EqualTo(5.5f));
        }

        [Test]
        public void GivenTwoVectors_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Vector3D v1 = new(5.0f, 8.0f, 11.0f);
            Vector3D v2 = new(1.5f, 2.5f, 3.5f);

            Vector3D result = v1 - v2;

            Assert.That(result.X, Is.EqualTo(3.5f));
            Assert.That(result.Y, Is.EqualTo(5.5f));
            Assert.That(result.Z, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenTwoVectors_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Vector3D v1 = new(2.0f, 3.0f, 4.0f);
            Vector3D v2 = new(5.0f, 6.0f, 7.0f);

            Vector3D result = v1 * v2;

            Assert.That(result.X, Is.EqualTo(10.0f));
            Assert.That(result.Y, Is.EqualTo(18.0f));
            Assert.That(result.Z, Is.EqualTo(28.0f));
        }

        [Test]
        public void GivenTwoVectors_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Vector3D v1 = new(10.0f, 20.0f, 30.0f);
            Vector3D v2 = new(2.0f, 4.0f, 5.0f);

            Vector3D result = v1 / v2;

            Assert.That(result.X, Is.EqualTo(5.0f));
            Assert.That(result.Y, Is.EqualTo(5.0f));
            Assert.That(result.Z, Is.EqualTo(6.0f));
        }

        [Test]
        public void GivenTwoEqualVectors_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Vector3D v1 = new(1.5f, 2.5f, 3.5f);
            Vector3D v2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(v1 == v2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentVectors_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Vector3D v1 = new(1.5f, 2.5f, 3.5f);
            Vector3D v2 = new(1.5f, 2.5f, 3.6f);

            Assert.That(v1 == v2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentVectors_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Vector3D v1 = new(1.5f, 2.5f, 3.5f);
            Vector3D v2 = new(1.5f, 2.5f, 3.6f);

            Assert.That(v1 != v2, Is.True);
        }

        [Test]
        public void GivenTwoEqualVectors_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Vector3D v1 = new(1.5f, 2.5f, 3.5f);
            Vector3D v2 = new(1.5f, 2.5f, 3.5f);

            Assert.That(v1 != v2, Is.False);
        }

        [Test]
        public void GivenVector3D_WhenConvertingToXnaVector3_ThenValuesArePreserved()
        {
            Vector3D vector3D = new(1.5f, 2.5f, 3.5f);

            Vector3 xnaVector = vector3D;

            Assert.That(xnaVector.X, Is.EqualTo(1.5f));
            Assert.That(xnaVector.Y, Is.EqualTo(2.5f));
            Assert.That(xnaVector.Z, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenXnaVector3_WhenConvertingToVector3D_ThenValuesArePreserved()
        {
            Vector3 xnaVector = new(1.5f, 2.5f, 3.5f);

            Vector3D vector3D = xnaVector;

            Assert.That(vector3D.X, Is.EqualTo(1.5f));
            Assert.That(vector3D.Y, Is.EqualTo(2.5f));
            Assert.That(vector3D.Z, Is.EqualTo(3.5f));
        }
    }
}
