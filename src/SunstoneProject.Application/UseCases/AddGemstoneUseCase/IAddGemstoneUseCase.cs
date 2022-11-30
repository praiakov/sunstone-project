using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases
{
    public interface IAddGemstoneUseCase
    {
        Task ExecuteAsync(Domain.Entities.Gemstone gemstone);
    }
}
