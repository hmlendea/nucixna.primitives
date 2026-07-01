using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using SystemColor = System.Drawing.Color;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    public class ColourMappingExtensionsTests
    {
        [Test]
        public void GivenSystemColor_WhenConvertingToColour_ThenChannelsArePreserved()
        {
            SystemColor source = SystemColor.FromArgb(128, 10, 20, 30);
            Colour result = source.ToColour();

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenXnaColor_WhenConvertingToColour_ThenChannelsArePreserved()
        {
            XnaColor source = new(10, 20, 30, 128);
            Colour result = source.ToColour();

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenColour_WhenConvertingToSystemColor_ThenChannelsArePreserved()
        {
            Colour source = new(10, 20, 30, 128);
            SystemColor result = source.ToSystemColor();

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenXnaColor_WhenConvertingToSystemColor_ThenChannelsArePreserved()
        {
            XnaColor source = new(10, 20, 30, 128);
            SystemColor result = source.ToSystemColor();

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenColour_WhenConvertingToXnaColor_ThenChannelsArePreserved()
        {
            Colour source = new(10, 20, 30, 128);
            XnaColor result = source.ToXnaColor();

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenSystemColor_WhenConvertingToXnaColor_ThenChannelsArePreserved()
        {
            SystemColor source = SystemColor.FromArgb(128, 10, 20, 30);
            XnaColor result = source.ToXnaColor();

            Assert.That(result.A, Is.EqualTo(128));
            Assert.That(result.R, Is.EqualTo(10));
            Assert.That(result.G, Is.EqualTo(20));
            Assert.That(result.B, Is.EqualTo(30));
        }

        [Test]
        public void GivenSystemColorArray_WhenConvertingToColours_ThenAllElementsAreConverted()
        {
            SystemColor[] source =
            [
                SystemColor.FromArgb(255, 255, 0, 0),
                SystemColor.FromArgb(255, 0, 255, 0),
            ];

            Colour[] result = source.ToColours();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.That(result[0].R, Is.EqualTo(255));
            Assert.That(result[0].G, Is.EqualTo(0));
            Assert.That(result[1].R, Is.EqualTo(0));
            Assert.That(result[1].G, Is.EqualTo(255));
        }

        [Test]
        public void GivenXnaColorArray_WhenConvertingToColours_ThenAllElementsAreConverted()
        {
            XnaColor[] source = [new(255, 0, 0, 255), new(0, 255, 0, 255)];

            Colour[] result = source.ToColours();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.That(result[0].R, Is.EqualTo(255));
            Assert.That(result[1].G, Is.EqualTo(255));
        }

        [Test]
        public void GivenXnaColorArray_WhenConvertingToSystemColors_ThenAllElementsAreConverted()
        {
            XnaColor[] source = [new(10, 20, 30, 128), new(40, 50, 60, 200)];

            SystemColor[] result = source.ToSystemColors();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.That(result[0].R, Is.EqualTo(10));
            Assert.That(result[1].R, Is.EqualTo(40));
        }

        [Test]
        public void GivenColourArray_WhenConvertingToSystemColors_ThenAllElementsAreConverted()
        {
            Colour[] source = [new(10, 20, 30, 128), new(40, 50, 60, 200)];

            SystemColor[] result = source.ToSystemColors();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.That(result[0].R, Is.EqualTo(10));
            Assert.That(result[1].R, Is.EqualTo(40));
        }

        [Test]
        public void GivenColourArray_WhenConvertingToXnaColors_ThenAllElementsAreConverted()
        {
            Colour[] source = [new(10, 20, 30, 128), new(40, 50, 60, 200)];

            XnaColor[] result = source.ToXnaColors();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.That(result[0].R, Is.EqualTo(10));
            Assert.That(result[1].R, Is.EqualTo(40));
        }

        [Test]
        public void GivenSystemColorArray_WhenConvertingToXnaColors_ThenAllElementsAreConverted()
        {
            SystemColor[] source =
            [
                SystemColor.FromArgb(255, 10, 20, 30),
                SystemColor.FromArgb(200, 40, 50, 60),
            ];

            XnaColor[] result = source.ToXnaColors();

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.That(result[0].R, Is.EqualTo(10));
            Assert.That(result[1].R, Is.EqualTo(40));
        }
    }
}
