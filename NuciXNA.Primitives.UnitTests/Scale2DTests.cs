using System;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Scale2DTests
    {
        [Test]
        public void GivenHorizontalAndVertical_WhenConstructing_ThenPropertiesAreSet()
        {
            Scale2D scale = new(2.0f, 3.0f);

            Assert.That(scale.Horizontal, Is.EqualTo(2.0f));
            Assert.That(scale.Vertical, Is.EqualTo(3.0f));
        }

        [Test]
        public void GivenSingleValue_WhenConstructing_ThenBothDimensionsAreEqual()
        {
            Scale2D scale = new(2.5f);

            Assert.That(scale.Horizontal, Is.EqualTo(2.5f));
            Assert.That(scale.Vertical, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenPoint2D_WhenConstructing_ThenPropertiesMatchPointCoordinates()
        {
            Point2D point = new(3, 7);
            Scale2D scale = new(point);

            Assert.That(scale.Horizontal, Is.EqualTo(3f));
            Assert.That(scale.Vertical, Is.EqualTo(7f));
        }

        [Test]
        public void GivenSize2D_WhenConstructing_ThenPropertiesMatchSizeDimensions()
        {
            Size2D size = new(4, 8);
            Scale2D scale = new(size);

            Assert.That(scale.Horizontal, Is.EqualTo(4f));
            Assert.That(scale.Vertical, Is.EqualTo(8f));
        }

        [Test]
        public void GivenZeroValues_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Scale2D scale = new(0f, 0f);

            Assert.That(scale.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroValues_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Scale2D scale = new(1.0f, 0f);

            Assert.That(scale.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingValues_ThenBothAreZero()
        {
            Scale2D empty = Scale2D.Empty;

            Assert.That(empty.Horizontal, Is.EqualTo(0f));
            Assert.That(empty.Vertical, Is.EqualTo(0f));
        }

        [Test]
        public void GivenZeroStatic_WhenCheckingValues_ThenBothAreZero()
        {
            Scale2D zero = Scale2D.Zero;

            Assert.That(zero.Horizontal, Is.EqualTo(0f));
            Assert.That(zero.Vertical, Is.EqualTo(0f));
        }

        [Test]
        public void GivenOneStatic_WhenCheckingValues_ThenBothAreOne()
        {
            Scale2D one = Scale2D.One;

            Assert.That(one.Horizontal, Is.EqualTo(1f));
            Assert.That(one.Vertical, Is.EqualTo(1f));
        }

        [Test]
        public void GivenTwoScalesWithSameValues_WhenCheckingEquality_ThenReturnsTrue()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 3.0f);

            Assert.That(scale1.Equals(scale2), Is.True);
        }

        [Test]
        public void GivenTwoScalesWithDifferentValues_WhenCheckingEquality_ThenReturnsFalse()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 4.0f);

            Assert.That(scale1.Equals(scale2), Is.False);
        }

        [Test]
        public void GivenMatchingFloatValues_WhenCheckingEqualityWithHorizontalVertical_ThenReturnsTrue()
        {
            Scale2D scale = new(2.0f, 3.0f);

            Assert.That(scale.Equals(2.0f, 3.0f), Is.True);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Scale2D scale = new(2.0f, 3.0f);

            Assert.That(scale.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoScales_WhenAdding_ThenReturnsCorrectSum()
        {
            Scale2D scale1 = new(1.0f, 2.0f);
            Scale2D scale2 = new(0.5f, 1.5f);

            Scale2D result = scale1 + scale2;

            Assert.That(result.Horizontal, Is.EqualTo(1.5f));
            Assert.That(result.Vertical, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenTwoScales_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Scale2D scale1 = new(3.0f, 5.0f);
            Scale2D scale2 = new(1.0f, 2.0f);

            Scale2D result = scale1 - scale2;

            Assert.That(result.Horizontal, Is.EqualTo(2.0f));
            Assert.That(result.Vertical, Is.EqualTo(3.0f));
        }

        [Test]
        public void GivenTwoScales_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(4.0f, 5.0f);

            Scale2D result = scale1 * scale2;

            Assert.That(result.Horizontal, Is.EqualTo(8.0f));
            Assert.That(result.Vertical, Is.EqualTo(15.0f));
        }

        [Test]
        public void GivenTwoScales_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Scale2D scale1 = new(10.0f, 20.0f);
            Scale2D scale2 = new(2.0f, 4.0f);

            Scale2D result = scale1 / scale2;

            Assert.That(result.Horizontal, Is.EqualTo(5.0f));
            Assert.That(result.Vertical, Is.EqualTo(5.0f));
        }

        [Test]
        public void GivenScaleAndIntScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Scale2D scale = new(2.0f, 3.0f);

            Scale2D result = scale * 3;

            Assert.That(result.Horizontal, Is.EqualTo(6.0f));
            Assert.That(result.Vertical, Is.EqualTo(9.0f));
        }

        [Test]
        public void GivenScaleAndIntScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Scale2D scale = new(6.0f, 9.0f);

            Scale2D result = scale / 3;

            Assert.That(result.Horizontal, Is.EqualTo(2.0f));
            Assert.That(result.Vertical, Is.EqualTo(3.0f));
        }

        [Test]
        public void GivenScaleAndFloatScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Scale2D scale = new(2.0f, 4.0f);

            Scale2D result = scale * 2.5f;

            Assert.That(result.Horizontal, Is.EqualTo(5.0f));
            Assert.That(result.Vertical, Is.EqualTo(10.0f));
        }

        [Test]
        public void GivenScaleAndFloatScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Scale2D scale = new(6.0f, 9.0f);

            Scale2D result = scale / 3.0f;

            Assert.That(result.Horizontal, Is.EqualTo(2.0f));
            Assert.That(result.Vertical, Is.EqualTo(3.0f));
        }

        [Test]
        public void GivenTwoEqualScales_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 3.0f);

            Assert.That(scale1 == scale2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentScales_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 4.0f);

            Assert.That(scale1 == scale2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentScales_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 4.0f);

            Assert.That(scale1 != scale2, Is.True);
        }

        [Test]
        public void GivenTwoEqualScales_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 3.0f);

            Assert.That(scale1 != scale2, Is.False);
        }

        [Test]
        public void GivenNonMatchingValues_WhenCallingEqualsWithHorizontalVertical_ThenReturnsFalse()
        {
            Scale2D scale = new(2.0f, 3.0f);

            Assert.That(scale.Equals(2.0f, 9.9f), Is.False);
        }

        [Test]
        public void GivenSameScaleBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            Scale2D scale = new(2.0f, 3.0f);

            Assert.That(scale.Equals((object)new Scale2D(2.0f, 3.0f)), Is.True);
        }

        [Test]
        public void GivenTwoScalesWithSameValues_WhenGettingHashCode_ThenReturnSameHash()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 3.0f);

            Assert.That(scale1.GetHashCode(), Is.EqualTo(scale2.GetHashCode()));
        }

        [Test]
        public void GivenTwoScalesWithDifferentValues_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            Scale2D scale1 = new(2.0f, 3.0f);
            Scale2D scale2 = new(2.0f, 4.0f);

            Assert.That(scale1.GetHashCode(), Is.Not.EqualTo(scale2.GetHashCode()));
        }
    }
}
