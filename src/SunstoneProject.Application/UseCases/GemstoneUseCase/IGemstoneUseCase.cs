using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase
{
    public interface IGemstoneUseCase
    {
        Task ExecuteAsync(Domain.Entities.Gemstone gemstone);
        Task<IEnumerable<Domain.Entities.Gemstone>> GetAsync();
    }
}
