using SunstoneProject.Domain.Entities;
using Xunit;
using SunstoneProject.Domain.Enums;
using SunstoneProject.Domain.Exceptions;

namespace SunstoneProject.Tests.Domain
{
    public class GemstoneTest
    {
        [Fact]
        public void Create_Gemstone_ReturnGemstoneDomain()
        {
            // arrange & act
            var gemstone = new Gemstone("Amethyst Cabochon", 12, 89, Colors.Purple);

            // assert
            Assert.NotNull(gemstone);
        }

        [Theory]
        [InlineData("Labradorite", 0, 99, Colors.Black)]
        public void Add_GemstoneCaratUnderOrEqualZero_ThrowsDomainException(string name, decimal carat, decimal clarity, Colors color)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, color));
        }

        [Theory]
        [InlineData("Emerald", 4, 0, Colors.Green)]
        public void Add_GemstoneClarityUnderOrEqualZero_ThrowsDomainException(string name, decimal carat, decimal clarity, Colors color)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, color));
        }

        [Theory]
        [InlineData("Old Burma Ruby", 4, 67)]
        public void Add_GemstoneColorUnderZero_ThrowsDomainException(string name, decimal carat, decimal clarity)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, (Colors)18));
        }

        [Theory]
        [InlineData("", 4, 67, Colors.Orange)]
        public void Add_GemstoneNameIsNullOrWhiteSpace_ThrowsDomainException(string name, decimal carat, decimal clarity, Colors color)
        {
            Assert.Throws<DomainException>(() => new Gemstone(name, carat, clarity, color));
        }
    }
}
