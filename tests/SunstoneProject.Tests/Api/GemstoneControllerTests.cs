using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SunstoneProject.Api.Controllers.V1.Gemstone;
using SunstoneProject.Application.UseCases;
using SunstoneProject.Tests.Fixture;
using System.Net;
using Xunit;

namespace SunstoneProject.Tests.Api
{
    public class GemstoneControllerTests
    {
        private readonly Mock<ILogger<GemstoneController>> _logger;
        private readonly GemstoneController _gemstoneController;
        private readonly Mock<IAddGemstoneUseCase> _addGemstoneUseCase;
        private readonly Mock<IGetAllGemstoneUseCase> _getAllGemstoneUseCase;

        public GemstoneControllerTests()
        {
            _logger = new Mock<ILogger<GemstoneController>>();
            _addGemstoneUseCase = new Mock<IAddGemstoneUseCase>();
            _getAllGemstoneUseCase = new Mock<IGetAllGemstoneUseCase>();
            _gemstoneController = new GemstoneController(_logger.Object, _addGemstoneUseCase.Object, _getAllGemstoneUseCase.Object);
        }

        [Fact]
        public async void Add_Gemstone_ReturnAccepted()
        {
            // arrange
            var stone = new SunstoneProject.Api.Controllers.V1.InputModels.Gemstone
            {
                Name = "Esmerald",
                Carat = 10,
                Clarity = 10,
                Color = SunstoneProject.Domain.Enums.Colors.Black              
                
            };

            // act
            var response = await _gemstoneController.PostAsync(stone);

            // assert 
            Assert.NotNull(response);
            Assert.IsType<AcceptedResult>(response);
            Assert.Equal((int)HttpStatusCode.Accepted, ((AcceptedResult)response).StatusCode);
        }

        [Fact]
        public async void Get_All_ReturnsGemstones()
        {
            // arrange 
            var gemstones = GemstoneFixture.GetGemstones();

            _getAllGemstoneUseCase.Setup(x => x.GetAsync()).ReturnsAsync(gemstones);

            // act
            var response = await _gemstoneController.GetAsync();

            // assert 
            Assert.NotNull(response);
        }
    }
}
