using SystemPoint = System.Drawing.Point;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using XnaPoint = Microsoft.Xna.Framework.Point;

namespace NuciXNA.Primitives.Mapping
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="Point2D"/> and related point types
    /// from System.Drawing and Microsoft.Xna.Framework.
    /// </summary>
    public static class PointMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="SystemPoint"/> to a <see cref="Point2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemPoint"/>.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        public static Point2D ToPoint2D(this SystemPoint source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Vector2"/> to a <see cref="Point2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Vector2"/>.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        public static Point2D ToPoint2D(this Vector2 source) => new((int)source.X, (int)source.Y);

        /// <summary>
        /// Converts a <see cref="XnaPoint"/> to a <see cref="Point2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaPoint"/>.</param>
        /// <returns>The <see cref="Point2D"/>.</returns>
        public static Point2D ToPoint2D(this XnaPoint source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Point2D"/> to a <see cref="SystemPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point2D"/>.</param>
        /// <returns>The <see cref="SystemPoint"/>.</returns>
        public static SystemPoint ToSystemPoint(this Point2D source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Vector2"/> to a <see cref="SystemPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Vector2"/>.</param>
        /// <returns>The <see cref="SystemPoint"/>.</returns>
        public static SystemPoint ToSystemPoint(this Vector2 source) => new((int)source.X, (int)source.Y);

        /// <summary>
        /// Converts a <see cref="XnaPoint"/> to a <see cref="SystemPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="XnaPoint"/>.</param>
        /// <returns>The <see cref="SystemPoint"/>.</returns>
        public static SystemPoint ToSystemPoint(this XnaPoint source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="SystemPoint"/> to a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemPoint"/>.</param>
        /// <returns>The <see cref="Vector2"/>.</returns>
        public static Vector2 ToXnaVector2(this SystemPoint source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Point2D"/> to a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point2D"/>.</param>
        /// <returns>The <see cref="Vector2"/>.</returns>
        public static Vector2 ToXnaVector2(this Point2D source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Point2D"/> to a <see cref="XnaPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point2D"/>.</param>
        /// <returns>The <see cref="XnaPoint"/>.</returns>
        public static XnaPoint ToXnaPoint(this Point2D source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="SystemPoint"/> to a <see cref="XnaPoint"/>.
        /// </summary>
        /// <param name="source">Source <see cref="SystemPoint"/>.</param>
        /// <returns>The <see cref="XnaPoint"/>.</returns>
        public static XnaPoint ToXnaPoint(this SystemPoint source) => new(source.X, source.Y);
    }
}
