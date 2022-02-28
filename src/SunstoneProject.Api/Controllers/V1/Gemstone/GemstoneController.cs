using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SunstoneProject.Application.UseCases.GemstoneUseCase;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
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
        private readonly IGemstoneUseCase _gemstoneUseCase;

        ///<inheritdoc/>
        public GemstoneController(ILogger<GemstoneController> logger, IGemstoneUseCase gemstoneUseCase)
        {
            _logger = logger;
            _gemstoneUseCase = gemstoneUseCase;
        }

        /// <summary>
        /// Create Gemstone
        /// </summary>
        /// <param name="gemstoneInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> PostAsync(InputModels.Gemstone gemstoneInputModel)
        {
            _logger.LogInformation("GemstoneController.Post");

            await _gemstoneUseCase
                .ExecuteAsync(Mapping(gemstoneInputModel));

            return Accepted();
        }

        /// <summary>
        /// Get Gemstone
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Domain.Entities.Gemstone>> GetAsync()
        {
            _logger.LogInformation("GemstoneController.Get");

            return await _gemstoneUseCase.GetAsync();
        }

        #region Private methods
        private static Domain.Entities.Gemstone Mapping(InputModels.Gemstone gemstoneInputModel)
         => new(gemstoneInputModel.Name, gemstoneInputModel.Carat, 
                gemstoneInputModel.Clarity, gemstoneInputModel.Color);
        #endregion
    }
}
