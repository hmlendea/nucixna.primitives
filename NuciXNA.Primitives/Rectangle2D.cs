using System;
using System.Drawing;

using XnaRectangle = Microsoft.Xna.Framework.Rectangle;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// 2D rectangle structure
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Rectangle2D"/> structure.
    /// </remarks>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
    public struct Rectangle2D(int x, int y, int width, int height) : IEquatable<Rectangle2D>
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public Point2D Location
        {
            readonly get => new(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size2D Size
        {
            readonly get => new(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

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
        /// Gets a value indicating whether the location and size of this <see cref="Rectangle2D"/>
        /// are equal to zero.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public readonly bool IsEmpty
            => X.Equals(0) && Y.Equals(0) && Width.Equals(0) && Height.Equals(0);

        /// <summary>
        /// Gets the lowest Y-axis coordinate of the rectangle.
        /// </summary>
        /// <value>The bottom Y-axis coordinate.</value>
        public readonly int Bottom => Y + Height;

        /// <summary>
        /// Gets the lowest X-axis coordinate of the rectangle.
        /// </summary>
        /// <value>The left X-axis coordinate.</value>
        public readonly int Left => X;

        /// <summary>
        /// Gets the greatest X-axis coordinate of the rectangle.
        /// </summary>
        /// <value>The right X-axis coordinate.</value>
        public readonly int Right => X + Width;

        /// <summary>
        /// Gets the greatest Y-axis coordinate of the rectangle.
        /// </summary>
        /// <value>The top Y-axis coordinate.</value>
        public readonly int Top => Y;

        public readonly Point2D Centre => new(X + Width / 2, Y + Height / 2);

        public readonly Point2D TopLeft => Location;

        public readonly Point2D TopRight => new(Right, Top);

        public readonly Point2D BottomLeft => new(Left, Bottom);

        public readonly Point2D BottomRight => new(Right, Bottom);

        /// <summary>
        /// Gets an empty rectangle, whose location and size are equal to zero.
        /// </summary>
        /// <value>The empty rectangle.</value>
        public static Rectangle2D Empty => new(Point2D.Empty, Size2D.Empty);

        public Rectangle2D(Point2D point, Size2D size) : this(point.X, point.Y, size.Width, size.Height) { }
        public Rectangle2D(Point2D point, int width, int height) : this (point.X, point.Y, width, height) { }
        public Rectangle2D(int x, int y, Size2D size) : this (x, y, size.Width, size.Height) { }
        public Rectangle2D(Point2D start, Point2D end) : this(start.X, start.Y, end.X - start.X, end.Y - start.Y) { }
        public Rectangle2D(Size2D size) : this(Point2D.Empty, size) { }

        /// <summary>
        /// Checks whether the specified <see cref="Rectangle2D"/> contains a set of coordinates.
        /// </summary>
        /// <param name="x">The X-axis coordinate.</param>
        /// <param name="x">The Y-axis coordinate.</param>
        /// <returns><c>true</c> if the specified set of coordinates are inside the rectangle area;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Contains(int x, int y)
            => Left <= x && Right >= x && Top <= y && Bottom >= y;

        /// <summary>
        /// Checks whether the specified <see cref="Rectangle2D"/> contains a <see cref="Point2D"/>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns><c>true</c> if the specified point is inside the rectangle area;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Contains(Point2D point) => Contains(point.X, point.Y);

        /// <summary>
        /// Checks whether the specified <see cref="Rectangle2D"/> fully contains another <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns><c>true</c> if the specified rectangle is inside the rectangle area;
        /// otherwise, <c>false</c>.</returns>
        public readonly bool Contains(Rectangle2D rectangle) =>
            Contains(rectangle.TopLeft) &&
            Contains(rectangle.BottomRight);

        /// <summary>
        /// Determines whether the specified <see cref="Rectangle2D"/> is equal to the current <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Rectangle2D"/> to compare with the current <see cref="Rectangle2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Rectangle2D"/> is equal to the current
        /// <see cref="Rectangle2D"/>; otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Rectangle2D other) =>
            Equals(X, other.X) &&
            Equals(Y, other.Y) &&
            Equals(Width, other.Width) &&
            Equals(Height, other.Height);

        public readonly bool Equals(int x, int y, int width, int height)
            => X.Equals(x) && Y.Equals(y) && Width.Equals(width) && Height.Equals(height);

        public readonly bool Equals(Point2D location, Size2D size) =>
            X.Equals(location.X) &&
            Y.Equals(location.Y) &&
            Width.Equals(size.Width) &&
            Height.Equals(size.Height);

        public readonly bool Equals(Point2D location, int width, int height) =>
            X.Equals(location.X) &&
            Y.Equals(location.Y) &&
            Width.Equals(width) &&
            Height.Equals(height);

        public readonly bool Equals(int x, int y, Size2D size) =>
            X.Equals(x) &&
            Y.Equals(y) &&
            Width.Equals(size.Width) &&
            Height.Equals(size.Height);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Rectangle2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Rectangle2D"/>; otherwise, <c>false</c>.</returns>
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

            return Equals((Rectangle2D)obj);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Rectangle2D"/> is equal to
        /// another specified <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Rectangle2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Rectangle2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Rectangle2D source, Rectangle2D other) => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Rectangle2D"/> is not equal
        /// to another specified <see cref="Rectangle2D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Rectangle2D"/> to compare.</param>
        /// <param name="other">The second <see cref="Rectangle2D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Rectangle2D source, Rectangle2D other) => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Rectangle2D"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^
                        Y.GetHashCode() ^
                        Width.GetHashCode() ^
                        Height.GetHashCode();
            }
        }

        public static implicit operator Rectangle(Rectangle2D source)
            => new(source.X, source.Y, source.Width, source.Height);

        public static implicit operator Rectangle2D(Rectangle source)
            => new(source.X, source.Y, source.Width, source.Height);

        public static implicit operator XnaRectangle(Rectangle2D source)
            => new(source.X, source.Y, source.Width, source.Height);

        public static implicit operator Rectangle2D(XnaRectangle source)
            => new(source.X, source.Y, source.Width, source.Height);
    }
}
