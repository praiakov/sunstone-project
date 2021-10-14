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
        private readonly IEventBus _eventBus;
        private readonly ILogger<GemstoneService> _logger;
        private readonly AppConfiguration _appConfiguration;

        public GemstoneService(IEventBus eventBus, ILogger<GemstoneService> logger, IOptions<AppConfiguration> appConfiguration)
        {
            _eventBus = eventBus;
            _logger = logger;
            _appConfiguration = appConfiguration.Value;
        }

        public async Task SendGemstone(Domain.Entities.Gemstone gemstone)
        {
            var stone = MapGemstone(gemstone);

            try
            {
                _logger.LogInformation($"GemstoneService.SendGemstone({gemstone.Id})");

                await _eventBus.PublishAsync(_appConfiguration.Queue, stone);
            }
            catch (Exception ex)
            {
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
