using SunstoneProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Application.Interfaces.Service
{
    public interface IGemstoneService
    {
        Task SendGemstone(Gemstone gemstone);
        Task<IEnumerable<Gemstone>> GetGemstones();
    }
}
