using System;
using System.Drawing;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D orthogonal coordinates structure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="PointF2D"/> structure.
    /// </remarks>
    /// <param name="x">The X-axis coordinate.</param>
    /// <param name="y">The Y-axis coordinate.</param>
    public struct PointF2D(float x, float y) : IEquatable<PointF2D>
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
        /// Gets a value indicating whether the coordinates of this <see cref="PointF2D"/> are zero.
        /// </summary>
        /// <value><c>true</c> if the coorinates are zero; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => X.Equals(0) && Y.Equals(0);

        /// <summary>
        /// Gets a <see cref="PointF2D"/> with the coordinates of zero.
        /// </summary>
        /// <value>The orthogonal centre point.</value>
        public static PointF2D Empty => new(0, 0);

        public PointF2D(Point2D point) : this(point.X, point.Y) { }
        public PointF2D(SizeF2D size) : this(size.Width, size.Height) { }
        public PointF2D(Size2D size) : this(size.Width, size.Height) { }

        /// <summary>
        /// Determines whether the specified <see cref="PointF2D"/> is equal to the current <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="PointF2D"/> to compare with the current <see cref="PointF2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="PointF2D"/> is equal to the current <see cref="PointF2D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(PointF2D other)
            => Equals(X, other.X) && Equals(Y, other.Y);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="PointF2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="PointF2D"/>; otherwise, <c>false</c>.</returns>
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

            return Equals((PointF2D)obj);
        }

        public readonly bool Equals(float x, float y)
            => X.Equals(x) && Y.Equals(y);

        /// <summary>
        /// Adds the coordinates of a <see cref="PointF2D"/> to those of another <see cref="PointF2D"/>,
        /// yielding a new <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="PointF2D"/> to add.</param>
        /// <param name="other">The second <see cref="PointF2D"/> to add.</param>
        /// <returns>The <see cref="PointF2D"/> whose coordinates are the sum of the coordinates of <c>source</c> and <c>other</c>.</returns>
        public static PointF2D operator +(PointF2D source, PointF2D other) => new(
            source.X + other.X,
            source.Y + other.Y);

        /// <summary>
        /// Subtracts the coordinates of a <see cref="PointF2D"/> from those of another <see cref="PointF2D"/>,
        /// yielding a new <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="PointF2D"/> to subtract.</param>
        /// <param name="other">The second <see cref="PointF2D"/> to subtract.</param>
        /// <returns>The <see cref="PointF2D"/> whose coordinates are the sum of the coordinates of <c>source</c> and <c>other</c>.</returns>
        public static PointF2D operator -(PointF2D source, PointF2D other) => new(
            source.X - other.X,
            source.Y - other.Y);

        /// <summary>
        /// Multiples the values of a <see cref="PointF2D"/> from those of another <see cref="PointF2D"/>,
        /// yielding a new <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="PointF2D"/> to multiply.</param>
        /// <param name="other">The second <see cref="PointF2D"/> to multiply.</param>
        /// <returns>The <see cref="PointF2D"/> whose values are the produce of the values of <c>source</c> and <c>other</c>.</returns>
        public static PointF2D operator *(PointF2D source, PointF2D other) => new(
            source.X * other.X,
            source.Y * other.Y);

        /// <summary>
        /// Divides the values of a <see cref="PointF2D"/> from those of another <see cref="PointF2D"/>,
        /// yielding a new <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="PointF2D"/> to divide.</param>
        /// <param name="other">The second <see cref="PointF2D"/> to divide.</param>
        /// <returns>The <see cref="PointF2D"/> whose values are the division of the values of <c>source</c> and <c>other</c>.</returns>
        public static PointF2D operator /(PointF2D source, PointF2D other) => new(
            source.X / other.X,
            source.Y / other.Y);

        public static PointF2D operator *(PointF2D source, float other) => new(
            source.X * other,
            source.Y * other);

        public static PointF2D operator /(PointF2D source, float other) => new(
            source.X / other,
            source.Y / other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="PointF2D"/> is equal to another specified <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="PointF2D"/> to compare.</param>
        /// <param name="other">The second <see cref="PointF2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PointF2D source, PointF2D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="PointF2D"/> is not equal to
        /// another specified <see cref="PointF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="PointF2D"/> to compare.</param>
        /// <param name="other">The second <see cref="PointF2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PointF2D source, PointF2D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="PointF2D"/> object.
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

        public static implicit operator PointF(PointF2D source) => new(source.X, source.Y);

        public static implicit operator PointF2D(PointF source) => new(source.X, source.Y);
    }
}
