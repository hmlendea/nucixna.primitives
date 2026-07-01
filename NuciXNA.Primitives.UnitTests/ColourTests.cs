using System;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class ColourTests
    {
        [Test]
        public void GivenDefaultConstructor_WhenConstructing_ThenAlphaIsMaxAndRGBIsZero()
        {
            Colour colour = new();

            Assert.That(colour.R, Is.EqualTo(0));
            Assert.That(colour.G, Is.EqualTo(0));
            Assert.That(colour.B, Is.EqualTo(0));
            Assert.That(colour.A, Is.EqualTo(byte.MaxValue));
        }

        [Test]
        public void GivenRgbComponents_WhenConstructing_ThenPropertiesAreSet()
        {
            Colour colour = new(1, 2, 3);

            Assert.That(colour.R, Is.EqualTo(1));
            Assert.That(colour.G, Is.EqualTo(2));
            Assert.That(colour.B, Is.EqualTo(3));
            Assert.That(colour.A, Is.EqualTo(byte.MaxValue));
        }

        [Test]
        public void GivenRgbaComponents_WhenConstructing_ThenPropertiesAreSet()
        {
            Colour colour = new(1, 2, 3, 4);

            Assert.That(colour.R, Is.EqualTo(1));
            Assert.That(colour.G, Is.EqualTo(2));
            Assert.That(colour.B, Is.EqualTo(3));
            Assert.That(colour.A, Is.EqualTo(4));
        }

        [Test]
        public void GivenTransparentColour_WhenCheckingComponents_ThenAlphaIsZero()
            => Assert.That(Colour.Transparent.A, Is.EqualTo(0));

        [Test]
        public void GivenBlackColour_WhenCheckingComponents_ThenRgbAreZeroAndAlphaIsMax()
        {
            Assert.That(Colour.Black.R, Is.EqualTo(0));
            Assert.That(Colour.Black.G, Is.EqualTo(0));
            Assert.That(Colour.Black.B, Is.EqualTo(0));
            Assert.That(Colour.Black.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenRedColour_WhenCheckingComponents_ThenOnlyRedChannelIsMax()
        {
            Assert.That(Colour.Red.R, Is.EqualTo(255));
            Assert.That(Colour.Red.G, Is.EqualTo(0));
            Assert.That(Colour.Red.B, Is.EqualTo(0));
            Assert.That(Colour.Red.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenHexString_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(255, 0, 0);
            Colour actual = Colour.FromHexadecimal("#FF0000");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenArgbInteger_WhenCallingFromArgb_ThenReturnsCorrectColour()
        {
            Colour expected = new(1, 2, 3, 4);
            Colour actual = Colour.FromArgb(67174915);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenByteRgb_WhenCallingFromArgb_ThenReturnsCorrectColour()
        {
            Colour result = Colour.FromArgb((byte)10, (byte)20, (byte)30);

            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
            Assert.That(result.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenByteArgb_WhenCallingFromArgb_ThenReturnsCorrectColour()
        {
            Colour result = Colour.FromArgb((byte)128, (byte)10, (byte)20, (byte)30);

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenColour_WhenCallingToString_ThenReturnsHexadecimalString()
        {
            Colour colour = new(255, 0, 0);
            string expected = "#FF0000";
            string actual = colour.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenFullyOpaqueColour_WhenCallingToHexadecimal_ThenOmitsAlpha()
        {
            Colour colour = new(0, 255, 0);
            string expected = "#00FF00";

            string actual = colour.ToHexadecimal();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColourWithAlpha_WhenCallingToHexadecimal_ThenIncludesAlphaPrefix()
        {
            Colour colour = new(255, 0, 0, 128);
            string expected = "#80FF0000";

            string actual = colour.ToHexadecimal();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColour_WhenCallingToArgb_ThenReturnsCorrectInteger()
        {
            Colour colour = new(1, 2, 3);
            int expected = -16711165;

            int actual = colour.ToArgb();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColour_WhenCallingToMonochromeAverage_ThenReturnsCorrectColour()
        {
            Colour colour = new(8, 16, 24);
            Colour expected = new(16, 16, 16);
            Colour actual = colour.ToMonochromeAverage();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColourWithEqualRGBComponents_WhenCallingToMonochromeAverage_ThenReturnsUnchangedColour()
        {
            Colour colour = new(10, 10, 10);
            Colour expected = new(10, 10, 10);

            Colour actual = colour.ToMonochromeAverage();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColour_WhenCallingToMonochromeAverage_ThenAlphaIsPreserved()
        {
            Colour colour = new(8, 16, 24, 200);

            Colour actual = colour.ToMonochromeAverage();

            Assert.That(actual.A, Is.EqualTo(200));
        }

        [Test]
        public void GivenColour_WhenCallingToMonochromeLight_ThenReturnsCorrectColour()
        {
            Colour colour = new(8, 16, 24);
            Colour expected = new(24, 24, 24);
            Colour actual = colour.ToMonochromeLight();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColour_WhenCallingToMonochromeLight_ThenAlphaIsPreserved()
        {
            Colour colour = new(8, 16, 24, 200);

            Colour actual = colour.ToMonochromeLight();

            Assert.That(actual.A, Is.EqualTo(200));
        }

        [Test]
        public void GivenColour_WhenCallingToMonochromeDark_ThenReturnsCorrectColour()
        {
            Colour colour = new(8, 16, 24);
            Colour expected = new(8, 8, 8);
            Colour actual = colour.ToMonochromeDark();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColour_WhenCallingToMonochromeDark_ThenAlphaIsPreserved()
        {
            Colour colour = new(8, 16, 24, 200);

            Colour actual = colour.ToMonochromeDark();

            Assert.That(actual.A, Is.EqualTo(200));
        }

        [Test]
        public void GivenTwoSimilarColours_WhenCallingIsSimilarTo_ThenReturnsTrue()
        {
            Colour colour1 = new(8, 16, 24);
            Colour colour2 = new(10, 18, 26);
            bool isSimilar = colour1.IsSimilarTo(colour2, 2);

            Assert.That(isSimilar);
        }

        [Test]
        public void GivenColourAtExactToleranceBoundary_WhenCallingIsSimilarTo_ThenReturnsTrue()
        {
            Colour colour1 = new(10, 10, 10);
            Colour colour2 = new(12, 12, 12);

            bool isSimilar = colour1.IsSimilarTo(colour2, 2);

            Assert.That(isSimilar, Is.True);
        }

        [Test]
        public void GivenColourSlightlyOutsideTolerance_WhenCallingIsSimilarTo_ThenReturnsFalse()
        {
            Colour colour1 = new(8, 16, 24);
            Colour colour2 = new(10, 18, 27);

            bool isSimilar = colour1.IsSimilarTo(colour2, 2);

            Assert.That(isSimilar, Is.False);
        }

        [Test]
        public void GivenColourAndValidFactor_WhenCallingMultiply_ThenReturnsCorrectColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(16, 16, 16, 16);
            Colour actual = Colour.Multiply(colour, 2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColourAndHugeFactor_WhenCallingMultiply_ThenReturnsWhiteColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(255, 255, 255, 255);
            Colour actual = Colour.Multiply(colour, 100);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColourAndNegativeFactor_WhenCallingMultiply_ThenReturnsBlackColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(0, 0, 0, 0);
            Colour actual = Colour.Multiply(colour, -100);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenTwoColoursWithSameRgb_WhenCheckingEquality_ThenReturnsTrue()
            => Assert.That(new Colour(1, 2, 3), Is.EqualTo(new Colour(1, 2, 3)));

        [Test]
        public void GivenTwoColoursWithDifferentRgb_WhenCheckingEquality_ThenReturnsFalse()
        {
            Colour colour1 = new(1, 2, 3);
            Colour colour2 = new(1, 2, 4);

            Assert.That(colour1, Is.Not.EqualTo(colour2));
        }

        [Test]
        public void GivenTwoColoursWithSameRgba_WhenCheckingEquality_ThenReturnsTrue()
            => Assert.That(new Colour(1, 2, 3, 4), Is.EqualTo(new Colour(1, 2, 3, 4)));

        [Test]
        public void GivenTwoColoursWithDifferentRgba_WhenCheckingEquality_ThenReturnsFalse()
            => Assert.That(new Colour(1, 2, 3, 4), Is.Not.EqualTo(new Colour(1, 2, 3, 5)));

        [Test]
        public void GivenMatchingRgbValues_WhenCallingEqualsWithRgb_ThenReturnsTrue()
            => Assert.That(new Colour(1, 2, 3).Equals(1, 2, 3), Is.True);

        [Test]
        public void GivenNonMatchingRgbValues_WhenCallingEqualsWithRgb_ThenReturnsFalse()
            => Assert.That(new Colour(1, 2, 3).Equals(1, 2, 99), Is.False);

        [Test]
        public void GivenMatchingArgbValues_WhenCallingEqualsWithArgb_ThenReturnsTrue()
            => Assert.That(new Colour(1, 2, 3, 4).Equals(4, 1, 2, 3), Is.True);

        [Test]
        public void GivenNonMatchingArgbValues_WhenCallingEqualsWithArgb_ThenReturnsFalse()
            => Assert.That(new Colour(1, 2, 3, 4).Equals(4, 1, 2, 99), Is.False);

        [Test]
        public void GivenColourAndMatchingHexString_WhenCheckingEquality_ThenReturnsTrue()
            => Assert.That(new Colour(255, 0, 255).Equals("#FF00FF"));

        [Test]
        public void GivenColourAndInvalidHexString_WhenCheckingEquality_ThenReturnsFalse()
            => Assert.That(new Colour(255, 0, 0).Equals("INVALID"), Is.False);

        [Test]
        public void GivenColourAndNullHexString_WhenCheckingEquality_ThenReturnsFalse()
            => Assert.That(new Colour(255, 0, 0).Equals((string)null), Is.False);

        [Test]
        public void GivenColourAndUnrelatedObject_WhenCheckingEquality_ThenReturnsFalse()
            => Assert.That(new Colour(255, 0, 255), Is.Not.EqualTo(DateTime.Now));

        [Test]
        public void GivenColoursWithSameComponents_WhenGettingHashCode_ThenReturnSameHash()
        {
            Colour colour1 = new(10, 20, 30, 40);
            Colour colour2 = new(10, 20, 30, 40);

            Assert.That(colour1.GetHashCode(), Is.EqualTo(colour2.GetHashCode()));
        }

        [Test]
        public void GivenColoursWithPermutedComponents_WhenGettingHashCode_ThenReturnDifferentHashes()
        {
            Colour colour1 = new(255, 0, 0, 1);
            Colour colour2 = new(0, 255, 1, 0);

            Assert.That(colour1.GetHashCode(), Is.Not.EqualTo(colour2.GetHashCode()));
        }

        [Test]
        public void GivenColourAndFactor_WhenUsingMultiplyOperator_ThenReturnsCorrectColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(16, 16, 16, 16);
            Colour actual = colour * 2;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColourAndHugeFactor_WhenUsingMultiplyOperator_ThenReturnsWhiteColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(255, 255, 255, 255);
            Colour actual = colour * 100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenColourAndNegativeFactor_WhenUsingMultiplyOperator_ThenReturnsBlackColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(0, 0, 0, 0);
            Colour actual = colour * -1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenTwoIdenticalColours_WhenUsingEqualityOperator_ThenReturnsTrue()
            => Assert.That(Colour.Black == Colour.Black);

        [Test]
        public void GivenTwoDifferentColours_WhenUsingEqualityOperator_ThenReturnsFalse()
            => Assert.That(Colour.Black == Colour.White, Is.False);

        [Test]
        public void GivenColourAndNull_WhenUsingEqualityOperator_ThenReturnsFalse()
            => Assert.That(Colour.Black == null, Is.False);

        [Test]
        public void GivenNullRightOperand_WhenUsingEqualityOperator_ThenReturnsFalse()
            => Assert.That(Colour.White == null, Is.False);

        [Test]
        public void GivenTwoDifferentColours_WhenUsingInequalityOperator_ThenReturnsTrue()
            => Assert.That(Colour.Black != Colour.White, Is.True);

        [Test]
        public void GivenTwoIdenticalColours_WhenUsingInequalityOperator_ThenReturnsFalse()
            => Assert.That(Colour.Black != Colour.Black, Is.False);

        [Test]
        public void GivenColour_WhenCastingToInt_ThenReturnsArgbInteger()
        {
            Colour colour = new(1, 2, 3, 4);
            int result = (int)colour;

            Assert.That(result, Is.EqualTo(67174915));
        }

        [Test]
        public void GivenArgbInteger_WhenCastingToColour_ThenReturnsCorrectColour()
        {
            Colour result = (Colour)67174915;

            Assert.That(result.A, Is.EqualTo(4));
            Assert.That(result.R, Is.EqualTo(1));
            Assert.That(result.G, Is.EqualTo(2));
            Assert.That(result.B, Is.EqualTo(3));
        }

        [Test]
        public void GivenColour_WhenCastingToString_ThenReturnsHexadecimalString()
        {
            Colour colour = new(255, 0, 0);
            string result = (string)colour;

            Assert.That(result, Is.EqualTo("#FF0000"));
        }

        [Test]
        public void GivenHexString_WhenCastingToColour_ThenReturnsCorrectColour()
        {
            Colour result = (Colour)"#FF0000";

            Assert.That(result.R, Is.EqualTo(255));
            Assert.That(result.G, Is.EqualTo(0));
            Assert.That(result.B, Is.EqualTo(0));
        }
    }
}
