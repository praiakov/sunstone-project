using SunstoneProject.Application.Services.Gemstones.Interfaces;
using System.Threading.Tasks;

namespace SunstoneProject.Infrastructure.Gemstone
{
    public class GemstoneService : IGemstoneService
    {
        public async Task SendGemstone(Domain.Entities.Gemstone gemstone)
        {
            var stone = MapGemstone(gemstone);            
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
