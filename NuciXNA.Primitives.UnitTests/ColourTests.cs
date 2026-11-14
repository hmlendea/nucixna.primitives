using System;
using System.Reflection;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    [TestFixture]
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
        public void GivenGrayColour_WhenCheckingComponents_ThenRgbAreEqualTo128AndAlphaIsMax()
        {
            Assert.That(Colour.Gray.R, Is.EqualTo(128));
            Assert.That(Colour.Gray.G, Is.EqualTo(128));
            Assert.That(Colour.Gray.B, Is.EqualTo(128));
            Assert.That(Colour.Gray.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenMaroonColour_WhenCheckingComponents_ThenOnlyRedIs128AndAlphaIsMax()
        {
            Assert.That(Colour.Maroon.R, Is.EqualTo(128));
            Assert.That(Colour.Maroon.G, Is.EqualTo(0));
            Assert.That(Colour.Maroon.B, Is.EqualTo(0));
            Assert.That(Colour.Maroon.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenNavyColour_WhenCheckingComponents_ThenOnlyBlueIs128AndAlphaIsMax()
        {
            Assert.That(Colour.Navy.R, Is.EqualTo(0));
            Assert.That(Colour.Navy.G, Is.EqualTo(0));
            Assert.That(Colour.Navy.B, Is.EqualTo(128));
            Assert.That(Colour.Navy.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenPurpleColour_WhenCheckingComponents_ThenRedAndBlueAre128AndAlphaIsMax()
        {
            Assert.That(Colour.Purple.R, Is.EqualTo(128));
            Assert.That(Colour.Purple.G, Is.EqualTo(0));
            Assert.That(Colour.Purple.B, Is.EqualTo(128));
            Assert.That(Colour.Purple.A, Is.EqualTo(255));
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

            Assert.That(isSimilar);
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
            => Assert.That(new Colour(1, 2, 3).Equals(1, 2, 3));

        [Test]
        public void GivenNonMatchingRgbValues_WhenCallingEqualsWithRgb_ThenReturnsFalse()
            => Assert.That(new Colour(1, 2, 3).Equals(1, 2, 99), Is.False);

        [Test]
        public void GivenMatchingArgbValues_WhenCallingEqualsWithArgb_ThenReturnsTrue()
            => Assert.That(new Colour(1, 2, 3, 4).Equals(4, 1, 2, 3));

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
            => Assert.That(new Colour(255, 0, 0).Equals((string)null!), Is.False);

        [Test]
        public void GivenColourAndUnrelatedObject_WhenCheckingEquality_ThenReturnsFalse()
            => Assert.That(new Colour(255, 0, 255), Is.Not.EqualTo((object)"Unrelated"));

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
        public void GivenTwoDifferentColours_WhenUsingInequalityOperator_ThenReturnsTrue()
            => Assert.That(Colour.Black != Colour.White);
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

        [TestCase(nameof(Colour.Transparent), 0, 0, 0, 0)]
        [TestCase(nameof(Colour.AliceBlue), 240, 248, 255, 255)]
        [TestCase(nameof(Colour.AntiqueWhite), 250, 235, 215, 255)]
        [TestCase(nameof(Colour.Aqua), 0, 255, 255, 255)]
        [TestCase(nameof(Colour.Aquamarine), 127, 255, 212, 255)]
        [TestCase(nameof(Colour.Bisque), 255, 228, 196, 255)]
        [TestCase(nameof(Colour.Black), 0, 0, 0, 255)]
        [TestCase(nameof(Colour.Blue), 0, 0, 255, 255)]
        [TestCase(nameof(Colour.Chocolate), 210, 105, 30, 255)]
        [TestCase(nameof(Colour.CornflowerBlue), 100, 149, 237, 255)]
        [TestCase(nameof(Colour.Cornsilk), 255, 248, 220, 255)]
        [TestCase(nameof(Colour.Crimson), 220, 20, 60, 255)]
        [TestCase(nameof(Colour.DarkGreen), 0, 100, 0, 255)]
        [TestCase(nameof(Colour.DarkRed), 139, 0, 0, 255)]
        [TestCase(nameof(Colour.DimGray), 105, 105, 105, 255)]
        [TestCase(nameof(Colour.DodgerBlue), 30, 144, 255, 255)]
        [TestCase(nameof(Colour.Gold), 255, 215, 0, 255)]
        [TestCase(nameof(Colour.Gray), 128, 128, 128, 255)]
        [TestCase(nameof(Colour.Green), 0, 255, 0, 255)]
        [TestCase(nameof(Colour.Maroon), 128, 0, 0, 255)]
        [TestCase(nameof(Colour.Navy), 0, 0, 128, 255)]
        [TestCase(nameof(Colour.Olive), 128, 128, 0, 255)]
        [TestCase(nameof(Colour.OliveDrab), 107, 142, 45, 255)]
        [TestCase(nameof(Colour.Orange), 255, 165, 0, 255)]
        [TestCase(nameof(Colour.Purple), 128, 0, 128, 255)]
        [TestCase(nameof(Colour.Red), 255, 0, 0, 255)]
        [TestCase(nameof(Colour.RoyalBlue), 65, 105, 255, 255)]
        [TestCase(nameof(Colour.Salmon), 250, 128, 114, 255)]
        [TestCase(nameof(Colour.SeaGreen), 46, 139, 87, 255)]
        [TestCase(nameof(Colour.SkyBlue), 135, 206, 235, 255)]
        [TestCase(nameof(Colour.Snow), 255, 250, 250, 255)]
        [TestCase(nameof(Colour.Tan), 210, 180, 140, 255)]
        [TestCase(nameof(Colour.Teal), 0, 128, 128, 255)]
        [TestCase(nameof(Colour.Thistle), 216, 191, 216, 255)]
        [TestCase(nameof(Colour.Tomato), 255, 99, 71, 255)]
        [TestCase(nameof(Colour.Turqoise), 64, 224, 208, 255)]
        [TestCase(nameof(Colour.Violet), 238, 130, 238, 255)]
        [TestCase(nameof(Colour.Wheat), 245, 222, 179, 255)]
        [TestCase(nameof(Colour.White), 255, 255, 255, 255)]
        [TestCase(nameof(Colour.WhiteSmoke), 245, 245, 245, 255)]
        [TestCase(nameof(Colour.Yellow), 255, 255, 0, 255)]
        [TestCase(nameof(Colour.YellowGreen), 154, 205, 50, 255)]
        [TestCase(nameof(Colour.CobaltBlue), 0, 43, 127, 255)]
        [TestCase(nameof(Colour.ChromeYellow), 252, 209, 22, 255)]
        [TestCase(nameof(Colour.PersianRed), 200, 29, 17, 255)]
        [TestCase(nameof(Colour.Vermilion), 227, 66, 52, 255)]
        [TestCase(nameof(Colour.VermilionRed), 206, 17, 38, 255)]
        [TestCase(nameof(Colour.Greenery), 136, 176, 75, 255)]
        [TestCase(nameof(Colour.Honeysuckle), 217, 79, 112, 255)]
        [TestCase(nameof(Colour.Tangerine), 248, 143, 88, 255)]
        [TestCase(nameof(Colour.TangerineTango), 221, 65, 36, 255)]
        [TestCase(nameof(Colour.UltraViolet), 95, 75, 139, 255)]
        [TestCase(nameof(Colour.MaterialRed), 244, 67, 54, 255)]
        [TestCase(nameof(Colour.MaterialPink), 233, 30, 99, 255)]
        [TestCase(nameof(Colour.MaterialPurple), 103, 58, 183, 255)]
        [TestCase(nameof(Colour.MaterialIndigo), 63, 81, 181, 255)]
        [TestCase(nameof(Colour.MaterialBlue), 33, 150, 243, 255)]
        [TestCase(nameof(Colour.MaterialLightBlue), 3, 169, 244, 255)]
        [TestCase(nameof(Colour.MaterialCyan), 0, 188, 212, 255)]
        [TestCase(nameof(Colour.MaterialTeal), 0, 150, 136, 255)]
        [TestCase(nameof(Colour.MaterialGreen), 76, 175, 80, 255)]
        [TestCase(nameof(Colour.MaterialLightGreen), 139, 195, 74, 255)]
        [TestCase(nameof(Colour.MaterialLime), 205, 220, 57, 255)]
        [TestCase(nameof(Colour.MaterialYellow), 255, 235, 59, 255)]
        [TestCase(nameof(Colour.MaterialAmber), 255, 193, 7, 255)]
        [TestCase(nameof(Colour.MaterialOrange), 255, 152, 0, 255)]
        [TestCase(nameof(Colour.MaterialDeepOrange), 255, 87, 34, 255)]
        [TestCase(nameof(Colour.MaterialBrown), 121, 85, 72, 255)]
        [TestCase(nameof(Colour.MaterialGrey), 158, 158, 158, 255)]
        [TestCase(nameof(Colour.MaterialBlueGrey), 96, 125, 139, 255)]
        public void GivenPredefinedColour_WhenInspectingChannels_ThenTheyMatchTheDocumentedValues(
            string colourName, int r, int g, int b, int a)
        {
            Colour colour = GetPredefinedColour(colourName);

            Assert.That((int)colour.R, Is.EqualTo(r));
            Assert.That((int)colour.G, Is.EqualTo(g));
            Assert.That((int)colour.B, Is.EqualTo(b));
            Assert.That((int)colour.A, Is.EqualTo(a));
        }

        [TestCase(nameof(Colour.Transparent))]
        [TestCase(nameof(Colour.AliceBlue))]
        [TestCase(nameof(Colour.AntiqueWhite))]
        [TestCase(nameof(Colour.Aqua))]
        [TestCase(nameof(Colour.Aquamarine))]
        [TestCase(nameof(Colour.Bisque))]
        [TestCase(nameof(Colour.Black))]
        [TestCase(nameof(Colour.Blue))]
        [TestCase(nameof(Colour.Chocolate))]
        [TestCase(nameof(Colour.CornflowerBlue))]
        [TestCase(nameof(Colour.Cornsilk))]
        [TestCase(nameof(Colour.Crimson))]
        [TestCase(nameof(Colour.DarkGreen))]
        [TestCase(nameof(Colour.DarkRed))]
        [TestCase(nameof(Colour.DimGray))]
        [TestCase(nameof(Colour.DodgerBlue))]
        [TestCase(nameof(Colour.Gold))]
        [TestCase(nameof(Colour.Gray))]
        [TestCase(nameof(Colour.Green))]
        [TestCase(nameof(Colour.Maroon))]
        [TestCase(nameof(Colour.Navy))]
        [TestCase(nameof(Colour.Olive))]
        [TestCase(nameof(Colour.OliveDrab))]
        [TestCase(nameof(Colour.Orange))]
        [TestCase(nameof(Colour.Purple))]
        [TestCase(nameof(Colour.Red))]
        [TestCase(nameof(Colour.RoyalBlue))]
        [TestCase(nameof(Colour.Salmon))]
        [TestCase(nameof(Colour.SeaGreen))]
        [TestCase(nameof(Colour.SkyBlue))]
        [TestCase(nameof(Colour.Snow))]
        [TestCase(nameof(Colour.Tan))]
        [TestCase(nameof(Colour.Teal))]
        [TestCase(nameof(Colour.Thistle))]
        [TestCase(nameof(Colour.Tomato))]
        [TestCase(nameof(Colour.Turqoise))]
        [TestCase(nameof(Colour.Violet))]
        [TestCase(nameof(Colour.Wheat))]
        [TestCase(nameof(Colour.White))]
        [TestCase(nameof(Colour.WhiteSmoke))]
        [TestCase(nameof(Colour.Yellow))]
        [TestCase(nameof(Colour.YellowGreen))]
        [TestCase(nameof(Colour.CobaltBlue))]
        [TestCase(nameof(Colour.ChromeYellow))]
        [TestCase(nameof(Colour.PersianRed))]
        [TestCase(nameof(Colour.Vermilion))]
        [TestCase(nameof(Colour.VermilionRed))]
        [TestCase(nameof(Colour.Greenery))]
        [TestCase(nameof(Colour.Honeysuckle))]
        [TestCase(nameof(Colour.Tangerine))]
        [TestCase(nameof(Colour.TangerineTango))]
        [TestCase(nameof(Colour.UltraViolet))]
        [TestCase(nameof(Colour.MaterialRed))]
        [TestCase(nameof(Colour.MaterialPink))]
        [TestCase(nameof(Colour.MaterialPurple))]
        [TestCase(nameof(Colour.MaterialIndigo))]
        [TestCase(nameof(Colour.MaterialBlue))]
        [TestCase(nameof(Colour.MaterialLightBlue))]
        [TestCase(nameof(Colour.MaterialCyan))]
        [TestCase(nameof(Colour.MaterialTeal))]
        [TestCase(nameof(Colour.MaterialGreen))]
        [TestCase(nameof(Colour.MaterialLightGreen))]
        [TestCase(nameof(Colour.MaterialLime))]
        [TestCase(nameof(Colour.MaterialYellow))]
        [TestCase(nameof(Colour.MaterialAmber))]
        [TestCase(nameof(Colour.MaterialOrange))]
        [TestCase(nameof(Colour.MaterialDeepOrange))]
        [TestCase(nameof(Colour.MaterialBrown))]
        [TestCase(nameof(Colour.MaterialGrey))]
        [TestCase(nameof(Colour.MaterialBlueGrey))]
        public void GivenPredefinedColour_WhenConvertingToAndFromHexadecimal_ThenTheColourIsPreserved(string colourName)
        {
            Colour colour = GetPredefinedColour(colourName);
            Colour roundTripped = Colour.FromHexadecimal(colour.ToHexadecimal());

            Assert.That(roundTripped, Is.EqualTo(colour));
        }

        [TestCase(nameof(Colour.Transparent))]
        [TestCase(nameof(Colour.AliceBlue))]
        [TestCase(nameof(Colour.AntiqueWhite))]
        [TestCase(nameof(Colour.Aqua))]
        [TestCase(nameof(Colour.Aquamarine))]
        [TestCase(nameof(Colour.Bisque))]
        [TestCase(nameof(Colour.Black))]
        [TestCase(nameof(Colour.Blue))]
        [TestCase(nameof(Colour.Chocolate))]
        [TestCase(nameof(Colour.CornflowerBlue))]
        [TestCase(nameof(Colour.Cornsilk))]
        [TestCase(nameof(Colour.Crimson))]
        [TestCase(nameof(Colour.DarkGreen))]
        [TestCase(nameof(Colour.DarkRed))]
        [TestCase(nameof(Colour.DimGray))]
        [TestCase(nameof(Colour.DodgerBlue))]
        [TestCase(nameof(Colour.Gold))]
        [TestCase(nameof(Colour.Gray))]
        [TestCase(nameof(Colour.Green))]
        [TestCase(nameof(Colour.Maroon))]
        [TestCase(nameof(Colour.Navy))]
        [TestCase(nameof(Colour.Olive))]
        [TestCase(nameof(Colour.OliveDrab))]
        [TestCase(nameof(Colour.Orange))]
        [TestCase(nameof(Colour.Purple))]
        [TestCase(nameof(Colour.Red))]
        [TestCase(nameof(Colour.RoyalBlue))]
        [TestCase(nameof(Colour.Salmon))]
        [TestCase(nameof(Colour.SeaGreen))]
        [TestCase(nameof(Colour.SkyBlue))]
        [TestCase(nameof(Colour.Snow))]
        [TestCase(nameof(Colour.Tan))]
        [TestCase(nameof(Colour.Teal))]
        [TestCase(nameof(Colour.Thistle))]
        [TestCase(nameof(Colour.Tomato))]
        [TestCase(nameof(Colour.Turqoise))]
        [TestCase(nameof(Colour.Violet))]
        [TestCase(nameof(Colour.Wheat))]
        [TestCase(nameof(Colour.White))]
        [TestCase(nameof(Colour.WhiteSmoke))]
        [TestCase(nameof(Colour.Yellow))]
        [TestCase(nameof(Colour.YellowGreen))]
        [TestCase(nameof(Colour.CobaltBlue))]
        [TestCase(nameof(Colour.ChromeYellow))]
        [TestCase(nameof(Colour.PersianRed))]
        [TestCase(nameof(Colour.Vermilion))]
        [TestCase(nameof(Colour.VermilionRed))]
        [TestCase(nameof(Colour.Greenery))]
        [TestCase(nameof(Colour.Honeysuckle))]
        [TestCase(nameof(Colour.Tangerine))]
        [TestCase(nameof(Colour.TangerineTango))]
        [TestCase(nameof(Colour.UltraViolet))]
        [TestCase(nameof(Colour.MaterialRed))]
        [TestCase(nameof(Colour.MaterialPink))]
        [TestCase(nameof(Colour.MaterialPurple))]
        [TestCase(nameof(Colour.MaterialIndigo))]
        [TestCase(nameof(Colour.MaterialBlue))]
        [TestCase(nameof(Colour.MaterialLightBlue))]
        [TestCase(nameof(Colour.MaterialCyan))]
        [TestCase(nameof(Colour.MaterialTeal))]
        [TestCase(nameof(Colour.MaterialGreen))]
        [TestCase(nameof(Colour.MaterialLightGreen))]
        [TestCase(nameof(Colour.MaterialLime))]
        [TestCase(nameof(Colour.MaterialYellow))]
        [TestCase(nameof(Colour.MaterialAmber))]
        [TestCase(nameof(Colour.MaterialOrange))]
        [TestCase(nameof(Colour.MaterialDeepOrange))]
        [TestCase(nameof(Colour.MaterialBrown))]
        [TestCase(nameof(Colour.MaterialGrey))]
        [TestCase(nameof(Colour.MaterialBlueGrey))]
        public void GivenPredefinedColour_WhenConvertingToAndFromArgb_ThenTheColourIsPreserved(string colourName)
        {
            Colour colour = GetPredefinedColour(colourName);
            Colour roundTripped = Colour.FromArgb(colour.ToArgb());

            Assert.That(roundTripped, Is.EqualTo(colour));
        }

        [Test]
        public void GivenColourAndFactor_WhenMultiplyingByFractionalFactor_ThenChannelsAreTruncated()
        {
            Colour colour = new(3, 5, 7, 255);
            Colour actual = colour * 1.5f;

            Assert.That(actual.R, Is.EqualTo(4));
            Assert.That(actual.G, Is.EqualTo(7));
            Assert.That(actual.B, Is.EqualTo(10));
            Assert.That(actual.A, Is.EqualTo(255));
        }

        [Test]
        public void GivenColourAndZeroFactor_WhenCallingMultiply_ThenReturnsFullyTransparentBlack()
        {
            Colour colour = new(200, 150, 100, 50);
            Colour actual = Colour.Multiply(colour, 0);

            Assert.That(actual, Is.EqualTo(new Colour(0, 0, 0, 0)));
        }

        [Test]
        public void GivenColour_WhenMultiplyingByExactIdentity_ThenColourIsUnchanged()
        {
            Colour colour = new(12, 34, 56, 78);
            Colour actual = colour * 1f;

            Assert.That(actual, Is.EqualTo(colour));
        }

        [Test]
        public void GivenColourWithAlpha_WhenCallingToMonochromeAverage_ThenAlphaIsPreserved()
        {
            Colour colour = new(30, 60, 90, 40);
            Colour actual = colour.ToMonochromeAverage();

            Assert.That(actual.A, Is.EqualTo(40));
        }

        [Test]
        public void GivenColourWithAlpha_WhenCallingToMonochromeLight_ThenLightestChannelAndAlphaAreUsed()
        {
            Colour colour = new(30, 60, 90, 40);
            Colour actual = colour.ToMonochromeLight();

            Assert.That(actual.R, Is.EqualTo(90));
            Assert.That(actual.A, Is.EqualTo(40));
        }

        [Test]
        public void GivenColourWithAlpha_WhenCallingToMonochromeDark_ThenDarkestChannelAndAlphaAreUsed()
        {
            Colour colour = new(30, 60, 90, 40);
            Colour actual = colour.ToMonochromeDark();

            Assert.That(actual.R, Is.EqualTo(30));
            Assert.That(actual.A, Is.EqualTo(40));
        }

        [Test]
        public void GivenColourAndNegativeTolerance_WhenCallingIsSimilarTo_ThenReturnsFalse()
            => Assert.That(new Colour(10, 10, 10).IsSimilarTo(new Colour(10, 10, 10), -1), Is.False);

        [Test]
        public void GivenColourAndZeroTolerance_WhenCallingIsSimilarTo_ThenRequiresExactEquality()
            => Assert.That(new Colour(10, 10, 10).IsSimilarTo(new Colour(10, 10, 11), 0), Is.False);

        [Test]
        public void GivenSameColourReference_WhenCallingObjectEquals_ThenReturnsTrue()
        {
            Colour colour = new(10, 20, 30);

            Assert.That(colour.Equals((object)colour));
        }

        [Test]
        public void GivenTwoNullOperands_WhenUsingEqualityOperator_ThenReturnsTrue()
        {
            Colour? left = null;
            Colour? right = null;

            Assert.That(left == right);
        }

        [Test]
        public void GivenColour_WhenCallingEqualsOnItself_ThenReturnsTrue()
        {
            Colour colour = new(10, 20, 30, 40);

            Assert.That(colour.Equals(colour));
        }

        private static Colour GetPredefinedColour(string colourName)
        {
            PropertyInfo? property = typeof(Colour).GetProperty(colourName, BindingFlags.Public | BindingFlags.Static);

            Assert.That(
                property,
                Is.Not.Null,
                $"Violated expectation: predefined colour '{colourName}' was not found.");

            return (Colour)property!.GetValue(null)!;
        }
    }
}
