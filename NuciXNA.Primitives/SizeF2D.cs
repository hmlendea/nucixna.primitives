using System;
using System.Drawing;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D size structure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SizeF2D"/> structure.
    /// </remarks>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public struct SizeF2D(float width, float height) : IEquatable<SizeF2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SizeF2D"/> structure.
        /// </summary>
        /// <param name="size">Size.</param>
        public SizeF2D(float size) : this(size, size) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeF2D"/> structure.
        /// </summary>
        /// <param name="size">Size.</param>
        public SizeF2D(int size) : this(size, size) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeF2D"/> structure.
        /// </summary>
        /// <param name="point">Point.</param>
        public SizeF2D(PointF2D point) : this(point.X, point.Y) { }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public float Width { get; set; } = width;

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public float Height { get; set; } = height;

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>The area.</value>
        public readonly double Area => Width * Height;

        /// <summary>
        /// Gets the perimeter.
        /// </summary>
        public readonly double Perimeter => Width * 2 + Height * 2;

        /// <summary>
        /// Gets a value indicating whether this <see cref="SizeF2D"/> is zero.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => Width.Equals(0) && Height.Equals(0);

        /// <summary>
        /// Gets the size of zero.
        /// </summary>
        /// <value>The size of zero.</value>
        public static SizeF2D Empty => new(0, 0);

        /// <summary>
        /// Determines whether the specified <see cref="SizeF2D"/> is equal to the current <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="SizeF2D"/> to compare with the current <see cref="SizeF2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="SizeF2D"/> is equal to the current <see cref="SizeF2D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(SizeF2D other) =>
            Equals(Width, other.Width) &&
            Equals(Height, other.Height);

        /// <summary>
        /// Determines whether the specified width and height are equal to the current <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns><c>true</c> if the specified width and height are equal to the current <see cref="SizeF2D"/>;
        public readonly bool Equals(float width, float height) =>
            Width.Equals(width) &&
            Height.Equals(height);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="SizeF2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="SizeF2D"/>;
        /// otherwise, <c>false</c>.</returns>
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

            return Equals((SizeF2D)obj);
        }

        /// <summary>
        /// Adds the values of a <see cref="SizeF2D"/> to those of another <see cref="SizeF2D"/>,
        /// yielding a new <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="SizeF2D"/> to add.</param>
        /// <param name="other">The second <see cref="SizeF2D"/> to add.</param>
        /// <returns>The <see cref="SizeF2D"/> that is the sum of the values of <c>source</c> and <c>other</c>.</returns>
        public static SizeF2D operator +(SizeF2D source, SizeF2D other) => new(
            source.Width + other.Width,
            source.Height + other.Height);

        /// <summary>
        /// Subtracts the values of a <see cref="SizeF2D"/> from those of another <see cref="SizeF2D"/>,
        /// yielding a new <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="SizeF2D"/> to subtract.</param>
        /// <param name="other">The second <see cref="SizeF2D"/> to subtract.</param>
        /// <returns>The <see cref="SizeF2D"/> that is the subtraction of the values of <c>other</c> from <c>source</c>.</returns>
        public static SizeF2D operator -(SizeF2D source, SizeF2D other) => new(
            source.Width - other.Width,
            source.Height - other.Height);

        /// <summary>
        /// Multiplies the values of a <see cref="SizeF2D"/> from those of another <see cref="SizeF2D"/>,
        /// </summary>
        /// <param name="source">The first <see cref="SizeF2D"/> to multiply.</param>
        /// <param name="other">The second <see cref="SizeF2D"/> to multiply.</param>
        /// <returns>The <see cref="SizeF2D"/> whose values are the product of the values of <c>source</c> and <c>other</c>.</returns>
        public static SizeF2D operator *(SizeF2D source, SizeF2D other) => new(
            source.Width * other.Width,
            source.Height * other.Height);

        /// <summary>
        /// Divides the values of a <see cref="SizeF2D"/> from those of another <see cref="SizeF2D"/>,
        /// </summary>
        /// <param name="source">The first <see cref="SizeF2D"/> to divide.</param>
        /// <param name="other">The second <see cref="SizeF2D"/> to divide.</param>
        /// <returns>The <see cref="SizeF2D"/> whose values are the quotient of the values of <c>source</c> and <c>other</c>.</returns>
        public static SizeF2D operator /(SizeF2D source, SizeF2D other) => new(
            source.Width / other.Width,
            source.Height / other.Height);

        /// <summary>
        /// Multiplies the values of a <see cref="SizeF2D"/> by a scalar value,
        /// </summary>
        /// <param name="source">The <see cref="SizeF2D"/> to multiply.</param>
        /// <param name="other">The scalar value to multiply with.</param>
        /// <returns>The <see cref="SizeF2D"/> whose values are the product of the values of <c>source</c> and <c>other</c>.</returns>
        public static SizeF2D operator *(SizeF2D source, float other) => new(
            source.Width * other,
            source.Height * other);

        /// <summary>
        /// Divides the values of a <see cref="SizeF2D"/> by a scalar value,
        /// </summary>
        /// <param name="source">The <see cref="SizeF2D"/> to divide.</param>
        /// <param name="other">The scalar value to divide with.</param>
        /// <returns>The <see cref="SizeF2D"/> whose values are the quotient of the values of <c>source</c> and <c>other</c>.</returns>
        public static SizeF2D operator /(SizeF2D source, float other) => new(
            source.Width / other,
            source.Height / other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="SizeF2D"/> is equal to
        /// another specified <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="SizeF2D"/> to compare.</param>
        /// <param name="other">The second <see cref="SizeF2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SizeF2D source, SizeF2D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="SizeF2D"/> is not equal to
        /// another specified <see cref="SizeF2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="SizeF2D"/> to compare.</param>
        /// <param name="other">The second <see cref="SizeF2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(SizeF2D source, SizeF2D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="SizeF2D"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode() * 397) ^
                        Height.GetHashCode();
            }
        }

        /// <summary>
        /// Converts a <see cref="SizeF2D"/> to a <see cref="SizeF"/> by using the width and height values.
        /// </summary>
        /// <param name="source">The <see cref="SizeF2D"/> to convert.</param>
        public static implicit operator SizeF(SizeF2D source) => new(source.Width, source.Height);

        /// <summary>
        /// Converts a <see cref="SizeF"/> to a <see cref="SizeF2D"/> by using the width and height values.
        /// </summary>
        /// <param name="source">The <see cref="SizeF"/> to convert.</param>
        public static implicit operator SizeF2D(SizeF source) => new(source.Width, source.Height);
    }
}
