using System;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D orthogonal coordinates structure.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Point3D"/> structure.
    /// </remarks>
    /// <param name="x">The X-axis coordinate.</param>
    /// <param name="y">The Y-axis coordinate.</param>
    /// <param name="z">The Z-axis coordinate.</param>
    public struct Point3D(int x, int y, int z) : IEquatable<Point3D>
    {
        /// <summary>
        /// Gets or sets the X-axis coordinate.
        /// </summary>
        /// <value>The X-axis coordinate.</value>
        public int X { get; set; } = x;

        /// <summary>
        /// Gets or sets the Y-axis coordinate.
        /// </summary>
        /// <value>The Y-axis coordinate.</value>
        public int Y { get; set; } = y;

        /// <summary>
        /// Gets or sets the Z-axis coordinate.
        /// </summary>
        /// <value>The Z-axis coordinate.</value>
        public int Z { get; set; } = z;

        /// <summary>
        /// Gets a value indicating whether the coordinates of this <see cref="Point3D"/> are zero.
        /// </summary>
        /// <value><c>true</c> if the coorinates are zero; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty => X == 0 && Y == 0;

        /// <summary>
        /// Gets a <see cref="Point3D"/> with the coordinates of zero.
        /// </summary>
        /// <value>The orthogonal centre point.</value>
        public static Point3D Empty => new(0, 0, 0);

        public Point3D(Point2D point, int z) : this(point.X, point.Y, z) { }

        /// <summary>
        /// Determines whether the specified <see cref="Point3D"/> is equal to the current <see cref="Point3D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Point3D"/> to compare with the current <see cref="Point3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Point3D"/> is equal to the current <see cref="Point3D"/>;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Point3D other)
            => Equals(X, other.X) && Equals(Y, other.Y) && Equals(Z, other.Z);

        public readonly bool Equals(int x, int y, int z)
            => X.Equals(x) && Y.Equals(Y) && Z.Equals(Z);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Point3D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Point3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Point3D"/>; otherwise, <c>false</c>.</returns>
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

            return Equals((Point3D)obj);
        }

        /// <summary>
        /// Adds the coordinates of a <see cref="Point3D"/> to those of another <see cref="Point3D"/>,
        /// yielding a new <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to add.</param>
        /// <param name="other">The second <see cref="Point3D"/> to add.</param>
        /// <returns>The <see cref="Point3D"/> whose coordinates are the sum of the coordinates of <c>source</c> and <c>other</c>.</returns>
        public static Point3D operator +(Point3D source, Point3D other) => new(
            source.X + other.X,
            source.Y + other.Y,
            source.Z + other.Z);

        /// <summary>
        /// Subtracts the coordinates of a <see cref="Point3D"/> from those of another <see cref="Point3D"/>,
        /// yielding a new <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to subtract.</param>
        /// <param name="other">The second <see cref="Point3D"/> to subtract.</param>
        /// <returns>The <see cref="Point3D"/> whose coordinates are the sum of the coordinates of <c>source</c> and <c>other</c>.</returns>
        public static Point3D operator -(Point3D source, Point3D other) => new(
            source.X - other.X,
            source.Y - other.Y,
            source.Z - other.Z);

        /// <summary>
        /// Multiples the values of a <see cref="Point3D"/> from those of another <see cref="Point3D"/>,
        /// yielding a new <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to multiply.</param>
        /// <param name="other">The second <see cref="Point3D"/> to multiply.</param>
        /// <returns>The <see cref="Point3D"/> whose values are the produce of the values of <c>source</c> and <c>other</c>.</returns>
        public static Point3D operator *(Point3D source, Point3D other) => new(
            source.X * other.X,
            source.Y * other.Y,
            source.Z * other.Z);

        /// <summary>
        /// Divides the values of a <see cref="Point3D"/> from those of another <see cref="Point3D"/>,
        /// yielding a new <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to divide.</param>
        /// <param name="other">The second <see cref="Point3D"/> to divide.</param>
        /// <returns>The <see cref="Point3D"/> whose values are the division of the values of <c>source</c> and <c>other</c>.</returns>
        public static Point3D operator /(Point3D source, Point3D other) => new(
            source.X / other.X,
            source.Y / other.Y,
            source.Z / other.Z);

        public static Point3D operator *(Point3D source, int other) => new(
            source.X * other,
            source.Y * other,
            source.Y * other);

        public static Point3D operator /(Point3D source, int other) => new(
            source.X / other,
            source.Y / other,
            source.Y * other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point3D"/> is equal to another specified <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to compare.</param>
        /// <param name="other">The second <see cref="Point3D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Point3D source, Point3D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point3D"/> is not equal to
        /// another specified <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to compare.</param>
        /// <param name="other">The second <see cref="Point3D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Point3D source, Point3D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Point3D"/> object.
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
    }
}
