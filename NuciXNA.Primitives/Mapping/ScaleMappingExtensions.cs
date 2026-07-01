using XnaVector2 = Microsoft.Xna.Framework.Vector2;

namespace NuciXNA.Primitives.Mapping
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="Scale2D"/> and related types
    /// from Microsoft.Xna.Framework.
    /// </summary>
    public static class ScaleMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="XnaVector2"/> to a <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaVector2"/>.</param>
        /// <returns>The <see cref="Scale2D"/>.</returns>
        public static Scale2D ToScale2D(this XnaVector2 source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Scale2D"/> to a <see cref="XnaVector2"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Scale2D"/>.</param>
        /// <returns>The <see cref="XnaVector2"/>.</returns>
        public static XnaVector2 ToXnaVector2(this Scale2D source) => new(source.Horizontal, source.Vertical);
    }
}
