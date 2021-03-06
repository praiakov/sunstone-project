using System.Threading.Tasks;

namespace SunstoneProject.Application.Interfaces
{
    public interface IEventBus
    {
        Task PublishAsync<T>(string queue, T @event);
    }
}
