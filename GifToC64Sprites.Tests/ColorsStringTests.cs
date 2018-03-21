using Xunit;

namespace GifToC64Sprites.Tests
{
    public class ColorsStringTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("xxxx")]
        [InlineData("10g1")]
        [InlineData("00000")]
        public void GivenColorsStringIsIncorrect_ShouldReturnNotValid(string colors)
        {
            Assert.False(ColorsString.IsValid(colors));
        }

        [Theory]
        [InlineData("0000")]
        [InlineData("01ab")]
        [InlineData("abcd")]
        public void GivenColorsStringIsIncorrect_ShouldReturnValid(string colors)
        {
            Assert.True(ColorsString.IsValid(colors));
        }
    }
}
