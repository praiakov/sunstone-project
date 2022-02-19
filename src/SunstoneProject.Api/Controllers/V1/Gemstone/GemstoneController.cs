using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SunstoneProject.Application.UseCases.GemstoneUseCase;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SunstoneProject.Api.Controllers.V1.Gemstone
{
    ///<inheritdoc/>
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/gemstone")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Gemstone Operations")]
    [ApiController]
    public class GemstoneController : ControllerBase
    {
        private readonly ILogger<GemstoneController> _logger;

        ///<inheritdoc/>
        public GemstoneController(ILogger<GemstoneController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Create Gemstone
        /// </summary>
        /// <param name="gemstoneInputModel"></param>
        /// <param name="gemstoneUseCase"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Post(InputModels.Gemstone gemstoneInputModel,[FromServices] IGemstoneUseCase gemstoneUseCase)
        {
            _logger.LogInformation("GemstoneController.Post");

            await gemstoneUseCase
                .ExecuteAsync(Mapping(gemstoneInputModel));

            return Accepted();
        }


        #region Private methods
        private static Domain.Entities.Gemstone Mapping(InputModels.Gemstone gemstoneInputModel)
        {
            return new Domain.Entities.Gemstone(gemstoneInputModel.Name, gemstoneInputModel.Carat, 
                                                gemstoneInputModel.Clarity, gemstoneInputModel.Color);
        }
        #endregion
    }
}
