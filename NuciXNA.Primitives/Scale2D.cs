using System;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D scale strucure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Scale2D"/> structure.
    /// </remarks>
    /// <param name="horizontal">The horizontal scale.</param>
    /// <param name="vertical">The vertical scale.</param>
    public struct Scale2D(float horizontal, float vertical) : IEquatable<Scale2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scale2D"/> structure with equal horizontal and vertical scale.
        /// </summary>
        /// <param name="scale">The scale to apply to both horizontal and vertical dimensions.</param>
        public Scale2D(float scale) : this(scale, scale) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scale2D"/> structure.
        /// </summary>
        /// <param name="point">Point.</param>
        public Scale2D(Point2D point) : this(point.X, point.Y) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scale2D"/> structure.
        /// </summary>
        /// <param name="size">Size.</param>
        public Scale2D(Size2D size) : this(size.Width, size.Height) { }

        /// <summary>
        /// Gets or sets the horizontal scale.
        /// </summary>
        /// <value>The horizontal scale.</value>
        public float Horizontal { get; set; } = horizontal;

        /// <summary>
        /// Gets or sets the vertical scale.
        /// </summary>
        /// <value>The vertical scale.</value>
        public float Vertical { get; set; } = vertical;

        /// <summary>
        /// Gets a value indicating whether the values of this <see cref="Scale2D"/> are zero.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => Horizontal == 0 && Vertical == 0;

        /// <summary>
        /// Gets a scale of zero.
        /// </summary>
        /// <value>The scale of zero.</value>
        public static Scale2D Empty => new(0, 0);

        /// <summary>
        /// Gets a scale of zero.
        /// </summary>
        /// <value>The scale of zero.</value>
        public static Scale2D Zero => new(0, 0);

        /// <summary>
        /// Gets a scale of one.
        /// </summary>
        /// <value>The scale of one.</value>
        public static Scale2D One => new(1, 1);

        /// <summary>
        /// Determines whether the specified <see cref="Scale2D"/> is equal to the current <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Scale2D"/> to compare with the current <see cref="Scale2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Scale2D"/> is equal to the current
        /// <see cref="Scale2D"/>; otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Scale2D other) =>
            Equals(Horizontal, other.Horizontal) &&
            Equals(Vertical, other.Vertical);

        /// <summary>
        /// Determines whether the specified horizontal and vertical scale values are equal to the current <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="horizontal">The horizontal scale value.</param>
        /// <param name="vertical">The vertical scale value.</param>
        /// <returns><c>true</c> if the specified horizontal and vertical scale values are equal to the current
        public readonly bool Equals(float horizontal, float vertical) =>
            Horizontal.Equals(horizontal) &&
            Vertical.Equals(vertical);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Scale2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Scale2D"/>; otherwise, <c>false</c>.</returns>
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

            return Equals((Scale2D)obj);
        }

        /// <summary>
        /// Adds the values of a <see cref="Scale2D"/> to those of another <see cref="Scale2D"/>,
        /// yielding a new <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/>.</param>
        /// <param name="other">The second <see cref="Scale2D"/>.</param>
        /// <returns>The <see cref="Scale2D"/> that is the sum of the values of <c>source</c> and <c>other</c>.</returns>
        public static Scale2D operator +(Scale2D source, Scale2D other) => new(
            source.Horizontal + other.Horizontal,
            source.Vertical + other.Vertical);

        /// <summary>
        /// Subtracts the values of a <see cref="Scale2D"/> from those of another <see cref="Scale2D"/>,
        /// yielding a new <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/> to subtract.</param>
        /// <param name="other">The second <see cref="Scale2D"/> to subtract.</param>
        /// <returns>The <see cref="Scale2D"/> that is the subtraction of the values of <c>other</c> from <c>source</c>.</returns>
        public static Scale2D operator -(Scale2D source, Scale2D other) => new(
            source.Horizontal - other.Horizontal,
            source.Vertical - other.Vertical);

        /// <summary>
        /// Multiplies the values of a <see cref="Scale2D"/> to those of another <see cref="Scale2D"/>,
        /// yielding a new <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/>.</param>
        /// <param name="other">The second <see cref="Scale2D"/>.</param>
        /// <returns>The <see cref="Scale2D"/> that is the produce of the values of <c>source</c> and <c>other</c>.</returns>
        public static Scale2D operator *(Scale2D source, Scale2D other) => new(
            source.Horizontal * other.Horizontal,
            source.Vertical * other.Vertical);

        /// <summary>
        /// Divides the values of a <see cref="Scale2D"/> to those of another <see cref="Scale2D"/>,
        /// yielding a new <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/>.</param>
        /// <param name="other">The second <see cref="Scale2D"/>.</param>
        /// <returns>The <see cref="Scale2D"/> that is the division of the values of <c>source</c> and <c>other</c>.</returns>
        public static Scale2D operator /(Scale2D source, Scale2D other) => new(
            source.Horizontal / other.Horizontal,
            source.Vertical / other.Vertical);

        /// <summary>
        /// Multiplies the values of a <see cref="Scale2D"/> to those of an <see cref="int"/>,
        /// yielding a new <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/>.</param>
        /// <param name="value">The <see cref="int"/> to multiply with.</param>
        /// <returns>The <see cref="Scale2D"/> that is the produce of the values of <c>source</c> and <c>value</c>.</returns>
        public static Scale2D operator *(Scale2D source, int value) => new(
            source.Horizontal * value,
            source.Vertical * value);

        /// <summary>
        /// Divides the values of a <see cref="Scale2D"/> to those of an <see cref="int"/>,
        /// yielding a new <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/>.</param>
        /// <param name="value">The <see cref="int"/> to divide with.</param>
        /// <returns>The <see cref="Scale2D"/> that is the division of the values of <c>source</c> and <c>value</c>.</returns>
        public static Scale2D operator /(Scale2D source, int value) => new(
            source.Horizontal / value,
            source.Vertical / value);

        /// <summary>
        /// Multiplies the values of a <see cref="Scale2D"/> by a scalar value,
        /// </summary>
        /// <param name="source">The <see cref="Scale2D"/> to multiply.</param>
        /// <param name="value">The scalar value to multiply with.</param>
        /// <returns>The <see cref="Scale2D"/> that is the product of the values of <c>source</c> and <c>value</c>.</returns>
        public static Scale2D operator *(Scale2D source, float value) => new(
            source.Horizontal * value,
            source.Vertical * value);

        /// <summary>
        /// Divides the values of a <see cref="Scale2D"/> by a scalar value,
        /// </summary>
        /// <param name="source">The <see cref="Scale2D"/> to divide.</param>
        /// <param name="value">The scalar value to divide with.</param>
        /// <returns>The <see cref="Scale2D"/> that is the division of the values of <c>source</c> and <c>value</c>.</returns>
        public static Scale2D operator /(Scale2D source, float value) => new(
            source.Horizontal / value,
            source.Vertical * value);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Scale2D"/> is equal to
        /// another specified <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Scale2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Scale2D source, Scale2D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Scale2D"/> is not equal to
        /// another specified <see cref="Scale2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Scale2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Scale2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Scale2D source, Scale2D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Scale2D"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (Horizontal.GetHashCode() * 397) ^
                        Vertical.GetHashCode();
            }
        }
    }
}
