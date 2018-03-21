using System;
using System.Drawing;
using Xunit;

namespace GifToC64Sprites.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void GivenValidColor_ShouldReturnC64Color()
        {
            // Arrange
            var rgb = Color.FromArgb(204, 68, 204);

            // Act
            var c64color = rgb.ToC64Color();

            // Assert
            Assert.Equal(C64Colors.Violet, c64color);
        }

        [Fact]
        public void GivenInvalidColor_ShouldThrow()
        {
            // Arrange
            var rgb = Color.FromArgb(100, 200, 3);

            // Act
            void Act() => rgb.ToC64Color();

            // Assert
            Assert.Throws<ArgumentException>((Action) Act);
        }
    }
}