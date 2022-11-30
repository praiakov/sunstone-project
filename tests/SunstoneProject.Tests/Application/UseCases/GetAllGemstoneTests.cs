using Microsoft.Extensions.Logging;
using Moq;
using SunstoneProject.Application.UseCases;
using SunstoneProject.Domain.Interfaces;
using SunstoneProject.Tests.Fixture;
using Xunit;

namespace SunstoneProject.Tests.Application.UseCases
{
    public class GetAllGemstoneTests
    {
        private readonly Mock<ILogger<GetAllGemstoneUseCase>> _logger;
        private readonly Mock<IGemstoneService> _gemstoneService;
        private readonly GetAllGemstoneUseCase _getAllGemstoneUseCase;

        public GetAllGemstoneTests()
        {
            _logger = new Mock<ILogger<GetAllGemstoneUseCase>>();
            _gemstoneService = new Mock<IGemstoneService>();
            _getAllGemstoneUseCase = new GetAllGemstoneUseCase(_logger.Object, _gemstoneService.Object);
        }

        [Fact]
        public async void Get_All_ReturnsGemstones()
        {
            // arrange
            var gemstones = GemstoneFixture.GetGemstones();
            _gemstoneService.Setup(x => x.GetGemstones()).ReturnsAsync(gemstones);

            //act
            var gemstonesList = await _getAllGemstoneUseCase.GetAsync();

            // assert
            _gemstoneService.Verify(x => x.GetGemstones(), Times.Once);
            Assert.NotNull(gemstonesList);
        }
    }
}
