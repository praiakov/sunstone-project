using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SunstoneProject.Application.Configuration;
using SunstoneProject.Application.Interfaces;
using SunstoneProject.Application.Services.Gemstones.Interfaces;
using System;
using System.Threading.Tasks;

namespace SunstoneProject.Infrastructure.Gemstone
{
    public class GemstoneService : IGemstoneService
    {
        private readonly IGemstoneRepository _gemstoneRepository;
        private readonly IEventBus _eventBus;
        private readonly ILogger<GemstoneService> _logger;
        private readonly AppConfiguration _appConfiguration;

        public GemstoneService(IGemstoneRepository gemstoneRepository, IEventBus eventBus,
            ILogger<GemstoneService> logger, IOptions<AppConfiguration> appConfiguration)
        {
            _gemstoneRepository = gemstoneRepository;
            _eventBus = eventBus;
            _logger = logger;
            _appConfiguration = appConfiguration.Value;
        }

        public async Task SendGemstone(Domain.Entities.Gemstone gemstone)
        {
            _logger.LogInformation($"GemstoneService.SendGemstone({gemstone.Id})");

            var stone = MapGemstone(gemstone);

            try
            {
                var result = await _gemstoneRepository.Add(gemstone);

                if(result == 1)
                {
                    _logger.LogInformation($"GemstoneService.SendGemstone({gemstone.Id}).PublishAsync");

                    await _eventBus.PublishAsync(_appConfiguration.Queue, stone);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GemstoneService.SendGemstone({ex})");
                throw;
            }
        }

        #region Private methods
        private Application.Services.Gemstones.Models.Gemstone MapGemstone(Domain.Entities.Gemstone gemstone)
        {
            var stone = new Application.Services.Gemstones.Models.Gemstone();

            stone.Id = gemstone.Id;
            stone.Carat = gemstone.Carat;
            stone.Clarity = gemstone.Clarity;
            stone.Color = gemstone.Color;

            return stone;

        }
        #endregion
    }
}
