using System;

using Microsoft.Xna.Framework;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D vector structure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Vector2D"/> structure.
    /// </remarks>
    /// <param name="xCoordinate">The X-axis value.</param>
    /// <param name="yCoordinate">The Y-axis value.</param>
    public struct Vector2D(float xCoordinate, float yCoordinate) : IEquatable<Vector2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/> to copy the X and Y values from.</param>
        public Vector2D(Point2D point) : this(point.X, point.Y) { }

        /// <summary>
        /// Gets or sets the X-axis value.
        /// </summary>
        /// <value>The X-axis value.</value>
        public float X { get; set; } = xCoordinate;

        /// <summary>
        /// Gets or sets the Y-axis value.
        /// </summary>
        /// <value>The Y-axis value.</value>
        public float Y { get; set; } = yCoordinate;

        /// <summary>
        /// Gets a value indicating whether the values of this <see cref="Vector2D"/> are zero.
        /// </summary>
        /// <value><c>true</c> if the coorinates are zero; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => object.Equals(X, 0f) && object.Equals(Y, 0f);

        /// <summary>
        /// Gets a <see cref="Vector2D"/> with the values of zero.
        /// </summary>
        public static Vector2D Zero => new(0, 0);

        /// <summary>
        /// Gets a <see cref="Vector2D"/> with the values of one.
        /// </summary>
        public static Vector2D One => new(1, 1);

        /// <summary>
        /// Determines whether the specified <see cref="Vector2D"/> is equal to the current <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Vector2D"/> to compare with the current <see cref="Vector2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Vector2D"/> is equal to the current <see cref="Vector2D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Vector2D other) =>
            object.Equals(X, other.X) &&
            object.Equals(Y, other.Y);

        /// <summary>
        /// Determines whether the specified <see cref="float"/> values are equal to the current <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="xCoordinate">The X-axis value.</param>
        /// <param name="yCoordinate">The Y-axis value.</param>
        /// <returns><c>true</c> if the specified <see cref="float"/> values are equal to the current <see cref="Vector2D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(float xCoordinate, float yCoordinate) =>
            object.Equals(X, xCoordinate) &&
            object.Equals(Y, yCoordinate);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Vector2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Vector2D"/>; otherwise, <c>false</c>.</returns>
        public override readonly bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!Equals(obj.GetType(), GetType()))
            {
                return false;
            }

            return Equals((Vector2D)obj);
        }

        /// <summary>
        /// Adds the values of a <see cref="Vector2D"/> to those of another <see cref="Vector2D"/>,
        /// yielding a new <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector2D"/> to add.</param>
        /// <param name="other">The second <see cref="Vector2D"/> to add.</param>
        /// <returns>The <see cref="Vector2D"/> whose values are the sum of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector2D operator +(Vector2D source, Vector2D other) => new(
            source.X + other.X,
            source.Y + other.Y);

        /// <summary>
        /// Subtracts the values of a <see cref="Vector2D"/> from those of another <see cref="Vector2D"/>,
        /// yielding a new <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector2D"/> to subtract.</param>
        /// <param name="other">The second <see cref="Vector2D"/> to subtract.</param>
        /// <returns>The <see cref="Vector2D"/> whose values are the subtraction of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector2D operator -(Vector2D source, Vector2D other) => new(
            source.X - other.X,
            source.Y - other.Y);

        /// <summary>
        /// Multiplies the values of a <see cref="Vector2D"/> by those of another <see cref="Vector2D"/>,
        /// yielding a new <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector2D"/> to multiply.</param>
        /// <param name="other">The second <see cref="Vector2D"/> to multiply.</param>
        /// <returns>The <see cref="Vector2D"/> whose values are the product of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector2D operator *(Vector2D source, Vector2D other) => new(
            source.X * other.X,
            source.Y * other.Y);

        /// <summary>
        /// Divides the values of a <see cref="Vector2D"/> by those of another <see cref="Vector2D"/>,
        /// yielding a new <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector2D"/> to divide.</param>
        /// <param name="other">The second <see cref="Vector2D"/> to divide by.</param>
        /// <returns>The <see cref="Vector2D"/> whose values are the quotient of the values of <c>source</c> and <c>other</c>.</returns>
        public static Vector2D operator /(Vector2D source, Vector2D other) => new(
            source.X / other.X,
            source.Y / other.Y);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vector2D"/> is equal to another specified <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Vector2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vector2D source, Vector2D other)
            => Equals(source, other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vector2D"/> is not equal to
        /// another specified <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Vector2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Vector2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vector2D source, Vector2D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Vector2D"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^
                        Y.GetHashCode();
            }
        }

        /// <summary>
        /// Converts a <see cref="Vector2D"/> to a <see cref="Vector2"/> implicitly.
        /// </summary>
        /// <param name="source">The <see cref="Vector2D"/> to convert.</param>
        public static implicit operator Vector2(Vector2D source) => new(source.X, source.Y);

        /// <summary>
        /// Converts a <see cref="Vector2"/> to a <see cref="Vector2D"/> implicitly.
        /// </summary>
        /// <param name="source">The <see cref="Vector2"/> to convert.</param>
        /// <returns>A <see cref="Vector2D"/> that represents the specified <see cref="Vector2"/>.</returns>
        public static implicit operator Vector2D(Vector2 source) => new(source.X, source.Y);
    }
}
