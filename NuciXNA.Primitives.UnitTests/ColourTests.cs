using System;

using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class ColourTests
    {
        [Test]
        public void Constructor_RGB_PropertiesSet()
        {
            Colour colour = new(1, 2, 3);

            Assert.That(colour.R, Is.EqualTo(1));
            Assert.That(colour.G, Is.EqualTo(2));
            Assert.That(colour.B, Is.EqualTo(3));
            Assert.That(colour.A, Is.EqualTo(byte.MaxValue));
        }

        [Test]
        public void Constructor_RGBA_PropertiesSet()
        {
            Colour colour = new(1, 2, 3, 4);

            Assert.That(colour.R, Is.EqualTo(1));
            Assert.That(colour.G, Is.EqualTo(2));
            Assert.That(colour.B, Is.EqualTo(3));
            Assert.That(colour.A, Is.EqualTo(4));
        }

        [Test]
        public void ToMonochromeAverage_ReturnsCorrectColour()
        {
            Colour colour = new(8, 16, 24);
            Colour expected = new(16, 16, 16);
            Colour actual = colour.ToMonochromeAverage();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToMonochromeDark_ReturnsCorrectColour()
        {
            Colour colour = new(8, 16, 24);
            Colour expected = new(8, 8, 8);
            Colour actual = colour.ToMonochromeDark();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToMonochromeLight_ReturnsCorrectColour()
        {
            Colour colour = new(8, 16, 24);
            Colour expected = new(24, 24, 24);
            Colour actual = colour.ToMonochromeLight();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsSimilarTo_ReturnsCorrectValue()
        {
            Colour colour1 = new(8, 16, 24);
            Colour colour2 = new(10, 18, 26);
            bool isSimilar = colour1.IsSimilarTo(colour2, 2);

            Assert.That(isSimilar);
        }

        [Test]
        public void Multiply_CalledWithValidFactor_ReturnsCorrectColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(16, 16, 16, 16);
            Colour actual = Colour.Multiply(colour, 2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiply_CalledWithHugeFactor_ReturnsWhiteColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(255, 255, 255, 255);
            Colour actual = Colour.Multiply(colour, 100);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiply_CalledWithNegativeFactor_ReturnsBlackColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(0, 0, 0, 0);
            Colour actual = Colour.Multiply(colour, -100);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_ReturnsCorrectValue()
        {
            Colour colour = new(255, 0, 0);
            string expected = "#FF0000";
            string actual = colour.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_CalledWithColourWithSameRGB_ReturnsTrue()
            => Assert.That(new Colour(1, 2, 3), Is.EqualTo(new Colour(1, 2, 3)));

        [Test]
        public void Equals_CalledWithColourWithDifferentRGB_ReturnsFalse()
        {
            Colour colour1 = new(1, 2, 3);
            Colour colour2 = new(1, 2, 4);

            Assert.That(colour1, Is.Not.EqualTo(colour2));
        }

        [Test]
        public void Equals_CalledWithColourWithSameRGBA_ReturnsTrue()
            => Assert.That(new Colour(1, 2, 3, 4), Is.EqualTo(new Colour(1, 2, 3, 4)));

        [Test]
        public void Equals_CalledWithColourWithDifferentRGBA_ReturnsFalse()
            => Assert.That(new Colour(1, 2, 3, 4), Is.Not.EqualTo(new Colour(1, 2, 3, 5)));

        [Test]
        public void Equals_CalledWithHexStringWithSameValue_ReturnsTrue()
            => Assert.That(new Colour(255, 0, 255).Equals("#FF00FF"));

        [Test]
        public void Equals_CalledWithUnrelatedObject_Returnsfalse()
            => Assert.That(new Colour(255, 0, 255), Is.Not.EqualTo(DateTime.Now));

        [Test]
        public void MultiplyOperator_ReturnsCorrectColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(16, 16, 16, 16);
            Colour actual = colour * 2;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplyOperator_MultiplyWithHugeFactor_ReturnsWhiteColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(255, 255, 255, 255);
            Colour actual = colour * 100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplyOperator_MultiplyWithNegativeFactor_ReturnsBlackColour()
        {
            Colour colour = new(8, 8, 8, 8);
            Colour expected = new(0, 0, 0, 0);
            Colour actual = colour * -1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsOperator_CalledWithSameColour_ReturnsTrue()
            => Assert.That(Colour.Black == Colour.Black);

        [Test]
        public void EqualsOperator_CalledWithDifferentColour_ReturnsFalse()
            => Assert.That(Colour.Black == Colour.White, Is.False);

        [Test]
        public void EqualsOperator_CalledWithNull_ReturnsFalse()
            => Assert.That(Colour.Black == null, Is.False);

        [Test]
        public void EqualsOperator_CurrentIsNull_ReturnsFalse()
            => Assert.That(Colour.White == null, Is.False);
    }
}
