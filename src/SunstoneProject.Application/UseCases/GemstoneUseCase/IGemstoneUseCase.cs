using SunstoneProject.Domain.Entities;
using System.Threading.Tasks;

namespace SunstoneProject.Application.UseCases.GemstoneUseCase
{
    public interface IGemstoneUseCase
    {
        Task ExecuteAsync(Gemstone gemstone);
    }
}
