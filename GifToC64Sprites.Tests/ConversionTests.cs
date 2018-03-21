using System.IO;
using System.Linq;
using Xunit;

namespace GifToC64Sprites.Tests
{
    public class ConversionTests
    {
        [Fact]
        public void GivenInputFile_Convert_ShouldReturnEqualsToReferenceFile()
        {
            // Arrange
            var options = new Options
            {
                Input = "input.gif",
                Colors = "0fae"
            };

            // Act
            bool equal;
            using (var stream = new FileStream(options.Input, FileMode.Open))
            {
                var (bytes, _) = Converter.Convert(
                    stream.ToFrames().ToList(),
                    options.Colors.ToColorsString().ToByteAdds());
                using (var file = new FileStream("output.spr", FileMode.Open))
                {
                    var buffer = new byte[3000];
                    var count = file.Read(buffer, 0, 3000);
                    equal = buffer.Take(count).SequenceEqual(bytes.Take(bytes.Length));
                }
            }

            // Assert
            Assert.True(equal);
        }
    }
}
