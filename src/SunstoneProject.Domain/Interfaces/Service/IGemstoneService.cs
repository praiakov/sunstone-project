using SunstoneProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Domain.Interfaces
{
    public interface IGemstoneService
    {
        Task SendGemstone(Gemstone gemstone);
        Task<IEnumerable<Gemstone>> GetGemstones();
    }
}
