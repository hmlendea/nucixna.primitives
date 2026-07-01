using System;
using System.Drawing;

using Microsoft.Xna.Framework;

using NUnit.Framework;

using SystemRectangle = System.Drawing.Rectangle;
using XnaRectangle = Microsoft.Xna.Framework.Rectangle;

namespace NuciXNA.Primitives.UnitTests
{
    public class Rectangle2DTests
    {
        [Test]
        public void GivenXYWidthHeight_WhenConstructing_ThenPropertiesAreSet()
        {
            Rectangle2D rect = new(1, 2, 10, 20);

            Assert.That(rect.X, Is.EqualTo(1));
            Assert.That(rect.Y, Is.EqualTo(2));
            Assert.That(rect.Width, Is.EqualTo(10));
            Assert.That(rect.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenPoint2DAndSize2D_WhenConstructing_ThenPropertiesAreSet()
        {
            Point2D location = new(3, 5);
            Size2D size = new(12, 24);
            Rectangle2D rect = new(location, size);

            Assert.That(rect.X, Is.EqualTo(3));
            Assert.That(rect.Y, Is.EqualTo(5));
            Assert.That(rect.Width, Is.EqualTo(12));
            Assert.That(rect.Height, Is.EqualTo(24));
        }

        [Test]
        public void GivenStartAndEndPoints_WhenConstructing_ThenSizeIsComputedFromDifference()
        {
            Point2D start = new(2, 4);
            Point2D end = new(10, 16);
            Rectangle2D rect = new(start, end);

            Assert.That(rect.X, Is.EqualTo(2));
            Assert.That(rect.Y, Is.EqualTo(4));
            Assert.That(rect.Width, Is.EqualTo(8));
            Assert.That(rect.Height, Is.EqualTo(12));
        }

        [Test]
        public void GivenSize2D_WhenConstructing_ThenLocationIsAtOrigin()
        {
            Size2D size = new(10, 20);
            Rectangle2D rect = new(size);

            Assert.That(rect.X, Is.EqualTo(0));
            Assert.That(rect.Y, Is.EqualTo(0));
            Assert.That(rect.Width, Is.EqualTo(10));
            Assert.That(rect.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenPoint2DAndWidthHeight_WhenConstructing_ThenPropertiesAreSet()
        {
            Point2D point = new(1, 2);
            Rectangle2D rect = new(point, 10, 20);

            Assert.That(rect.X, Is.EqualTo(1));
            Assert.That(rect.Y, Is.EqualTo(2));
            Assert.That(rect.Width, Is.EqualTo(10));
            Assert.That(rect.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenXYAndSize2D_WhenConstructing_ThenPropertiesAreSet()
        {
            Size2D size = new(10, 20);
            Rectangle2D rect = new(1, 2, size);

            Assert.That(rect.X, Is.EqualTo(1));
            Assert.That(rect.Y, Is.EqualTo(2));
            Assert.That(rect.Width, Is.EqualTo(10));
            Assert.That(rect.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenAllZeroValues_WhenCheckingIsEmpty_ThenReturnsTrue()
        {
            Rectangle2D rect = new(0, 0, 0, 0);

            Assert.That(rect.IsEmpty, Is.True);
        }

        [Test]
        public void GivenNonZeroWidth_WhenCheckingIsEmpty_ThenReturnsFalse()
        {
            Rectangle2D rect = new(0, 0, 1, 0);

            Assert.That(rect.IsEmpty, Is.False);
        }

        [Test]
        public void GivenEmptyStatic_WhenCheckingValues_ThenAllAreZero()
        {
            Rectangle2D empty = Rectangle2D.Empty;

            Assert.That(empty.X, Is.EqualTo(0));
            Assert.That(empty.Y, Is.EqualTo(0));
            Assert.That(empty.Width, Is.EqualTo(0));
            Assert.That(empty.Height, Is.EqualTo(0));
        }

        [Test]
        public void GivenRectangle_WhenGettingLeft_ThenReturnsX()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.Left, Is.EqualTo(5));
        }

        [Test]
        public void GivenRectangle_WhenGettingTop_ThenReturnsY()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.Top, Is.EqualTo(10));
        }

        [Test]
        public void GivenRectangle_WhenGettingRight_ThenReturnsXPlusWidth()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.Right, Is.EqualTo(25));
        }

        [Test]
        public void GivenRectangle_WhenGettingBottom_ThenReturnsYPlusHeight()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.Bottom, Is.EqualTo(40));
        }

        [Test]
        public void GivenRectangle_WhenGettingCentre_ThenReturnsMidpoint()
        {
            Rectangle2D rect = new(0, 0, 10, 20);

            Assert.That(rect.Centre.X, Is.EqualTo(5));
            Assert.That(rect.Centre.Y, Is.EqualTo(10));
        }

        [Test]
        public void GivenRectangle_WhenGettingTopLeft_ThenReturnsXAndY()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.TopLeft.X, Is.EqualTo(5));
            Assert.That(rect.TopLeft.Y, Is.EqualTo(10));
        }

        [Test]
        public void GivenRectangle_WhenGettingTopRight_ThenReturnsRightAndTop()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.TopRight.X, Is.EqualTo(25));
            Assert.That(rect.TopRight.Y, Is.EqualTo(10));
        }

        [Test]
        public void GivenRectangle_WhenGettingBottomLeft_ThenReturnsLeftAndBottom()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.BottomLeft.X, Is.EqualTo(5));
            Assert.That(rect.BottomLeft.Y, Is.EqualTo(40));
        }

        [Test]
        public void GivenRectangle_WhenGettingBottomRight_ThenReturnsRightAndBottom()
        {
            Rectangle2D rect = new(5, 10, 20, 30);

            Assert.That(rect.BottomRight.X, Is.EqualTo(25));
            Assert.That(rect.BottomRight.Y, Is.EqualTo(40));
        }

        [Test]
        public void GivenRectangle_WhenGettingLocation_ThenReturnsXYAsPoint()
        {
            Rectangle2D rect = new(3, 7, 10, 20);

            Assert.That(rect.Location.X, Is.EqualTo(3));
            Assert.That(rect.Location.Y, Is.EqualTo(7));
        }

        [Test]
        public void GivenRectangle_WhenGettingSize_ThenReturnsWidthHeightAsSize()
        {
            Rectangle2D rect = new(3, 7, 10, 20);

            Assert.That(rect.Size.Width, Is.EqualTo(10));
            Assert.That(rect.Size.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenNewLocation_WhenSettingLocation_ThenXAndYAreUpdated()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            rect.Location = new Point2D(5, 6);

            Assert.That(rect.X, Is.EqualTo(5));
            Assert.That(rect.Y, Is.EqualTo(6));
        }

        [Test]
        public void GivenNewSize_WhenSettingSize_ThenWidthAndHeightAreUpdated()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            rect.Size = new Size2D(50, 60);

            Assert.That(rect.Width, Is.EqualTo(50));
            Assert.That(rect.Height, Is.EqualTo(60));
        }

        [Test]
        public void GivenPointInsideRectangle_WhenCallingContainsWithXY_ThenReturnsTrue()
        {
            Rectangle2D rect = new(0, 0, 10, 10);

            Assert.That(rect.Contains(5, 5), Is.True);
        }

        [Test]
        public void GivenPointOutsideRectangle_WhenCallingContainsWithXY_ThenReturnsFalse()
        {
            Rectangle2D rect = new(0, 0, 10, 10);

            Assert.That(rect.Contains(15, 5), Is.False);
        }

        [Test]
        public void GivenPointOnEdge_WhenCallingContainsWithXY_ThenReturnsTrue()
        {
            Rectangle2D rect = new(0, 0, 10, 10);

            Assert.That(rect.Contains(0, 0), Is.True);
            Assert.That(rect.Contains(10, 10), Is.True);
        }

        [Test]
        public void GivenPoint2DInsideRectangle_WhenCallingContains_ThenReturnsTrue()
        {
            Rectangle2D rect = new(0, 0, 10, 10);
            Point2D point = new(5, 5);

            Assert.That(rect.Contains(point), Is.True);
        }

        [Test]
        public void GivenPoint2DOutsideRectangle_WhenCallingContains_ThenReturnsFalse()
        {
            Rectangle2D rect = new(0, 0, 10, 10);
            Point2D point = new(15, 5);

            Assert.That(rect.Contains(point), Is.False);
        }

        [Test]
        public void GivenInnerRectangleFullyContained_WhenCallingContains_ThenReturnsTrue()
        {
            Rectangle2D outer = new(0, 0, 20, 20);
            Rectangle2D inner = new(2, 2, 5, 5);

            Assert.That(outer.Contains(inner), Is.True);
        }

        [Test]
        public void GivenRectanglePartiallyOutside_WhenCallingContains_ThenReturnsFalse()
        {
            Rectangle2D outer = new(0, 0, 10, 10);
            Rectangle2D partial = new(5, 5, 10, 10);

            Assert.That(outer.Contains(partial), Is.False);
        }

        [Test]
        public void GivenRectangleFullyOutside_WhenCallingContains_ThenReturnsFalse()
        {
            Rectangle2D outer = new(0, 0, 10, 10);
            Rectangle2D outside = new(15, 15, 5, 5);

            Assert.That(outer.Contains(outside), Is.False);
        }

        [Test]
        public void GivenTwoRectanglesWithSameValues_WhenCheckingEquality_ThenReturnsTrue()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 20);

            Assert.That(rect1.Equals(rect2), Is.True);
        }

        [Test]
        public void GivenTwoRectanglesWithDifferentValues_WhenCheckingEquality_ThenReturnsFalse()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 21);

            Assert.That(rect1.Equals(rect2), Is.False);
        }

        [Test]
        public void GivenMatchingXYWidthHeight_WhenCallingEqualsWithXYWidthHeight_ThenReturnsTrue()
            => Assert.That(new Rectangle2D(1, 2, 10, 20).Equals(1, 2, 10, 20), Is.True);

        [Test]
        public void GivenNonMatchingXYWidthHeight_WhenCallingEqualsWithXYWidthHeight_ThenReturnsFalse()
            => Assert.That(new Rectangle2D(1, 2, 10, 20).Equals(1, 2, 10, 99), Is.False);

        [Test]
        public void GivenMatchingLocationAndSize_WhenCallingEqualsWithLocationAndSize_ThenReturnsTrue()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals(new Point2D(1, 2), new Size2D(10, 20)), Is.True);
        }

        [Test]
        public void GivenNonMatchingLocationAndSize_WhenCallingEqualsWithLocationAndSize_ThenReturnsFalse()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals(new Point2D(1, 2), new Size2D(10, 99)), Is.False);
        }

        [Test]
        public void GivenMatchingLocationAndWidthHeight_WhenCallingEqualsWithLocationAndWidthHeight_ThenReturnsTrue()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals(new Point2D(1, 2), 10, 20), Is.True);
        }

        [Test]
        public void GivenNonMatchingLocationAndWidthHeight_WhenCallingEqualsWithLocationAndWidthHeight_ThenReturnsFalse()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals(new Point2D(1, 2), 10, 99), Is.False);
        }

        [Test]
        public void GivenMatchingXYAndSize_WhenCallingEqualsWithXYAndSize_ThenReturnsTrue()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals(1, 2, new Size2D(10, 20)), Is.True);
        }

        [Test]
        public void GivenNonMatchingXYAndSize_WhenCallingEqualsWithXYAndSize_ThenReturnsFalse()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals(1, 2, new Size2D(10, 99)), Is.False);
        }

        [Test]
        public void GivenSameRectangleBoxedAsObject_WhenCheckingObjectEquality_ThenReturnsTrue()
        {
            Rectangle2D rect = new(1, 2, 10, 20);
            Assert.That(rect.Equals((object)new Rectangle2D(1, 2, 10, 20)), Is.True);
        }

        [Test]
        public void GivenUnrelatedObject_WhenCheckingObjectEquality_ThenReturnsFalse()
        {
            Rectangle2D rect = new(1, 2, 10, 20);

            Assert.That(rect.Equals(DateTime.Now), Is.False);
        }

        [Test]
        public void GivenTwoRectanglesWithSameValues_WhenGettingHashCode_ThenReturnSameHash()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 20);

            Assert.That(rect1.GetHashCode(), Is.EqualTo(rect2.GetHashCode()));
        }

        [Test]
        public void GivenTwoRectanglesWithDifferentValues_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 21);

            Assert.That(rect1.GetHashCode(), Is.Not.EqualTo(rect2.GetHashCode()));
        }

        [Test]
        public void GivenTwoEqualRectangles_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 20);

            Assert.That(rect1 == rect2, Is.True);
        }

        [Test]
        public void GivenTwoDifferentRectangles_WhenUsingEqualityOperator_ThenReturnsFalse()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 21);

            Assert.That(rect1 == rect2, Is.False);
        }

        [Test]
        public void GivenTwoDifferentRectangles_WhenUsingInequalityOperator_ThenReturnsTrue()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 21);

            Assert.That(rect1 != rect2, Is.True);
        }

        [Test]
        public void GivenTwoEqualRectangles_WhenUsingInequalityOperator_ThenReturnsFalse()
        {
            Rectangle2D rect1 = new(1, 2, 10, 20);
            Rectangle2D rect2 = new(1, 2, 10, 20);

            Assert.That(rect1 != rect2, Is.False);
        }

        [Test]
        public void GivenRectangle2D_WhenConvertingToSystemRectangle_ThenValuesArePreserved()
        {
            Rectangle2D source = new(1, 2, 10, 20);
            SystemRectangle result = source;

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenSystemRectangle_WhenConvertingToRectangle2D_ThenValuesArePreserved()
        {
            SystemRectangle source = new(1, 2, 10, 20);
            Rectangle2D result = source;

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenRectangle2D_WhenConvertingToXnaRectangle_ThenValuesArePreserved()
        {
            Rectangle2D source = new(1, 2, 10, 20);
            XnaRectangle result = source;

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }

        [Test]
        public void GivenXnaRectangle_WhenConvertingToRectangle2D_ThenValuesArePreserved()
        {
            XnaRectangle source = new(1, 2, 10, 20);
            Rectangle2D result = source;

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Width, Is.EqualTo(10));
            Assert.That(result.Height, Is.EqualTo(20));
        }
    }
}
