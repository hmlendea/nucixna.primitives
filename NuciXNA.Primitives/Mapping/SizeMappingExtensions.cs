using SystemSize = System.Drawing.Size;
using XnaPoint = Microsoft.Xna.Framework.Point;

namespace NuciXNA.Primitives.Mapping
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="Size2D"/> and related size types
    /// from System.Drawing and Microsoft.Xna.Framework.
    /// </summary>
    public static class SizeMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="SystemSize"/> to a <see cref="Size2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemSize"/>.</param>
        /// <returns>The <see cref="Size2D"/>.</returns>
        public static Size2D ToSize2D(this SystemSize source) => new(source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="XnaPoint"/> to a <see cref="Size2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaPoint"/>.</param>
        /// <returns>The <see cref="Size2D"/>.</returns>
        public static Size2D ToSize2D(this XnaPoint source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Size2D"/> to a <see cref="SystemSize"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Size2D"/>.</param>
        /// <returns>The <see cref="SystemSize"/>.</returns>
        public static SystemSize ToSystemSize(this Size2D source) => new(source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="XnaPoint"/> to a <see cref="SystemSize"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaPoint"/>.</param>
        /// <returns>The <see cref="SystemSize"/>.</returns>
        public static SystemSize ToSystemSize(this XnaPoint source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Size2D"/> to a <see cref="XnaPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Size2D"/>.</param>
        /// <returns>The <see cref="XnaPoint"/>.</returns>
        public static XnaPoint ToXnaPoint(this Size2D source) => new(source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="SystemSize"/> to a <see cref="XnaPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemSize"/>.</param>
        /// <returns>The <see cref="XnaPoint"/>.</returns>
        public static XnaPoint ToXnaPoint(this SystemSize source) => new(source.Width, source.Height);
    }
}
