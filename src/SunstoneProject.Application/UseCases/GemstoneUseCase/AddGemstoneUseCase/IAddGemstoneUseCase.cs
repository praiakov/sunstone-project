using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase.AddGemstoneUseCase
{
    public interface IAddGemstoneUseCase
    {
        Task ExecuteAsync(Domain.Entities.Gemstone gemstone);
    }
}
