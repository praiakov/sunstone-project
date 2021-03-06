using Microsoft.Extensions.Logging;
using SunstoneProject.Application.Services.Gemstones.Interfaces;
using SunstoneProject.Domain.Entities;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase.AddGemstoneUseCase
{
    public class AddGemstoneUseCase : IAddGemstoneUseCase
    {
        private readonly ILogger<AddGemstoneUseCase> _logger;
        private readonly IGemstoneService _gemstoneService;

        public AddGemstoneUseCase(ILogger<AddGemstoneUseCase> logger, IGemstoneService gemstoneService)
        {
            _logger = logger;
            _gemstoneService = gemstoneService;
        }

        public async Task ExecuteAsync(Gemstone gemstone)
        {
            _logger.LogInformation($"AddGemstoneUseCase.ExecuteAsync()");

            await _gemstoneService.SendGemstone(gemstone);
        }
    }
}
