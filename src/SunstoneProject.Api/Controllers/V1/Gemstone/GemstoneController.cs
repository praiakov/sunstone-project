using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Post([FromServices] IGemstoneUseCase gemstoneUseCase)
        {
            _logger.LogInformation("CheckoutController.Post");

            await gemstoneUseCase
                .ExecuteAsync(null);

            return Accepted();
        }
    }
}
