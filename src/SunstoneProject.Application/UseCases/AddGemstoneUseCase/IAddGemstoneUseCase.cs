using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.AddGemstoneUseCase
{
    public interface IAddGemstoneUseCase
    {
        Task ExecuteAsync(Domain.Entities.Gemstone gemstone);
    }
}
