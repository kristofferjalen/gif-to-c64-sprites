using CommandLine;

namespace GifToC64Sprites
{
    internal class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file to be converted.")]
        public string Input { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file to write to.")]
        public string Output { get; set; }

        [Option('c', "colors", Required = true, HelpText = "A four characters string of hex numbers defining the color in each of the registers $d020, $d025, $d026, $d027.")]
        public string Colors { get; set; }

        [Option('f', "maxframes", Required = false, HelpText = "Maximum number of frames to convert.")]
        public int? MaxFrames { get; set; }
    }
}
