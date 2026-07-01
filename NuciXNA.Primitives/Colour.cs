using System;

using NuciXNA.Primitives.Mapping;

namespace NuciXNA.Primitives
{
    /// <summary>
    /// Represents an RGBA colour with red, green, blue, and alpha components.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Colour"/> class.
    /// </remarks>
    /// <param name="r">The red component.</param>
    /// <param name="g">The green component.</param>
    /// <param name="b">The blue component.</param>
    /// <param name="a">The alpha component.</param>
    public sealed class Colour(byte r, byte g, byte b, byte a) : IEquatable<Colour>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        public Colour() : this(0, 0, 0, 255) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public Colour(byte r, byte g, byte b) : this(r, g, b, (byte)255) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public Colour(int r, int g, int b) : this(r, g, b, 255) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public Colour(int r, int g, int b, int a) : this((byte)r, (byte)g, (byte)b, (byte)a) { }

        /// <summary>
        /// Gets or sets the alpha component.
        /// </summary>
        /// <value>The alpha component value, in the range 0 (fully transparent) to 255 (fully opaque).</value>
        public byte A { get; set; } = a;

        /// <summary>
        /// Gets or sets the red value.
        /// </summary>
        /// <value>The red value.</value>
        public byte R { get; set; } = r;

        /// <summary>
        /// Gets or sets the green value.
        /// </summary>
        /// <value>The green value.</value>
        public byte G { get; set; } = g;

        /// <summary>
        /// Gets or sets the blue value.
        /// </summary>
        /// <value>The blue value.</value>
        public byte B { get; set; } = b;

        #region Predefined colours
        /// <summary>A fully transparent colour (A:0, R:0, G:0, B:0).</summary>
        public static Colour Transparent => new(0, 0, 0, 0);

        #region XNA colours
        /// <summary>The Alice Blue colour (#F0F8FF).</summary>
        public static Colour AliceBlue => new(240, 248, 255, 255);
        /// <summary>The Antique White colour (#FAEBD7).</summary>
        public static Colour AntiqueWhite => new(250, 235, 215, 255);
        /// <summary>The Aqua colour (#00FFFF).</summary>
        public static Colour Aqua => new(0, 255, 255, 255);
        /// <summary>The Aquamarine colour (#7FFFD4).</summary>
        public static Colour Aquamarine => new(127, 255, 212, 255);
        /// <summary>The Bisque colour (#FFE4C4).</summary>
        public static Colour Bisque => new(255, 228, 196, 255);
        /// <summary>The Black colour (#000000).</summary>
        public static Colour Black => new(0, 0, 0, 255);
        /// <summary>The Blue colour (#0000FF).</summary>
        public static Colour Blue => new(0, 0, 255, 255);
        /// <summary>The Chocolate colour (#D2691E).</summary>
        public static Colour Chocolate => new(210, 105, 30, 255);
        /// <summary>The Cornflower Blue colour (#6495ED).</summary>
        public static Colour CornflowerBlue => new(100, 149, 237, 255);
        /// <summary>The Cornsilk colour (#FFF8DC).</summary>
        public static Colour Cornsilk => new(255, 248, 220, 255);
        /// <summary>The Crimson colour (#DC143C).</summary>
        public static Colour Crimson => new(220, 20, 60, 255);
        /// <summary>The Dark Green colour (#006400).</summary>
        public static Colour DarkGreen => new(0, 100, 0, 255);
        /// <summary>The Dark Red colour (#8B0000).</summary>
        public static Colour DarkRed => new(139, 0, 0, 255);
        /// <summary>The Dim Gray colour (#696969).</summary>
        public static Colour DimGray => new(105, 105, 105, 255);
        /// <summary>The Dodger Blue colour (#1E90FF).</summary>
        public static Colour DodgerBlue => new(30, 144, 255, 255);
        /// <summary>The Gold colour (#FFD700).</summary>
        public static Colour Gold => new(255, 215, 0, 255);
        /// <summary>The Green colour (#00FF00).</summary>
        public static Colour Green => new(0, 255, 0, 255);
        /// <summary>The Olive colour (#808000).</summary>
        public static Colour Olive => new(128, 128, 0, 255);
        /// <summary>The Olive Drab colour (#6B8E2D).</summary>
        public static Colour OliveDrab => new(107, 142, 45, 255);
        /// <summary>The Orange colour (#FFA500).</summary>
        public static Colour Orange => new(255, 165, 0, 255);
        /// <summary>The Red colour (#FF0000).</summary>
        public static Colour Red => new(255, 0, 0, 255);
        /// <summary>The Royal Blue colour (#4169FF).</summary>
        public static Colour RoyalBlue => new(65, 105, 255, 255);
        /// <summary>The Salmon colour (#FA8072).</summary>
        public static Colour Salmon => new(250, 128, 114, 255);
        /// <summary>The Sea Green colour (#2E8B57).</summary>
        public static Colour SeaGreen => new(46, 139, 87, 255);
        /// <summary>The Sky Blue colour (#87CEEB).</summary>
        public static Colour SkyBlue => new(135, 206, 235, 255);
        /// <summary>The Snow colour (#FFFAFA).</summary>
        public static Colour Snow => new(255, 250, 250, 255);
        /// <summary>The Tan colour (#D2B48C).</summary>
        public static Colour Tan => new(210, 180, 140, 255);
        /// <summary>The Teal colour (#008080).</summary>
        public static Colour Teal => new(0, 128, 128, 255);
        /// <summary>The Thistle colour (#D8BFD8).</summary>
        public static Colour Thistle => new(216, 191, 216, 255);
        /// <summary>The Tomato colour (#FF6347).</summary>
        public static Colour Tomato => new(255, 99, 71, 255);
        /// <summary>The Turquoise colour (#40E0D0).</summary>
        public static Colour Turqoise => new(64, 224, 208, 255);
        /// <summary>The Violet colour (#EE82EE).</summary>
        public static Colour Violet => new(238, 130, 238, 255);
        /// <summary>The Wheat colour (#F5DEB3).</summary>
        public static Colour Wheat => new(245, 222, 179, 255);
        /// <summary>The White colour (#FFFFFF).</summary>
        public static Colour White => new(255, 255, 255, 255);
        /// <summary>The White Smoke colour (#F5F5F5).</summary>
        public static Colour WhiteSmoke => new(245, 245, 245, 255);
        /// <summary>The Yellow colour (#FFFF00).</summary>
        public static Colour Yellow => new(255, 255, 0, 255);
        /// <summary>The Yellow Green colour (#9ACD32).</summary>
        public static Colour YellowGreen => new(154, 205, 50, 255);
        #endregion

        #region NuciXNA colours
        /// <summary>Cobalt blue, as defined on the romanian flag.</summary>
        public static Colour CobaltBlue => new(0, 43, 127, 255);
        /// <summary>Chrome yellow, as defined on the romanian flag.</summary>
        public static Colour ChromeYellow => new(252, 209, 22, 255);
        /// <summary>Persian red.</summary>
        public static Colour PersianRed => new(200, 29, 17, 255);
        /// <summary>Vermilion.</summary>
        public static Colour Vermilion => new(227, 66, 52, 255);
        /// <summary>Vermilion red, as defined on the romanian flag.</summary>
        public static Colour VermilionRed => new(206, 17, 38, 255);
        #endregion

        #region Pantone colours
        /// <summary>PANTONE PQ-15-0343TCX Greenery.</summary>
        public static Colour Greenery => new(136, 176, 75, 255);
        /// <summary>PANTONE PQ-18-2120TCX Honeysuckle.</summary>
        public static Colour Honeysuckle => new(217, 79, 112, 255);
        /// <summary>PANTONE PQ-15-1247TCX Tangerine.</summary>
        public static Colour Tangerine => new(248, 143, 88, 255);
        /// <summary>PANTONE PQ-17-1463TCX Tangerine Tango.</summary>
        public static Colour TangerineTango => new(221, 65, 36, 255);
        /// <summary>PANTONE PQ-18-3838TCX Ultra Violet.</summary>
        public static Colour UltraViolet => new(95, 75, 139, 255);
        #endregion

        #region Material colours
        /// <summary>Material Design Red colour (#F44336).</summary>
        public static Colour MaterialRed => new(244, 67, 54, 255);
        /// <summary>Material Design Pink colour (#E91E63).</summary>
        public static Colour MaterialPink => new(233, 30, 99, 255);
        /// <summary>Material Design Purple colour (#673AB7).</summary>
        public static Colour MaterialPurple => new(103, 58, 183, 255);
        /// <summary>Material Design Indigo colour (#3F51B5).</summary>
        public static Colour MaterialIndigo => new(63, 81, 181, 255);
        /// <summary>Material Design Blue colour (#2196F3).</summary>
        public static Colour MaterialBlue => new(33, 150, 243, 255);
        /// <summary>Material Design Light Blue colour (#03A9F4).</summary>
        public static Colour MaterialLightBlue => new(3, 169, 244, 255);
        /// <summary>Material Design Cyan colour (#00BCD4).</summary>
        public static Colour MaterialCyan => new(0, 188, 212, 255);
        /// <summary>Material Design Teal colour (#009688).</summary>
        public static Colour MaterialTeal => new(0, 150, 136, 255);
        /// <summary>Material Design Green colour (#4CAF50).</summary>
        public static Colour MaterialGreen => new(76, 175, 80, 255);
        /// <summary>Material Design Light Green colour (#8BC34A).</summary>
        public static Colour MaterialLightGreen => new(139, 195, 74, 255);
        /// <summary>Material Design Lime colour (#CDDC39).</summary>
        public static Colour MaterialLime => new(205, 220, 57, 255);
        /// <summary>Material Design Yellow colour (#FFEB3B).</summary>
        public static Colour MaterialYellow => new(255, 235, 59, 255);
        /// <summary>Material Design Amber colour (#FFC107).</summary>
        public static Colour MaterialAmber => new(255, 193, 7, 255);
        /// <summary>Material Design Orange colour (#FF9800).</summary>
        public static Colour MaterialOrange => new(255, 152, 0, 255);
        /// <summary>Material Design Deep Orange colour (#FF5722).</summary>
        public static Colour MaterialDeepOrange => new(255, 87, 34, 255);
        /// <summary>Material Design Brown colour (#795548).</summary>
        public static Colour MaterialBrown => new(121, 85, 72, 255);
        /// <summary>Material Design Grey colour (#9E9E9E).</summary>
        public static Colour MaterialGrey => new(158, 158, 158, 255);
        /// <summary>Material Design Blue Grey colour (#607D8B).</summary>
        public static Colour MaterialBlueGrey => new(96, 125, 139, 255);
        #endregion
        #endregion

        /// <summary>
        /// Creates a colour from an ARGB integer.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="argb">ARGB integer.</param>
        public static Colour FromArgb(int argb) => ColourTranslator.FromArgb(argb);

        /// <summary>
        /// Creates a colour from RGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(byte r, byte g, byte b) => ColourTranslator.FromArgb(r, g, b);

        /// <summary>
        /// Creates a colour from RGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(int r, int g, int b) => ColourTranslator.FromArgb(r, g, b);

        /// <summary>
        /// Creates a colour from ARGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="a">Alpha value.</param>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(byte a, byte r, byte g, byte b) => ColourTranslator.FromArgb(a, r, g, b);

        /// <summary>
        /// Creates a colour from ARGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="a">Alpha value.</param>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(int a, int r, int g, int b) => ColourTranslator.FromArgb(a, r, g, b);

        /// <summary>
        /// Creates a colour from a hexadecimal code.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="hexa">Hexadecimal code.</param>
        public static Colour FromHexadecimal(string hexa) => ColourTranslator.FromHexadecimal(hexa);

        /// <summary>
        /// Converts the colour to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        public int ToArgb() => ColourTranslator.ToArgb(this);

        /// <summary>
        /// Converts the colour to a hexadecimal string.
        /// </summary>
        /// <returns>A string representing the hexadecimal code of the colour.</returns>
        public string ToHexadecimal() => ColourTranslator.ToHexadecimal(this);

        /// <summary>
        /// Converts the colour to a monochrome colour based on the average of the RGB components.
        /// </summary>
        /// <returns>A monochrome colour.</returns>
        public Colour ToMonochromeAverage()
        {
            int average = (R + G + B) / 3;

            return new Colour(average, average, average, A);
        }

        /// <summary>
        /// Converts the colour to a monochrome colour based on the lightest RGB component.
        /// </summary>
        /// <returns>A monochrome colour.</returns>
        public Colour ToMonochromeLight()
        {
            int lightest = Math.Max(R, Math.Max(G, B));

            return new Colour(lightest, lightest, lightest, A);
        }

        /// <summary>
        /// Converts the colour to a monochrome colour based on the darkest RGB component.
        /// </summary>
        /// <returns>A monochrome colour.</returns>
        public Colour ToMonochromeDark()
        {
            int darkest = Math.Min(R, Math.Min(G, B));

            return new Colour(darkest, darkest, darkest, A);
        }

        /// <summary>
        /// Checks whether the current colour is similar to another colour within a given tolerance.
        /// </summary>
        /// <param name="colour">The colour to compare against.</param>
        /// <param name="tolerance">The maximum allowed difference per RGB channel.</param>
        /// <returns><c>true</c> if the absolute difference of each RGB channel is within <paramref name="tolerance"/>; otherwise, <c>false</c>.</returns>
        public bool IsSimilarTo(Colour colour, int tolerance) =>
            Math.Abs(R - colour.R) <= tolerance &&
            Math.Abs(G - colour.G) <= tolerance &&
            Math.Abs(B - colour.B) <= tolerance;

        /// <summary>
        /// Multiplies a specified colour by a factor, clamping each component to the range 0–255.
        /// </summary>
        /// <param name="colour">The colour to multiply.</param>
        /// <param name="factor">The factor to multiply the colour components by.</param>
        /// <returns>A new <see cref="Colour"/> whose components are the result of multiplying each component of <paramref name="colour"/> by <paramref name="factor"/>, clamped to the range 0–255.</returns>
        public static Colour Multiply(Colour colour, float factor) => new(
            (byte)Math.Max(0, Math.Min(255, colour.R * factor)),
            (byte)Math.Max(0, Math.Min(255, colour.G * factor)),
            (byte)Math.Max(0, Math.Min(255, colour.B * factor)),
            (byte)Math.Max(0, Math.Min(255, colour.A * factor)));

        /// <summary>
        /// Returns a <see cref="string"/> that represents the hexadecimal code of the current <see cref="Colour"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the hexadecimal code of the current <see cref="Colour"/>.</returns>
        public override string ToString() => ToHexadecimal();

        /// <summary>
        /// Determines whether the specified <see cref="Colour"/> is equal to the current <see cref="Colour"/>.
        /// </summary>
        /// <param name="other">The <see cref="Colour"/> to compare with the current <see cref="Colour"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Colour"/> is equal to the current
        /// <see cref="Colour"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Colour other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return
                A == other.A &&
                R == other.R &&
                G == other.G &&
                B == other.B;
        }

        /// <summary>
        /// Determines whether the specified ARGB values are equal to the current <see cref="Colour"/>.
        /// </summary>
        /// <param name="a">The alpha value.</param>
        /// <param name="r">The red value.</param>
        /// <param name="g">The green value.</param>
        /// <param name="b">The blue value.</param>
        /// <returns><c>true</c> if the specified ARGB values are equal to the current <see cref="Colour"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(int a, int r, int g, int b)
            => A.Equals(a) && R.Equals(r) && G.Equals(g) && B.Equals(b);

        /// <summary>
        /// Determines whether the specified RGB coordinates are equal to the current <see cref="Colour"/>.
        /// </summary>
        /// <param name="r">The red value.</param>
        /// <param name="g">The green value.</param>
        /// <param name="b">The blue value.</param>
        /// <returns><c>true</c> if the specified RGB coordinates are equal to the current <see cref="Colour"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(int r, int g, int b) => Equals(255, r, g, b);

        /// <summary>
        /// Determines whether the specified hexadecimal code is equal to the current <see cref="Colour"/>.
        /// </summary>
        /// <param name="hexa">The hexadecimal code to compare with the current <see cref="Colour"/>.</param>
        /// <returns><c>true</c> if the specified hexadecimal code is equal to the current <see cref="Colour"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(string hexa)
        {
            try
            {
                return Equals(FromHexadecimal(hexa));
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Colour"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Colour"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Colour"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Colour)obj);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Colour"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
            => HashCode.Combine(A, R, G, B);

        /// <summary>
        /// Multiplies a specified colour by a scalar factor.
        /// </summary>
        /// <param name="colour">The colour to multiply.</param>
        /// <param name="factor">The factor to multiply the colour components by.</param>
        /// <returns>A new <see cref="Colour"/> whose components are the result of multiplying each component of <paramref name="colour"/> by <paramref name="factor"/>, clamped to the range 0–255.</returns>
        public static Colour operator *(Colour colour, float factor)
            => Multiply(colour, factor);

        /// <summary>
        /// Determines whether two specified instances of <see cref="Colour"/> are equal.
        /// </summary>
        /// <param name="self">The first <see cref="Colour"/> to compare.</param>
        /// <param name="other">The second <see cref="Colour"/> to compare.</param>
        /// <returns><c>true</c> if <c>self</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Colour self, Colour other)
        {
            if (self is null)
            {
                return other is null;
            }

            return self.Equals(other);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Colour"/> are not equal.
        /// </summary>
        /// <param name="self">The first <see cref="Colour"/> to compare.</param>
        /// <param name="other">The second <see cref="Colour"/> to compare.</param>
        /// <returns><c>true</c> if <c>self</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Colour self, Colour other)
            => !(self == other);

        /// <summary>
        /// Converts a <see cref="Colour"/> to an ARGB integer.
        /// </summary>
        /// <param name="self">Colour to convert.</param>
        public static explicit operator int(Colour self)
            => self.ToArgb();

        public static explicit operator string(Colour self)
            => self.ToString();

        /// <summary>
        /// Converts an ARGB integer to a <see cref="Colour"/>.
        /// </summary>
        /// <param name="argb"></param>
        public static explicit operator Colour(int argb)
            => FromArgb(argb);

        /// <summary>
        /// Converts a hexadecimal string to a <see cref="Colour"/>.
        /// </summary>
        /// <param name="hexadecimal"></param>
        public static explicit operator Colour(string hexadecimal)
            => FromHexadecimal(hexadecimal);
    }
}
