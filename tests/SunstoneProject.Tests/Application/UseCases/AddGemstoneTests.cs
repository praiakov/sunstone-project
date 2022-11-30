using Microsoft.Extensions.Logging;
using Moq;
using SunstoneProject.Application.UseCases;
using SunstoneProject.Domain.Interfaces;
using SunstoneProject.Tests.Fixture;
using Xunit;

namespace SunstoneProject.Tests.Application.UseCases
{
    public class AddGemstoneTests
    {
        private readonly Mock<ILogger<AddGemstoneUseCase>> _logger;
        private readonly Mock<IGemstoneService> _gemstoneService;
        private readonly AddGemstoneUseCase _addGemstoneUseCase;

        public AddGemstoneTests()
        {
            _logger = new Mock<ILogger<AddGemstoneUseCase>>();
            _gemstoneService = new Mock<IGemstoneService>();
            _addGemstoneUseCase = new AddGemstoneUseCase(_logger.Object, _gemstoneService.Object);
        }


        [Fact]
        public async void Add_Gemstone_ExecuteAsyncSuccess()
        {
            // arrange
            var gemstone = GemstoneFixture.AddGemstone();

            //act
            await _addGemstoneUseCase.ExecuteAsync(gemstone);

            // assert
            _gemstoneService.Verify(x => x.AddGemstone(gemstone), Times.Once);
        }
    }
}
