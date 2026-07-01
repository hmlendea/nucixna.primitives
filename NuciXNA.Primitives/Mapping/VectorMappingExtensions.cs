using Microsoft.Xna.Framework;

namespace NuciXNA.Primitives.Mapping
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="Vector2D"/>, <see cref="Vector3D"/>,
    /// and the corresponding Microsoft.Xna.Framework vector types.
    /// </summary>
    public static class VectorMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="Vector2"/> to a <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Vector2"/>.</param>
        /// <returns>The <see cref="Vector2D"/>.</returns>
        public static Vector2D ToVector2D(this Vector2 source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Vector3"/> to a <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Vector3"/>.</param>
        /// <returns>The <see cref="Vector3D"/>.</returns>
        public static Vector3D ToVector3D(this Vector3 source) => new(source.X, source.Y, source.Z);

        /// <summary>
        /// Converts a <see cref="Vector2D"/> to a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Vector2D"/>.</param>
        /// <returns>The <see cref="Vector2"/>.</returns>
        public static Vector2 ToXnaVector(this Vector2D source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Vector3D"/> to a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Vector3D"/>.</param>
        /// <returns>The <see cref="Vector3"/>.</returns>
        public static Vector3 ToXnaVector(this Vector3D source) => new(source.X, source.Y, source.Z);
    }
}
