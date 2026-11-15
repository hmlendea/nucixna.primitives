using System;

namespace NuciXNA.Primitives.Mapping
{
    /// <summary>
    /// Provides methods for converting between <see cref="Colour"/> and various colour representations
    /// such as ARGB integers and hexadecimal strings.
    /// </summary>
    public static class ColourTranslator
    {
        /// <summary>
        /// Gets the maximum value of a colour channel.
        /// </summary>
        /// <value>The maximum channel value.</value>
        private static byte MaximumChannelValue => 255;

        /// <summary>
        /// Converts the colour to its hexadecimal string representation.
        /// </summary>
        /// <param name="colour">The colour to convert.</param>
        /// <returns>The hexadecimal code.</returns>
        public static string ToHexadecimal(Colour colour)
        {
            string hexadecimalCode = string.Format(
                "#{0:X2}{1:X2}{2:X2}",
                colour.R,
                colour.G,
                colour.B);

            if (!object.Equals(colour.A, MaximumChannelValue))
            {
                hexadecimalCode = string.Format(
                    "#{0:X2}{1:X2}{2:X2}{3:X2}",
                    colour.A,
                    colour.R,
                    colour.G,
                    colour.B);
            }

            return hexadecimalCode;
        }

        /// <summary>
        /// Creates a colour from a hexadecimal code.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="hexadecimalCode">Hexadecimal code.</param>
        public static Colour FromHexadecimal(string hexadecimalCode)
        {
            if (hexadecimalCode is null)
            {
                throw new ArgumentNullException(nameof(hexadecimalCode));
            }

            string digits = hexadecimalCode;

            if (digits.StartsWith('#'))
            {
                digits = digits[1..];
            }

            Colour colour = new();

            if (object.Equals(digits.Length, 3))
            {
                colour.A = MaximumChannelValue;
                colour.R = Convert.ToByte($"{digits[0]}{digits[0]}", 16);
                colour.G = Convert.ToByte($"{digits[1]}{digits[1]}", 16);
                colour.B = Convert.ToByte($"{digits[2]}{digits[2]}", 16);
            }
            else if (object.Equals(digits.Length, 4))
            {
                colour.A = Convert.ToByte($"{digits[0]}{digits[0]}", 16);
                colour.R = Convert.ToByte($"{digits[1]}{digits[1]}", 16);
                colour.G = Convert.ToByte($"{digits[2]}{digits[2]}", 16);
                colour.B = Convert.ToByte($"{digits[3]}{digits[3]}", 16);
            }
            else if (object.Equals(digits.Length, 6))
            {
                colour.A = MaximumChannelValue;
                colour.R = Convert.ToByte(digits.Substring(0, 2), 16);
                colour.G = Convert.ToByte(digits.Substring(2, 2), 16);
                colour.B = Convert.ToByte(digits.Substring(4, 2), 16);
            }
            else if (object.Equals(digits.Length, 8))
            {
                colour.A = Convert.ToByte(digits.Substring(0, 2), 16);
                colour.R = Convert.ToByte(digits.Substring(2, 2), 16);
                colour.G = Convert.ToByte(digits.Substring(4, 2), 16);
                colour.B = Convert.ToByte(digits.Substring(6, 2), 16);
            }
            else
            {
                throw new ArgumentException(
                    $"Hexadecimal code '{hexadecimalCode}' must contain 3, 4, 6, or 8 digits.",
                    nameof(hexadecimalCode));
            }

            return colour;
        }

        /// <summary>
        /// Converts the colour to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="colour">Colour.</param>
        public static int ToArgb(Colour colour)
            => ToArgb(colour.R, colour.G, colour.B, colour.A);

        /// <summary>
        /// Converts the RGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="redComponent">The red component.</param>
        /// <param name="greenComponent">The green component.</param>
        /// <param name="blueComponent">The blue component.</param>
        public static int ToArgb(byte redComponent, byte greenComponent, byte blueComponent)
            => ToArgb(redComponent, greenComponent, blueComponent, MaximumChannelValue);

        /// <summary>
        /// Converts the RGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="redComponent">The red component.</param>
        /// <param name="greenComponent">The green component.</param>
        /// <param name="blueComponent">The blue component.</param>
        public static int ToArgb(int redComponent, int greenComponent, int blueComponent)
            => ToArgb(
                (byte)redComponent,
                (byte)greenComponent,
                (byte)blueComponent,
                MaximumChannelValue);

        /// <summary>
        /// Converts the ARGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="redComponent">The red component.</param>
        /// <param name="greenComponent">The green component.</param>
        /// <param name="blueComponent">The blue component.</param>
        /// <param name="alphaComponent">The alpha component.</param>
        public static int ToArgb(
            byte redComponent,
            byte greenComponent,
            byte blueComponent,
            byte alphaComponent)
            => (alphaComponent << 24) |
                (redComponent << 16) |
                (greenComponent << 8) |
                blueComponent;

        /// <summary>
        /// Converts the ARGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="redComponent">The red component.</param>
        /// <param name="greenComponent">The green component.</param>
        /// <param name="blueComponent">The blue component.</param>
        /// <param name="alphaComponent">The alpha component.</param>
        public static int ToArgb(
            int redComponent,
            int greenComponent,
            int blueComponent,
            int alphaComponent)
            => ToArgb(
                (byte)redComponent,
                (byte)greenComponent,
                (byte)blueComponent,
                (byte)alphaComponent);

        /// <summary>
        /// Creates a colour from an ARGB integer.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="argb">ARGB integer.</param>
        public static Colour FromArgb(int argb) => new(
            (byte)((argb >> 16) & MaximumChannelValue),
            (byte)((argb >> 8) & MaximumChannelValue),
            (byte)(argb & MaximumChannelValue),
            (byte)((argb >> 24) & MaximumChannelValue));

        /// <summary>
        /// Creates a colour from RGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="redComponent">Red value.</param>
        /// <param name="greenComponent">Green value.</param>
        /// <param name="blueComponent">Blue value.</param>
        public static Colour FromArgb(
            byte redComponent,
            byte greenComponent,
            byte blueComponent)
            => new(redComponent, greenComponent, blueComponent);

        /// <summary>
        /// Creates a colour from RGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="redComponent">Red value.</param>
        /// <param name="greenComponent">Green value.</param>
        /// <param name="blueComponent">Blue value.</param>
        public static Colour FromArgb(int redComponent, int greenComponent, int blueComponent)
            => new(redComponent, greenComponent, blueComponent);

        /// <summary>
        /// Creates a colour from ARGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="alphaComponent">Alpha value.</param>
        /// <param name="redComponent">Red value.</param>
        /// <param name="greenComponent">Green value.</param>
        /// <param name="blueComponent">Blue value.</param>
        public static Colour FromArgb(
            byte alphaComponent,
            byte redComponent,
            byte greenComponent,
            byte blueComponent)
            => new(redComponent, greenComponent, blueComponent, alphaComponent);

        /// <summary>
        /// Creates a colour from ARGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="alphaComponent">Alpha value.</param>
        /// <param name="redComponent">Red value.</param>
        /// <param name="greenComponent">Green value.</param>
        /// <param name="blueComponent">Blue value.</param>
        public static Colour FromArgb(
            int alphaComponent,
            int redComponent,
            int greenComponent,
            int blueComponent)
            => new(redComponent, greenComponent, blueComponent, alphaComponent);
    }
}
