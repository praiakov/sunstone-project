using SunstoneProject.Domain.Entities;
using Xunit;
using SunstoneProject.Domain.Enums;

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
    }
}
