using Xunit;

namespace GifToC64Sprites.Tests
{
    public class HexTests
    {
        [Theory]
        [InlineData("0000")]
        [InlineData("0123")]
        [InlineData("abcd")]
        [InlineData("01ab")]
        public void GivenHexString_IsHex(string hex)
        {
            Assert.True(hex.IsHex());
        }

        [Theory]
        [InlineData("012g")]
        [InlineData("gggg")]
        public void GivenHexString_IsNotHex(string hex)
        {
            Assert.False(hex.IsHex());
        }
    }
}
