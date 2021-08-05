using SunstoneProject.Domain.Entities;
using Xunit;
using SunstoneProject.Domain.Enums;
using SunstoneProject.Domain.Exceptions;

namespace SunstoneProject.Tests.Domain
{
    public class GemstoneTest
    {
        [Fact]
        public void CreateGemstone_WhenPayloadBeOk_ReturnDomainOK()
        {
            // arrange & act
            var gemstone = new Gemstone("Amethyst Cabochon", 12, 89, Colors.Purple);

            // assert
            Assert.NotNull(gemstone);
        }

        [Theory]
        [InlineData("Labradorite", 0, 99, Colors.Black)]
        public void Error_WhenCaratUnderOrEqualZero_ReturnDomainException(string name, decimal carat, decimal clarity, Colors color)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, color));
        }

        [Theory]
        [InlineData("Emerald", 4, 0, Colors.Green)]
        public void Error_WhenClarityUnderOrEqualZero_ReturnDomainException(string name, decimal carat, decimal clarity, Colors color)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, color));
        }

        [Theory]
        [InlineData("Old Burma Ruby", 4, 67)]
        public void Error_WhenColorUnderZero_ReturnDomainException(string name, decimal carat, decimal clarity)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, (Colors)18));
        }
    }
}
