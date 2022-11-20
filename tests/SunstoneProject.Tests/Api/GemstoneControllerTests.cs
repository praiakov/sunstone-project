using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using SunstoneProject.Api.Controllers.V1.Gemstone;
using SunstoneProject.Application.Interfaces.Service;
using System.Net;
using Xunit;

namespace SunstoneProject.Tests.Api
{
    public class GemstoneControllerTests
    {
        private readonly ILogger<GemstoneController> _logger;
        private readonly GemstoneController _gemstoneController;
        private readonly IGemstoneService _gemstonetUseCase;

        public GemstoneControllerTests()
        {
            _logger = Substitute.For<ILogger<GemstoneController>>();
            _gemstoneController = new GemstoneController(_logger);
            _gemstonetUseCase = Substitute.For<IGemstoneService>();
        }

        [Fact]
        public async void ResponseAcceptedWhenCallPostMethod()
        {
            var stone = new SunstoneProject.Api.Controllers.V1.InputModels.Gemstone
            {
                Name = "Esmerald",
                Carat = 10,
                Clarity = 10,
                Color = SunstoneProject.Domain.Enums.Colors.Black              
                
            };

            var response = await _gemstoneController.PostAsync(stone, _gemstonetUseCase);

            Assert.NotNull(response);
            Assert.IsType<AcceptedResult>(response);
            Assert.Equal((int)HttpStatusCode.Accepted, ((AcceptedResult)response).StatusCode);
        }
    }
}
