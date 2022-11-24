using System.Threading.Tasks;

namespace SunstoneProject.Domain.Interfaces
{
    public interface IEventBus
    {
        Task PublishAsync<T>(string queue, T @event);
    }
}
