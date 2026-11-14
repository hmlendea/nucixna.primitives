using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using XnaVector2 = Microsoft.Xna.Framework.Vector2;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    [TestFixture]
    public class ScaleMappingExtensionsTests
    {
        [Test]
        public void GivenXnaVector2_WhenConvertingToScale2D_ThenValuesArePreserved()
        {
            XnaVector2 source = new(1.5f, 2.5f);
            Scale2D result = source.ToScale2D();

            Assert.That(result.Horizontal, Is.EqualTo(1.5f));
            Assert.That(result.Vertical, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenScale2D_WhenConvertingToXnaVector2_ThenValuesArePreserved()
        {
            Scale2D source = new(1.5f, 2.5f);
            XnaVector2 result = source.ToXnaVector2();

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(2.5f));
        }
        [Test]
        public void GivenScale2D_WhenRoundTrippingThroughXnaVector2_ThenValuesArePreserved()
        {
            Scale2D scale = new(1.5f, 2.5f);
            Scale2D result = scale.ToXnaVector2().ToScale2D();

            Assert.That(result, Is.EqualTo(scale));
        }
    }
}
