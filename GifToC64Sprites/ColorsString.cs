using System;

namespace GifToC64Sprites
{
    internal class ColorsString
    {
        public string Value { get; }

        public ColorsString(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException($"{value} is not a valid string of colors.");
            
            Value = value;
        }

        public static bool IsValid(string value) => !string.IsNullOrEmpty(value) && value.Length == 4 && value.IsHex();
    }
}
