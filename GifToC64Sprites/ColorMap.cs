using System.Collections.Generic;

namespace GifToC64Sprites
{
    internal static class ColorMap
    {
        public static readonly Dictionary<char, C64Colors> Dict = new Dictionary<char, C64Colors>
        {
            {'0', C64Colors.Black},
            {'1', C64Colors.White},
            {'2', C64Colors.Red},
            {'3', C64Colors.Cyan},
            {'4', C64Colors.Violet},
            {'5', C64Colors.Green},
            {'6', C64Colors.Blue},
            {'7', C64Colors.Yellow},
            {'8', C64Colors.Orange},
            {'9', C64Colors.Brown},
            {'a', C64Colors.LightRed},
            {'b', C64Colors.DarkGrey},
            {'c', C64Colors.Grey},
            {'d', C64Colors.LightGreen},
            {'e', C64Colors.LightBlue},
            {'f', C64Colors.LightGrey}
        };

        public static readonly Dictionary<int, C64Colors> DictRgb = new Dictionary<int, C64Colors>
        {
            {-16777216, C64Colors.Black},
            {-1, C64Colors.White},
            {-7864320, C64Colors.Red},
            {-5570578, C64Colors.Cyan},
            {-3390260, C64Colors.Violet},
            {-16724907, C64Colors.Green},
            {-16777046, C64Colors.Blue},
            {-1118601, C64Colors.Yellow},
            {-2258859, C64Colors.Orange},
            {-10075136, C64Colors.Brown},
            {-34953, C64Colors.LightRed},
            {-13421773, C64Colors.DarkGrey},
            {-8947849, C64Colors.Grey},
            {-5570714, C64Colors.LightGreen},
            {-16742145, C64Colors.LightBlue},
            {-4473925, C64Colors.LightGrey}
        };
    }
}
