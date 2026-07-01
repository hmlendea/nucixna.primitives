using System;

using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    public class ColourTranslatorTests
    {
        [Test]
        public void GivenValidLongHexWithHashAndAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(255, 0, 255, 255);
            Colour actual = ColourTranslator.FromHexadecimal("#FFFF00FF");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidLongHexWithHashWithoutAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(255, 0, 255);
            Colour actual = ColourTranslator.FromHexadecimal("#FF00FF");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidLongHexWithoutHashWithAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(0, 255, 255, 255);
            Colour actual = ColourTranslator.FromHexadecimal("FF00FFFF");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidLongHexWithoutHashOrAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(0, 255, 255);
            Colour actual = ColourTranslator.FromHexadecimal("00FFFF");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidShortHexWithHashAndAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(255, 0, 255, 255);
            Colour actual = ColourTranslator.FromHexadecimal("#FF0F");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidShortHexWithHashWithoutAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(255, 0, 255);
            Colour actual = ColourTranslator.FromHexadecimal("#F0F");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidShortHexWithoutHashWithAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(0, 255, 255, 255);
            Colour actual = ColourTranslator.FromHexadecimal("F0FF");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidShortHexWithoutHashOrAlpha_WhenCallingFromHexadecimal_ThenReturnsCorrectColour()
        {
            Colour expected = new(0, 255, 255);
            Colour actual = ColourTranslator.FromHexadecimal("0FF");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenHexWithTwoHashes_WhenCallingFromHexadecimal_ThenThrowsFormatException()
            => Assert.Throws<FormatException>(() => ColourTranslator.FromHexadecimal("##0FF"));

        [Test]
        public void GivenHexWithDigitsOutsideHexRange_WhenCallingFromHexadecimal_ThenThrowsFormatException()
            => Assert.Throws<FormatException>(() => ColourTranslator.FromHexadecimal("#FZZ"));

        [Test]
        public void GivenHexWithTooFewDigits_WhenCallingFromHexadecimal_ThenThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() => ColourTranslator.FromHexadecimal("#FF"));

        [Test]
        public void GivenHexWithTooManyDigits_WhenCallingFromHexadecimal_ThenThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() => ColourTranslator.FromHexadecimal("#FF00FF00FF"));

        [Test]
        public void GivenNullArgument_WhenCallingFromHexadecimal_ThenThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => ColourTranslator.FromHexadecimal(null));

        [Test]
        public void GivenColour_WhenCallingToHexadecimal_ThenReturnsCorrectValue()
        {
            Colour colour = Colour.ChromeYellow;
            string expected = "#FCD116";
            string actual = ColourTranslator.ToHexadecimal(colour);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidArgbInteger_WhenCallingFromArgb_ThenReturnsCorrectColour()
        {
            Colour expected = new(1, 2, 3, 4);
            Colour actual = ColourTranslator.FromArgb(67174915);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidRgbComponents_WhenCallingFromArgb_ThenReturnsCorrectColour()
        {
            Colour expected = new(1, 2, 3);
            Colour actual = ColourTranslator.FromArgb(1, 2, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValidArgbComponents_WhenCallingFromArgb_ThenReturnsCorrectColour()
        {
            Colour expected = new(1, 2, 3, 0);
            Colour actual = ColourTranslator.FromArgb(0, 1, 2, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenByteRgbComponents_WhenCallingFromArgb_ThenAlphaIsMaxAndChannelsArePreserved()
        {
            Colour result = ColourTranslator.FromArgb((byte)10, (byte)20, (byte)30);

            Assert.That(result.A, Is.EqualTo(255));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenByteArgbComponents_WhenCallingFromArgb_ThenAllChannelsArePreserved()
        {
            Colour result = ColourTranslator.FromArgb((byte)128, (byte)10, (byte)20, (byte)30);

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenColour_WhenCallingToArgb_ThenReturnsCorrectValue()
        {
            int expected = 67174915;
            Colour colour = ColourTranslator.FromArgb(expected);

            int actual = ColourTranslator.ToArgb(colour);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenRgbComponents_WhenCallingToArgb_ThenReturnsCorrectValue()
        {
            int expected = -16711165;
            int actual = ColourTranslator.ToArgb(1, 2, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenRgbaComponents_WhenCallingToArgb_ThenReturnsCorrectValue()
        {
            int expected = -16711165;
            int actual = ColourTranslator.ToArgb(1, 2, 3, 255);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenByteRgbComponents_WhenCallingToArgb_ThenReturnsCorrectValue()
        {
            int result = ColourTranslator.ToArgb((byte)1, (byte)2, (byte)3);

            Assert.That(result, Is.EqualTo(-16711165));
        }

        [Test]
        public void GivenByteArgbComponents_WhenCallingToArgb_ThenReturnsCorrectValue()
        {
            int result = ColourTranslator.ToArgb((byte)1, (byte)2, (byte)3, (byte)255);

            Assert.That(result, Is.EqualTo(-16711165));
        }
    }
}
