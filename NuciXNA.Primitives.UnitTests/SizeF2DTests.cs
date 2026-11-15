using System;
using System.Drawing;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    [TestFixture]
    public sealed class SizeF2DTests
    {
        [Test]
        public static void GivenWidthAndHeight_WhenConstructing_ThenPropertiesAreSet()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Width, Is.EqualTo(3.5f));
            Assert.That(size.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public static void GivenSingleFloatValue_WhenConstructing_ThenBothDimensionsAreEqual()
        {
            SizeF2D size = new(5.0f);

            Assert.That(size.Width, Is.EqualTo(5.0f));
            Assert.That(size.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public static void GivenSingleIntValue_WhenConstructing_ThenBothDimensionsAreEqual()
        {
            SizeF2D size = new(5);

            Assert.That(size.Width, Is.EqualTo(5.0f));
            Assert.That(size.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public static void GivenPointF2D_WhenConstructing_ThenPropertiesMatchPointCoordinates()
        {
            PointF2D point = new(3.5f, 7.5f);
            SizeF2D size = new(point);

            Assert.That(size.Width, Is.EqualTo(3.5f));
            Assert.That(size.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public static void GivenZeroDimensions_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            SizeF2D size = new(0f, 0f);

            Assert.That(size.IsEmpty);
        }

        [Test]
        public static void GivenNonZeroDimensions_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            SizeF2D size = new(1.0f, 0f);

            Assert.That(size.IsEmpty, Is.False);
        }

        [Test]
        public static void GivenEmptyStatic_WhenCheckingDimensions_ThenBothAreZero()
        {
            SizeF2D empty = SizeF2D.Empty;

            Assert.That(empty.Width, Is.EqualTo(0f));
            Assert.That(empty.Height, Is.EqualTo(0f));
        }

        [Test]
        public static void GivenWidthAndHeight_WhenGettingArea_ThenReturnsCorrectValue()
        {
            SizeF2D size = new(4.0f, 5.0f);

            Assert.That(size.Area, Is.EqualTo(20.0).Within(0.001));
        }

        [Test]
        public static void GivenWidthAndHeight_WhenGettingPerimeter_ThenReturnsCorrectValue()
        {
            SizeF2D size = new(4.0f, 5.0f);

            Assert.That(size.Perimeter, Is.EqualTo(18.0).Within(0.001));
        }

        [Test]
        public static void GivenTwoSizesWithSameDimensions_WhenCheckingEquality_ThenReturnsTrue()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1.Equals(size2));
        }

        [Test]
        public static void GivenTwoSizesWithDifferentDimensions_WhenCheckingEquality_ThenReturnsFalse()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.6f);

            Assert.That(size1.Equals(size2), Is.False);
        }

        [Test]
        public static void GivenMatchingFloatDimensions_WhenCheckingEqualityWithWidthHeight_ThenReturnsTrue()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Equals(3.5f, 7.5f));
        }

        [Test]
        public static void GivenNonMatchingDimensions_WhenCallingEqualsWithWidthHeight_ThenReturnsFalse()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Equals(3.5f, 9.9f), Is.False);
        }

        [Test]
        public static void GivenSameSizeBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Equals((object)new SizeF2D(3.5f, 7.5f)));
        }

        [Test]
        public static void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            SizeF2D size = new(3.5f, 7.5f);

            Assert.That(size.Equals((object)"Unrelated"), Is.False);
        }

        [Test]
        public static void GivenTwoSizesWithSameDimensions_WhenGettingHashCode_ThenReturnSameHash()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1.GetHashCode(), Is.EqualTo(size2.GetHashCode()));
        }

        [Test]
        public static void GivenTwoSizesWithDifferentDimensions_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 8.5f);

            Assert.That(size1.GetHashCode(), Is.Not.EqualTo(size2.GetHashCode()));
        }

        [Test]
        public static void GivenTwoSizes_WhenAdding_ThenReturnsCorrectSum()
        {
            SizeF2D size1 = new(3.0f, 5.0f);
            SizeF2D size2 = new(1.5f, 2.5f);

            SizeF2D result = size1 + size2;

            Assert.That(result.Width, Is.EqualTo(4.5f));
            Assert.That(result.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public static void GivenTwoSizes_WhenSubtracting_ThenReturnsCorrectDifference()
        {
            SizeF2D size1 = new(10.0f, 20.0f);
            SizeF2D size2 = new(3.5f, 7.5f);

            SizeF2D result = size1 - size2;

            Assert.That(result.Width, Is.EqualTo(6.5f));
            Assert.That(result.Height, Is.EqualTo(12.5f));
        }

        [Test]
        public static void GivenTwoSizes_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            SizeF2D size1 = new(2.0f, 3.0f);
            SizeF2D size2 = new(4.0f, 5.0f);

            SizeF2D result = size1 * size2;

            Assert.That(result.Width, Is.EqualTo(8.0f));
            Assert.That(result.Height, Is.EqualTo(15.0f));
        }

        [Test]
        public static void GivenTwoSizes_WhenDividing_ThenReturnsCorrectQuotient()
        {
            SizeF2D size1 = new(10.0f, 20.0f);
            SizeF2D size2 = new(2.0f, 4.0f);

            SizeF2D result = size1 / size2;

            Assert.That(result.Width, Is.EqualTo(5.0f));
            Assert.That(result.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public static void GivenSizeAndFloatScalar_WhenMultiplying_ThenReturnsCorrectProduct()
        {
            SizeF2D size = new(2.0f, 4.0f);

            SizeF2D result = size * 2.5f;

            Assert.That(result.Width, Is.EqualTo(5.0f));
            Assert.That(result.Height, Is.EqualTo(10.0f));
        }

        [Test]
        public static void GivenSizeAndFloatScalar_WhenDividing_ThenReturnsCorrectQuotient()
        {
            SizeF2D size = new(10.0f, 20.0f);

            SizeF2D result = size / 4.0f;

            Assert.That(result.Width, Is.EqualTo(2.5f));
            Assert.That(result.Height, Is.EqualTo(5.0f));
        }

        [Test]
        public static void GivenTwoEqualSizes_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1 == size2);
        }

        [Test]
        public static void GivenTwoDifferentSizes_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.6f);

            Assert.That(size1 == size2, Is.False);
        }

        [Test]
        public static void GivenTwoDifferentSizes_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.6f);

            Assert.That(size1 != size2);
        }

        [Test]
        public static void GivenTwoEqualSizes_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            SizeF2D size1 = new(3.5f, 7.5f);
            SizeF2D size2 = new(3.5f, 7.5f);

            Assert.That(size1 != size2, Is.False);
        }

        [Test]
        public static void GivenSizeF2D_WhenConvertingToSystemSizeF_ThenDimensionsArePreserved()
        {
            SizeF2D sizeF2D = new(3.5f, 7.5f);

            SizeF systemSizeF = sizeF2D;

            Assert.That(systemSizeF.Width, Is.EqualTo(3.5f));
            Assert.That(systemSizeF.Height, Is.EqualTo(7.5f));
        }

        [Test]
        public static void GivenSystemSizeF_WhenConvertingToSizeF2D_ThenDimensionsArePreserved()
        {
            SizeF systemSizeF = new(3.5f, 7.5f);

            SizeF2D sizeF2D = systemSizeF;

            Assert.That(sizeF2D.Width, Is.EqualTo(3.5f));
            Assert.That(sizeF2D.Height, Is.EqualTo(7.5f));
        }
    }
}
