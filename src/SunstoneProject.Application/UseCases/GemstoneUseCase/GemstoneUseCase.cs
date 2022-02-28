using Microsoft.Extensions.Logging;
using SunstoneProject.Application.Services.Gemstones.Interfaces;
using SunstoneProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase
{
    public class GemstoneUseCase : IGemstoneUseCase
    {
        private readonly ILogger<GemstoneUseCase> _logger;
        private readonly IGemstoneService _gemstoneService;

        public GemstoneUseCase(ILogger<GemstoneUseCase> logger, IGemstoneService gemstoneService)
        {
            _logger = logger;
            _gemstoneService = gemstoneService;
        }


        public async Task ExecuteAsync(Domain.Entities.Gemstone gemstone)
        {
            _logger.LogInformation($"GemstoneUseCase.ExecuteAsync()");

            await _gemstoneService.SendGemstone(gemstone);
        }

        public async Task<IEnumerable<Gemstone>> GetAsync()
        {
            _logger.LogInformation($"GemstoneUseCase.GetAsync()");

           return await _gemstoneService.GetGemstones();
        }
    }
}
