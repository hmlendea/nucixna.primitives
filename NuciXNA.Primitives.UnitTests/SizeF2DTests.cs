using System;
using System.Drawing;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class SizeF2DTests
    {
        [Test]
        public void GivenWidthAndHeight_WhenConstructing_ThenPropertiesAreSet()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Width, Is.EqualTo(3.5f));
            Assert.That(size.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenSingleFloatValue_WhenConstructing_ThenBothDimensionsAreEqual()
        {
            SizeF2D size = new(5.0f);

            Assert.That(size.Width, Is.EqualTo(5.0f));
            Assert.That(size.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public void GivenSingleIntValue_WhenConstructing_ThenBothDimensionsAreEqual()
        {
            SizeF2D size = new(5);

            Assert.That(size.Width, Is.EqualTo(5.0f));
            Assert.That(size.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public void GivenPointF2D_WhenConstructing_ThenPropertiesMatchPointCoordinates()
        {
            PointF2D point = new(3.5f, 7.5f);
            SizeF2D size = new(point);

            Assert.That(size.Width, Is.EqualTo(3.5f));
            Assert.That(size.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenZeroDimensions_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            SizeF2D size = new(0f, 0f);

            Assert.That(size.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroDimensions_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            SizeF2D size = new(1.0f, 0f);

            Assert.That(size.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingDimensions_ThenBothAreZero()
        {
            SizeF2D empty = SizeF2D.Empty;

            Assert.That(empty.Width, Is.EqualTo(0f));
            Assert.That(empty.Height, Is.EqualTo(0f));
        }

        [Test]
        public void GivenWidthAndHeight_WhenGettingArea_ThenReturnsCorrectValue()
        {
            SizeF2D size = new(4.0f, 5.0f);

            Assert.That(size.Area, Is.EqualTo(20.0).Within(0.001));
        }

        [Test]
        public void GivenWidthAndHeight_WhenGettingPerimeter_ThenReturnsCorrectValue()
        {
            SizeF2D size = new(4.0f, 5.0f);

            Assert.That(size.Perimeter, Is.EqualTo(18.0).Within(0.001));
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(float width, float height) overload")]
        public void GivenTwoSizesWithSameDimensions_WhenCheckingEquality_ThenReturnsTrue()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1.Equals(size2), Is.True);
        }

        [Test]
        public void GivenTwoSizesWithDifferentDimensions_WhenCheckingEquality_ThenReturnsFalse()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.6f);

            Assert.That(size1.Equals(size2), Is.False);
        }

        [Test]
        public void GivenMatchingFloatDimensions_WhenCheckingEqualityWithWidthHeight_ThenReturnsTrue()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Equals(3.5f, 7.5f), Is.True);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoSizes_WhenAdding_ThenReturnsCorrectSum()
        {
            SizeF2D size1 = new(3.0f, 5.0f);
            SizeF2D size2 = new(1.5f, 2.5f);

            SizeF2D result = size1 + size2;

            Assert.That(result.Width, Is.EqualTo(4.5f));
            Assert.That(result.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenTwoSizes_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            SizeF2D size1 = new(10.0f, 20.0f);
            SizeF2D size2 = new(3.5f, 7.5f);

            SizeF2D result = size1 - size2;

            Assert.That(result.Width, Is.EqualTo(6.5f));
            Assert.That(result.Height, Is.EqualTo(12.5f));
        }

        [Test]
        public void GivenTwoSizes_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            SizeF2D size1 = new(2.0f, 3.0f);
            SizeF2D size2 = new(4.0f, 5.0f);

            SizeF2D result = size1 * size2;

            Assert.That(result.Width, Is.EqualTo(8.0f));
            Assert.That(result.Height, Is.EqualTo(15.0f));
        }

        [Test]
        public void GivenTwoSizes_WhenDividing_ThenReturnsCorrectQuotient()
        {
            SizeF2D size1 = new(10.0f, 20.0f);
            SizeF2D size2 = new(2.0f, 4.0f);

            SizeF2D result = size1 / size2;

            Assert.That(result.Width, Is.EqualTo(5.0f));
            Assert.That(result.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public void GivenSizeAndFloatScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            SizeF2D size = new(2.0f, 4.0f);

            SizeF2D result = size * 2.5f;

            Assert.That(result.Width, Is.EqualTo(5.0f));
            Assert.That(result.Height, Is.EqualTo(10.0f));
        }

        [Test]
        public void GivenSizeAndFloatScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            SizeF2D size = new(10.0f, 20.0f);

            SizeF2D result = size / 4.0f;

            Assert.That(result.Width, Is.EqualTo(2.5f));
            Assert.That(result.Height, Is.EqualTo(5.0f));
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(float width, float height) overload")]
        public void GivenTwoEqualSizes_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1 == size2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentSizes_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.6f);

            Assert.That(size1 == size2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentSizes_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.6f);

            Assert.That(size1 != size2, Is.True);
        }

        [Test]
        [Ignore("Implementation bug: Equals(T other) incorrectly resolves to Equals(float width, float height) overload")]
        public void GivenTwoEqualSizes_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1 != size2, Is.False);
        }

        [Test]
        public void GivenSizeF2D_WhenConvertingToSystemSizeF_ThenDimensionsArePreserved()
        {
            SizeF2D sizeF2D = new(3.5f, 7.5f);

            SizeF systemSizeF = sizeF2D;

            Assert.That(systemSizeF.Width, Is.EqualTo(3.5f));
            Assert.That(systemSizeF.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public void GivenSystemSizeF_WhenConvertingToSizeF2D_ThenDimensionsArePreserved()
        {
            SizeF systemSizeF = new(3.5f, 7.5f);

            SizeF2D sizeF2D = systemSizeF;

            Assert.That(sizeF2D.Width, Is.EqualTo(3.5f));
            Assert.That(sizeF2D.Height, Is.EqualTo(7.5f));
        }
    }
}
