using System;
using System.Drawing;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D size structure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Size2D"/> structure.
    /// </remarks>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
    public struct Size2D(int width, int height) : IEquatable<Size2D>
    {
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; } = width;

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; } = height;

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>The area.</value>
        public readonly double Area => Width * Height;

        public readonly double Perimeter => Width * 2 + Height * 2;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Size2D"/> is zero.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => Width == 0 && Height == 0;

        /// <summary>
        /// Gets the size of zero.
        /// </summary>
        /// <value>The size of zero.</value>
        public static Size2D Empty => new(0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2D"/> structure.
        /// </summary>
        /// <param name="point">Point.</param>
        public Size2D(Point2D point) : this(point.X, point.Y) { }

        public Size2D(int size) : this(size, size) { }

        /// <summary>
        /// Determines whether the specified <see cref="Size2D"/> is equal to the current <see cref="Size2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Size2D"/> to compare with the current <see cref="Size2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Size2D"/> is equal to the current <see cref="Size2D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Size2D other) =>
            Equals(Width, other.Width) &&
            Equals(Height, other.Height);

        public readonly bool Equals(int width, int height) =>
            Width.Equals(width) &&
            Height.Equals(height);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Size2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Size2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="Size2D"/>;
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

            return Equals((Size2D)obj);
        }

        /// <summary>
        /// Adds the values of a <see cref="Size2D"/> to those of another <see cref="Size2D"/>,
        /// yielding a new <see cref="Size2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Size2D"/> to add.</param>
        /// <param name="other">The second <see cref="Size2D"/> to add.</param>
        /// <returns>The <see cref="Size2D"/> that is the sum of the values of <c>source</c> and <c>other</c>.</returns>
        public static Size2D operator +(Size2D source, Size2D other) => new(
            source.Width + other.Width,
            source.Height + other.Height);

        /// <summary>
        /// Subtracts the values of a <see cref="Size2D"/> from those of another <see cref="Size2D"/>,
        /// yielding a new <see cref="Size2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Size2D"/> to subtract.</param>
        /// <param name="other">The second <see cref="Size2D"/> to subtract.</param>
        /// <returns>The <see cref="Size2D"/> that is the subtraction of the values of <c>other</c> from <c>source</c>.</returns>
        public static Size2D operator -(Size2D source, Size2D other) => new(
            source.Width - other.Width,
            source.Height - other.Height);

        public static Size2D operator *(Size2D source, Size2D other) => new(
            source.Width * other.Width,
            source.Height * other.Height);

        public static Size2D operator *(Size2D source, Scale2D scale) => new(
            (int)(source.Width * scale.Horizontal),
            (int)(source.Height * scale.Vertical));

        public static Size2D operator /(Size2D source, Size2D other) => new(
            source.Width / other.Width,
            source.Height / other.Height);

        public static Size2D operator /(Size2D source, Scale2D scale) => new(
            (int)(source.Width / scale.Horizontal),
            (int)(source.Height / scale.Vertical));

        public static Size2D operator *(Size2D source, int other) => new(
            source.Width * other,
            source.Height * other);

        public static Size2D operator /(Size2D source, int other) => new(
            source.Width / other,
            source.Height / other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Size2D"/> is equal to
        /// another specified <see cref="Size2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Size2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Size2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Size2D source, Size2D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Size2D"/> is not equal to
        /// another specified <see cref="Size2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Size2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Size2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Size2D source, Size2D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Size2D"/> object.
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

        public static implicit operator Size(Size2D source) => new(source.Width, source.Height);

        public static implicit operator Size2D(Size source) => new(source.Width, source.Height);

        public static implicit operator SizeF2D(Size2D source) => new(source.Width, source.Height);
    }
}
