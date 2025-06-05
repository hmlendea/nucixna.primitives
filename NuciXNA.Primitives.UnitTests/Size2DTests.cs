using NUnit.Framework;

namespace NuciXNA.Primitives.UnitTests
{
    public class Size2DTests
    {
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
    }
}
