using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase.GetAllGemstoneUseCase
{
    public interface IGetAllGemstoneUseCase
    {
        Task<IEnumerable<Domain.Entities.Gemstone>> GetAsync();
    }
}
