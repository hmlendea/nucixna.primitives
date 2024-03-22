using System;

using NUnit.Framework;

using NuciXNA.Primitives;

namespace NuciXNA.UnitTests.Primitives
{
    public class ColourTests
    {
        [Test]
        public void Constructor_RGB_PropertiesSet()
        {
            Colour colour = new Colour(1, 2, 3);

            Assert.That(colour.R, Is.EqualTo(1));
            Assert.That(colour.G, Is.EqualTo(2));
            Assert.That(colour.B, Is.EqualTo(3));
            Assert.That(colour.A, Is.EqualTo(byte.MaxValue));
        }

        [Test]
        public void Constructor_RGBA_PropertiesSet()
        {
            Colour colour = new Colour(1, 2, 3, 4);

            Assert.That(colour.R, Is.EqualTo(1));
            Assert.That(colour.G, Is.EqualTo(2));
            Assert.That(colour.B, Is.EqualTo(3));
            Assert.That(colour.A, Is.EqualTo(4));
        }

        [Test]
        public void ToMonochromeAverage_ReturnsCorrectColour()
        {
            Colour colour = new Colour(8, 16, 24);
            Colour expected = new Colour(16, 16, 16);
            Colour actual = colour.ToMonochromeAverage();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToMonochromeDark_ReturnsCorrectColour()
        {
            Colour colour = new Colour(8, 16, 24);
            Colour expected = new Colour(8, 8, 8);
            Colour actual = colour.ToMonochromeDark();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToMonochromeLight_ReturnsCorrectColour()
        {
            Colour colour = new Colour(8, 16, 24);
            Colour expected = new Colour(24, 24, 24);
            Colour actual = colour.ToMonochromeLight();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsSimilarTo_ReturnsCorrectValue()
        {
            Colour colour1 = new Colour(8, 16, 24);
            Colour colour2 = new Colour(10, 18, 26);
            bool isSimilar = colour1.IsSimilarTo(colour2, 2);

            Assert.That(isSimilar);
        }

        [Test]
        public void Multiply_CalledWithValidFactor_ReturnsCorrectColour()
        {
            Colour colour = new Colour(8, 8, 8, 8);
            Colour expected = new Colour(16, 16, 16, 16);
            Colour actual = Colour.Multiply(colour, 2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiply_CalledWithHugeFactor_ReturnsWhiteColour()
        {
            Colour colour = new Colour(8, 8, 8, 8);
            Colour expected = new Colour(255, 255, 255, 255);
            Colour actual = Colour.Multiply(colour, 100);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiply_CalledWithNegativeFactor_ReturnsBlackColour()
        {
            Colour colour = new Colour(8, 8, 8, 8);
            Colour expected = new Colour(0, 0, 0, 0);
            Colour actual = Colour.Multiply(colour, -100);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_ReturnsCorrectValue()
        {
            Colour colour = new Colour(255, 0, 0);
            string expected = "#FF0000";
            string actual = colour.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_CalledWithColourWithSameRGB_ReturnsTrue()
        {
            Colour colour1 = new Colour(1, 2, 3);
            Colour colour2 = new Colour(1, 2, 3);

            Assert.That(colour1, Is.EqualTo(colour2));
        }

        [Test]
        public void Equals_CalledWithColourWithDifferentRGB_ReturnsFalse()
        {
            Colour colour1 = new Colour(1, 2, 3);
            Colour colour2 = new Colour(1, 2, 4);

            Assert.That(colour1, Is.Not.EqualTo(colour2));
        }

        [Test]
        public void Equals_CalledWithColourWithSameRGBA_ReturnsTrue()
        {
            Colour colour1 = new Colour(1, 2, 3, 4);
            Colour colour2 = new Colour(1, 2, 3, 4);

            Assert.That(colour1, Is.EqualTo(colour2));
        }

        [Test]
        public void Equals_CalledWithColourWithDifferentRGBA_ReturnsFalse()
        {
            Colour colour1 = new Colour(1, 2, 3, 4);
            Colour colour2 = new Colour(1, 2, 3, 5);

            Assert.That(colour1, Is.Not.EqualTo(colour2));
        }

        [Test]
        public void Equals_CalledWithHexStringWithSameValue_ReturnsTrue()
        {
            Colour colour = new Colour(255, 0, 255);

            Assert.That(colour.Equals("#FF00FF"));
        }

        [Test]
        public void Equals_CalledWithUnrelatedObject_Returnsfalse()
        {
            Colour colour = new Colour(255, 0, 255);

            Assert.That(colour, Is.Not.EqualTo(DateTime.Now));
        }

        [Test]
        public void MultiplyOperator_ReturnsCorrectColour()
        {
            Colour colour = new Colour(8, 8, 8, 8);
            Colour expected = new Colour(16, 16, 16, 16);
            Colour actual = colour * 2;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplyOperator_MultiplyWithHugeFactor_ReturnsWhiteColour()
        {
            Colour colour = new Colour(8, 8, 8, 8);
            Colour expected = new Colour(255, 255, 255, 255);
            Colour actual = colour * 100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplyOperator_MultiplyWithNegativeFactor_ReturnsBlackColour()
        {
            Colour colour = new Colour(8, 8, 8, 8);
            Colour expected = new Colour(0, 0, 0, 0);
            Colour actual = colour * -1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsOperator_CalledWithSameColour_ReturnsTrue()
        {
            Colour me = Colour.Black;
            Colour other = Colour.Black;

            Assert.That(me == other);
        }

        [Test]
        public void EqualsOperator_CalledWithDifferentColour_ReturnsFalse()
        {
            Colour me = Colour.Black;
            Colour other = Colour.White;

            Assert.That(me == other, Is.False);
        }

        [Test]
        public void EqualsOperator_CalledWithNull_ReturnsFalse()
        {
            Colour me = Colour.Black;

            Assert.That(me == null, Is.False);
        }

        [Test]
        public void EqualsOperator_CurrentIsNull_ReturnsFalse()
        {
            Colour other = Colour.White;

            Assert.That(null == other, Is.False);
        }
    }
}
