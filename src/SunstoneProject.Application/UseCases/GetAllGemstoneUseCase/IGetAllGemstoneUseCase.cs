using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GetAllGemstoneUseCase
{
    public interface IGetAllGemstoneUseCase
    {
        Task<IEnumerable<Domain.Entities.Gemstone>> GetAsync();
    }
}
