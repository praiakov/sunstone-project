using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase
{
    public interface IGemstoneUseCase
    {
        Task ExecuteAsync(Domain.Entities.Gemstone gemstone);
    }
}
