using SunstoneProject.Domain.Entities;
using SunstoneProject.Domain.Enums;
using Xunit;

namespace SunstoneProject.Tests.Application.UseCases
{
    public class GemstoneTests
    {
        [Theory]
        [InlineData("Labradorite", 2, 99, Colors.Black)]
        [InlineData("Emerald", 4, 2, Colors.Green)]
        [InlineData("Old Burma Ruby", 4, 27, Colors.Red)]
        public static void Response_GemstoneOk_ReturnOk(string name, decimal carat, decimal clarity, Colors color)
        {
            Assert.NotNull(new Gemstone(name, carat, clarity, color));
        }
    }
}
