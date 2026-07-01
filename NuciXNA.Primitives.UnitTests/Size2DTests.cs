using System;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Size2DTests
    {
        [Test]
        public void GivenWidthAndHeight_WhenConstructing_ThenPropertiesAreSet()
        {
            Size2D size = new(10, 20);

            Assert.That(size.Width, Is.EqualTo(10));
            Assert.That(size.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenSingleValue_WhenConstructing_ThenBothDimensionsAreEqual()
        {
            Size2D size = new(7);

            Assert.That(size.Width, Is.EqualTo(7));
            Assert.That(size.Height, Is.EqualTo(7));
        }

        [Test]
        public void GivenPoint2D_WhenConstructing_ThenDimensionsMatchPointCoordinates()
        {
            Point2D point = new(5, 9);
            Size2D size = new(point);

            Assert.That(size.Width, Is.EqualTo(5));
            Assert.That(size.Height, Is.EqualTo(9));
        }

        [Test]
        public void GivenZeroDimensions_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Size2D size = new(0, 0);

            Assert.That(size.IsEmpty);
        }

        [Test]
        public void GivenNonZeroDimensions_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Size2D size = new(1, 0);

            Assert.That(size.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingDimensions_ThenBothAreZero()
        {
            Size2D empty = Size2D.Empty;

            Assert.That(empty.Width, Is.EqualTo(0));
            Assert.That(empty.Height, Is.EqualTo(0));
        }

        [Test]
        public void GivenWidthAndHeight_WhenGettingArea_ThenReturnsCorrectValue()
        {
            Size2D size = new(4, 5);

            Assert.That(size.Area, Is.EqualTo(20));
        }

        [Test]
        public void GivenWidthAndHeight_WhenGettingPerimeter_ThenReturnsCorrectValue()
        {
            Size2D size = new(4, 5);

            Assert.That(size.Perimeter, Is.EqualTo(18));
        }

        [Test]
        public void GivenTwoSizesWithSameDimensions_WhenCheckingEquality_ThenReturnsTrue()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 20);

            Assert.That(size1.Equals(size2));
        }

        [Test]
        public void GivenTwoSizesWithDifferentDimensions_WhenCheckingEquality_ThenReturnsFalse()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 21);

            Assert.That(size1.Equals(size2), Is.False);
        }

        [Test]
        public void GivenMatchingIntDimensions_WhenCheckingEqualityWithWidthHeight_ThenReturnsTrue()
        {
            Size2D size = new(10, 20);

            Assert.That(size.Equals(10, 20));
        }

        [Test]
        public void GivenNonMatchingDimensions_WhenCallingEqualsWithWidthHeight_ThenReturnsFalse()
        {
            Size2D size = new(10, 20);

            Assert.That(size.Equals(10, 99), Is.False);
        }

        [Test]
        public void GivenSameSizeBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            Size2D size = new(10, 20);

            Assert.That(size.Equals((object)new Size2D(10, 20)));
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Size2D size = new(10, 20);

            Assert.That(size.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoSizesWithSameDimensions_WhenGettingHashCode_ThenReturnSameHash()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 20);

            Assert.That(size1.GetHashCode(), Is.EqualTo(size2.GetHashCode()));
        }

        [Test]
        public void GivenTwoSizesWithDifferentDimensions_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 21);

            Assert.That(size1.GetHashCode(), Is.Not.EqualTo(size2.GetHashCode()));
        }

        [Test]
        public void GivenTwoSizes_WhenAdding_ThenReturnsCorrectSum()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(3, 7);

            Size2D result = size1 + size2;

            Assert.That(result.Width, Is.EqualTo(13));
            Assert.That(result.Height, Is.EqualTo(27));
        }

        [Test]
        public void GivenTwoSizes_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(3, 7);

            Size2D result = size1 - size2;

            Assert.That(result.Width, Is.EqualTo(7));
            Assert.That(result.Height, Is.EqualTo(13));
        }

        [Test]
        public void GivenTwoSizes_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Size2D size1 = new(4, 5);
            Size2D size2 = new(3, 6);

            Size2D result = size1 * size2;

            Assert.That(result.Width, Is.EqualTo(12));
            Assert.That(result.Height, Is.EqualTo(30));
        }

        [Test]
        public void GivenTwoSizes_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Size2D size1 = new(20, 30);
            Size2D size2 = new(4, 5);

            Size2D result = size1 / size2;

            Assert.That(result.Width, Is.EqualTo(5));
            Assert.That(result.Height, Is.EqualTo(6));
        }

        [Test]
        public void GivenSizeAndIntScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            Size2D size = new(5, 10);

            Size2D result = size * 3;

            Assert.That(result.Width, Is.EqualTo(15));
            Assert.That(result.Height, Is.EqualTo(30));
        }

        [Test]
        public void GivenSizeAndIntScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Size2D size = new(20, 30);

            Size2D result = size / 5;

            Assert.That(result.Width, Is.EqualTo(4));
            Assert.That(result.Height, Is.EqualTo(6));
        }

        [Test]
        [TestCase(10, 10, 2, 2, 20, 20)]
        [TestCase(10, 10, 2.5f, 2.5f, 25, 25)]
        [TestCase(10, 10, 2.51f, 2.51f, 25, 25)]
        [TestCase(10, 20, 2.53f, 5.68f, 25, 113)]
        public void GivenSize2D_WhenMultiplyingByScale2d_ThenTheCorrectValueIsReturned(
            int width, int height,
            float horizontalScale, float verticalScale,
            int expectedWidth, int expectedHeight)
        {
            Size2D size = new(width, height);
            Scale2D scale = new(horizontalScale, verticalScale);

            Size2D expectedSize = size * scale;

            Assert.That(expectedSize.Width, Is.EqualTo(expectedWidth));
            Assert.That(expectedSize.Height, Is.EqualTo(expectedHeight));
        }

        [Test]
        public void GivenSizeAndScale2D_WhenDividing_ThenReturnsCorrectQuotient()
        {
            Size2D size = new(20, 30);
            Scale2D scale = new(4.0f, 5.0f);

            Size2D result = size / scale;

            Assert.That(result.Width, Is.EqualTo(5));
            Assert.That(result.Height, Is.EqualTo(6));
        }

        [Test]
        public void GivenTwoEqualSizes_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 20);

            Assert.That(size1 == size2);
        }

        [Test]
        public void GivenTwoDifferentSizes_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 21);

            Assert.That(size1 == size2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentSizes_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 21);

            Assert.That(size1 != size2);
        }

        [Test]
        public void GivenTwoEqualSizes_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Size2D size1 = new(10, 20);
            Size2D size2 = new(10, 20);

            Assert.That(size1 != size2, Is.False);
        }

        [Test]
        public void GivenSize2D_WhenConvertingToSystemSize_ThenDimensionsArePreserved()
        {
            Size2D size2D = new(12, 34);

            System.Drawing.Size systemSize = size2D;

            Assert.That(systemSize.Width, Is.EqualTo(12));
            Assert.That(systemSize.Height, Is.EqualTo(34));
        }

        [Test]
        public void GivenSystemSize_WhenConvertingToSize2D_ThenDimensionsArePreserved()
        {
            System.Drawing.Size systemSize = new(12, 34);

            Size2D size2D = systemSize;

            Assert.That(size2D.Width, Is.EqualTo(12));
            Assert.That(size2D.Height, Is.EqualTo(34));
        }

        [Test]
        public void GivenSize2D_WhenConvertingToSizeF2D_ThenDimensionsArePreserved()
        {
            Size2D size2D = new(12, 34);

            SizeF2D sizeF2D = size2D;

            Assert.That(sizeF2D.Width, Is.EqualTo(12f));
            Assert.That(sizeF2D.Height, Is.EqualTo(34f));
        }
    }
}
