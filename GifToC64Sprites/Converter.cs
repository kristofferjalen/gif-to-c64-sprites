using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GifToC64Sprites
{
    internal class Converter
    {
        public static (byte[] bytes, int count) Convert(List<Bitmap> frames, IDictionary<C64Colors, Func<int, int>> byteAdds, int? maxframes = null)
        {
            var count = maxframes.GetValueOrDefault(frames.Count);

            var bytes = new[]
            {
                new byte[64 * count],
                new byte[64 * count],
                new byte[64 * count],
                new byte[64 * count]
            };

            for (var frame = 0; frame < count; frame++)
            {
                // The output is all frames for the top-left, followed by all frames for the bottom-left, then top-right, then bottom-right.
                for (var y = 0; y < 21; y++)
                {
                    for (var x = 0; x < 3; x++)
                    {
                        bytes[0][frame * 64 + y * 3 + x] = GetSpriteByte(frames[frame], 0, 0, x, y, byteAdds);
                        bytes[1][frame * 64 + y * 3 + x] = GetSpriteByte(frames[frame], 0, 1, x, y, byteAdds);
                        bytes[2][frame * 64 + y * 3 + x] = GetSpriteByte(frames[frame], 1, 0, x, y, byteAdds);
                        bytes[3][frame * 64 + y * 3 + x] = GetSpriteByte(frames[frame], 1, 1, x, y, byteAdds);
                    }
                }

                // Set the 64th byte to zero
                bytes[0][64 * (frame + 1) - 1] = System.Convert.ToByte(0);
                bytes[1][64 * (frame + 1) - 1] = System.Convert.ToByte(0);
                bytes[2][64 * (frame + 1) - 1] = System.Convert.ToByte(0);
                bytes[3][64 * (frame + 1) - 1] = System.Convert.ToByte(0);
            }

            return (bytes.SelectMany(x => x).ToArray(), count);
        }

        private static byte GetSpriteByte(Bitmap bitmap, int xOffset, int yOffset, int x, int y, IDictionary<C64Colors, Func<int, int>> byteAdds)
        {
            var @byte = 0;

            for (var bit = 0; bit < 8; bit = bit + 2)
            {
                var pixel = bitmap.GetPixel(24 * xOffset + 8 * x + bit, 21 * yOffset + y);

                if (pixel.A == 0)
                {
                    @byte += byteAdds.First().Value(bit);
                }
                else
                {
                    var c64Color = pixel.ToC64Color();
                    if (!byteAdds.ContainsKey(c64Color))
                        throw new ArgumentException($"Color {c64Color} not specified in Colors argument.");
                    @byte += byteAdds[pixel.ToC64Color()](bit);
                }
            }

            return System.Convert.ToByte(@byte);
        }
    }
}
