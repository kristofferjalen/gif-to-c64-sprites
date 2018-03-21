using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;

namespace GifToC64Sprites
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(ConvertToSprites)
                    .WithNotParsed(HandleParseError);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static void HandleParseError(IEnumerable<Error> errs) => Console.WriteLine(string.Join(", ", errs));

        private static void ConvertToSprites(Options options)
        {
            using (var stream = new FileStream(options.Input, FileMode.Open))
            using (var writer = new BinaryWriter(File.Open(options.Output, FileMode.Create)))
            {
                var (bytes, count) = Converter.Convert(
                    stream.ToFrames().ToList(),
                    options.Colors.ToColorsString().ToByteAdds(),
                    options.MaxFrames);
                writer.Write(bytes);
                Console.WriteLine($"Successfully converted {count} frames.");
            }
        }
    }
}
