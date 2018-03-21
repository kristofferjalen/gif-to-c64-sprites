using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace GifToC64Sprites
{
    internal static class Extensions
    {
        public static C64Colors ToC64Color(this Color color)
        {
            if (!ColorMap.DictRgb.ContainsKey(color.ToRgb()))
                throw new ArgumentException($"Pixel color {color.ToRgb()} not a valid C64 color.");
            return ColorMap.DictRgb[color.ToRgb()];
        }
        
        public static C64Colors ToC64Color(this char color) => ColorMap.Dict[color];

        public static int ToRgb(this Color color) => Color.FromArgb(color.R, color.G, color.B).ToArgb();

        public static ColorsString ToColorsString(this string @string) => new ColorsString(@string);

        public static IDictionary<C64Colors, Func<int, int>> ToByteAdds(this ColorsString colorsString) =>
            new Dictionary<C64Colors, Func<int, int>>
            {
                {colorsString.Value[0].ToC64Color(), x => 0},
                {colorsString.Value[1].ToC64Color(), x => (int)Math.Pow(2, 6 - x)},
                {colorsString.Value[2].ToC64Color(), x => (int)Math.Pow(2, 7 - x) + (int)Math.Pow(2, 6 - x)},
                {colorsString.Value[3].ToC64Color(), x => (int)Math.Pow(2, 7 - x)}
            };

        public static bool IsHex(this IEnumerable<char> chars) => 
            chars.Select(c => c >= '0' && c <= '9' || c >= 'a' && c <= 'f' || c >= 'A' && c <= 'F').All(isHex => isHex);

        public static IEnumerable<Bitmap> ToFrames(this Stream stream)
        {
            using (var gifImage = Image.FromStream(stream))
            {
                var dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
                var frameCount = gifImage.GetFrameCount(dimension);
                for (var index = 0; index < frameCount; index++)
                {
                    gifImage.SelectActiveFrame(dimension, index);
                    yield return (Bitmap)gifImage.Clone();
                }
            }
        }
    }
}
