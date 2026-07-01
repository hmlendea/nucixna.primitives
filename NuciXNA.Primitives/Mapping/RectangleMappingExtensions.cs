using SystemRectangle = System.Drawing.Rectangle;
using XnaRectangle = Microsoft.Xna.Framework.Rectangle;

namespace NuciXNA.Primitives.Mapping
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="Rectangle2D"/> and related rectangle types
    /// from System.Drawing and Microsoft.Xna.Framework.
    /// </summary>
    public static class RectangleMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="SystemRectangle"/> to a <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemRectangle"/>.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        public static Rectangle2D ToRectangle2D(this SystemRectangle source)
            => new(source.X, source.Y, source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="XnaRectangle"/> to a <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaRectangle"/>.</param>
        /// <returns>The <see cref="Rectangle2D"/>.</returns>
        public static Rectangle2D ToRectangle2D(this XnaRectangle source)
            => new(source.X, source.Y, source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="Rectangle2D"/> to a <see cref="SystemRectangle"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Rectangle2D"/>.</param>
        /// <returns>The <see cref="SystemRectangle"/>.</returns>
        public static SystemRectangle ToSystemRectangle(this Rectangle2D source)
            => new(source.X, source.Y, source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="XnaRectangle"/> to a <see cref="SystemRectangle"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaRectangle"/>.</param>
        /// <returns>The <see cref="SystemRectangle"/>.</returns>
        public static SystemRectangle ToSystemRectangle(this XnaRectangle source)
            => new(source.X, source.Y, source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="Rectangle2D"/> to a <see cref="XnaRectangle"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Rectangle2D"/>.</param>
        /// <returns>The <see cref="XnaRectangle"/>.</returns>
        public static XnaRectangle ToXnaRectangle(this Rectangle2D source)
            => new(source.X, source.Y, source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="SystemRectangle"/> to a <see cref="XnaRectangle"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemRectangle"/>.</param>
        /// <returns>The <see cref="XnaRectangle"/>.</returns>
        public static XnaRectangle ToXnaRectangle(this SystemRectangle source)
            => new(source.X, source.Y, source.Width, source.Height);
    }
}
