using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SunstoneProject.Api.Controllers.V1.InputModels;
using SunstoneProject.Application.UseCases.GemstoneUseCase;
using System.Threading.Tasks;

namespace SunstoneProject.Api.Controllers.V1.Gemstone
{
    [Route("/api/v1/gemstone")]
    [ApiController]
    public class GemstoneController : ControllerBase
    {
        private readonly ILogger<GemstoneController> _logger;

        public GemstoneController(ILogger<GemstoneController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Create Gemstone
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Post(GemstoneInputModel gemstoneInputModel,[FromServices] IGemstoneUseCase gemstoneUseCase)
        {
            _logger.LogInformation("CheckoutController.Post");

            await gemstoneUseCase
                .ExecuteAsync(Mapping(gemstoneInputModel));

            return Accepted();
        }


        #region Private methods
        private static Domain.Entities.Gemstone Mapping(GemstoneInputModel gemstoneInputModel)
        {
            return new Domain.Entities.Gemstone(gemstoneInputModel.Name, gemstoneInputModel.Carat, 
                                                gemstoneInputModel.Clarity, gemstoneInputModel.Color);
        }
        #endregion
    }
}
