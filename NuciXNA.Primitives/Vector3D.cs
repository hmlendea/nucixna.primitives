using System;

using Microsoft.Xna.Framework;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 3D vector structure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Vector3D"/> structure.
    /// </remarks>
    /// <param name="x">The X-axis coordinate.</param>
    /// <param name="y">The Y-axis coordinate.</param>
    /// <param name="z">The Z-axis coordinate.</param>
    public struct Vector3D(float x, float y, float z) : IEquatable<Vector3D>
    {
        /// <summary>
        /// Gets or sets the X-axis coordinate.
        /// </summary>
        /// <value>The X-axis coordinate.</value>
        public float X { get; set; } = x;

        /// <summary>
        /// Gets or sets the Y-axis coordinate.
        /// </summary>
        /// <value>The Y-axis coordinate.</value>
        public float Y { get; set; } = y;

        /// <summary>
        /// Gets or sets the Z-axis coordinate.
        /// </summary>
        /// <value>The Z-axis coordinate.</value>
        public float Z { get; set; } = z;

        /// <summary>
        /// Gets a value indicating whether the coordinates of this <see cref="Vector3D"/> are zero.
        /// </summary>
        /// <value><c>true</c> if the values are zero; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => X == 0 && Y == 0;

        public static Vector3D Zero => new(0, 0, 0);
        public static Vector3D One => new(1, 1, 1);

        /// <summary>
        /// Determines whether the specified <see cref="Vector3D"/> is equal to the current <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Vector3D"/> to compare with the current <see cref="Vector3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Vector3D"/> is equal to the current <see cref="Vector3D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Vector3D other) =>
            Equals(X, other.X) &&
            Equals(Y, other.Y) &&
            Equals(Z, other.Z);

        public readonly bool Equals(float x, float y, float z) =>
            X.Equals(x) &&
            Y.Equals(y) &&
            Z.Equals(z);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Vector3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Vector3D"/>; otherwise, <c>false</c>.</returns>
        public override readonly bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Vector3D)obj);
        }

        /// <summary>
        /// Adds the values of a <see cref="Vector3D"/> to those of another <see cref="Vector3D"/>,
        /// yielding a new <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector3D"/> to add.</param>
        /// <param name="other">The second <see cref="Vector3D"/> to add.</param>
        /// <returns>The <see cref="Vector3D"/> whose values are the sum of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector3D operator +(Vector3D source, Vector3D other) => new(
            source.X + other.X,
            source.Y + other.Y,
            source.Z + other.Z);

        /// <summary>
        /// Subtracts the values of a <see cref="Vector3D"/> from those of another <see cref="Vector3D"/>,
        /// yielding a new <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector3D"/> to subtract.</param>
        /// <param name="other">The second <see cref="Vector3D"/> to subtract.</param>
        /// <returns>The <see cref="Vector3D"/> whose values are the sum of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector3D operator -(Vector3D source, Vector3D other) => new(
            source.X - other.X,
            source.Y - other.Y,
            source.Z - other.Z);

        /// <summary>
        /// Multiples the values of a <see cref="Vector3D"/> from those of another <see cref="Vector3D"/>,
        /// yielding a new <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector3D"/> to multiply.</param>
        /// <param name="other">The second <see cref="Vector3D"/> to multiply.</param>
        /// <returns>The <see cref="Vector3D"/> whose values are the produce of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector3D operator *(Vector3D source, Vector3D other) => new(
            source.X * other.X,
            source.Y * other.Y,
            source.Z * other.Z);

        /// <summary>
        /// Divides the values of a <see cref="Vector3D"/> from those of another <see cref="Vector3D"/>,
        /// yielding a new <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector3D"/> to divide.</param>
        /// <param name="other">The second <see cref="Vector3D"/> to divide.</param>
        /// <returns>The <see cref="Vector3D"/> whose values are the division of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector3D operator /(Vector3D source, Vector3D other) => new(
            source.X / other.X,
            source.Y / other.Y,
            source.Z / other.Z);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vector3D"/> is equal to another specified <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector3D"/> to compare.</param>
        /// <param name="other">The second <see cref="Vector3D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vector3D source, Vector3D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vector3D"/> is not equal to
        /// another specified <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector3D"/> to compare.</param>
        /// <param name="other">The second <see cref="Vector3D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vector3D source, Vector3D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Vector3D"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^
                        Y.GetHashCode() ^
                        Z.GetHashCode();
            }
        }

        public static implicit operator Vector3(Vector3D source) => new(source.X, source.Y, source.Z);

        public static implicit operator Vector3D(Vector3 source) => new(source.X, source.Y, source.Z);
    }
}
