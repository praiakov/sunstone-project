using Microsoft.Extensions.Logging;
using SunstoneProject.Application.Services.Gemstones.Interfaces;
using SunstoneProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase.GetAllGemstoneUseCase
{
    public class GetAllGemstoneUseCase : IGetAllGemstoneUseCase
    {
        private readonly ILogger<GetAllGemstoneUseCase> _logger;
        private readonly IGemstoneService _gemstoneService;

        public GetAllGemstoneUseCase(ILogger<GetAllGemstoneUseCase> logger, IGemstoneService gemstoneService)
        {
            _logger = logger;
            _gemstoneService = gemstoneService;
        }

        public async Task<IEnumerable<Gemstone>> GetAsync()
        {
            _logger.LogInformation($"GetAllGemstoneUseCase.GetAsync()");

            return await _gemstoneService.GetGemstones();
        }
    }
}
