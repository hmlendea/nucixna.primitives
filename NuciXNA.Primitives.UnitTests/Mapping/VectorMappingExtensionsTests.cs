using NUnit.Framework;

using NuciXNA.Primitives.Mapping;

using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace NuciXNA.Primitives.UnitTests.Mapping
{
    [TestFixture]
    public class VectorMappingExtensionsTests
    {
        [Test]
        public void GivenVector2_WhenConvertingToVector2D_ThenValuesArePreserved()
        {
            Vector2 source = new(1.5f, 2.5f);
            Vector2D result = source.ToVector2D();

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenVector3_WhenConvertingToVector3D_ThenValuesArePreserved()
        {
            Vector3 source = new(1.5f, 2.5f, 3.5f);
            Vector3D result = source.ToVector3D();

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(2.5f));
            Assert.That(result.Z, Is.EqualTo(3.5f));
        }

        [Test]
        public void GivenVector2D_WhenConvertingToXnaVector_ThenValuesArePreserved()
        {
            Vector2D source = new(1.5f, 2.5f);
            Vector2 result = source.ToXnaVector();

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(2.5f));
        }

        [Test]
        public void GivenVector3D_WhenConvertingToXnaVector_ThenValuesArePreserved()
        {
            Vector3D source = new(1.5f, 2.5f, 3.5f);
            Vector3 result = source.ToXnaVector();

            Assert.That(result.X, Is.EqualTo(1.5f));
            Assert.That(result.Y, Is.EqualTo(2.5f));
            Assert.That(result.Z, Is.EqualTo(3.5f));
        }
        [Test]
        public void GivenVector2D_WhenRoundTrippingThroughXnaVector2_ThenValuesArePreserved()
        {
            Vector2D vector = new(1.5f, 2.5f);
            Vector2D result = vector.ToXnaVector().ToVector2D();

            Assert.That(result, Is.EqualTo(vector));
        }

        [Test]
        public void GivenVector3D_WhenRoundTrippingThroughXnaVector3_ThenValuesArePreserved()
        {
            Vector3D vector = new(1.5f, 2.5f, 3.5f);
            Vector3D result = vector.ToXnaVector().ToVector3D();

            Assert.That(result, Is.EqualTo(vector));
        }
    }
}
