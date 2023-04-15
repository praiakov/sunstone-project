using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SunstoneProject.Application.Configuration;
using SunstoneProject.Domain.Interfaces;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SunstoneProject.Infrastructure.RabbitMQ
{
    public class EventBus : IEventBus
    {
        private readonly ILogger<EventBus> _logger;
        private readonly AppConfiguration _appConfiguration;

        public EventBus(ILogger<EventBus> logger, IOptions<AppConfiguration> appConfiguration)
        {
            _logger = logger;
            _appConfiguration = appConfiguration.Value;
        }

        public async Task PublishAsync<T>(string queue, T @event)
        {
            _logger.LogInformation("RabbitMQ.PublishAsync # queue {queue}", queue);

            var factory = new ConnectionFactory()
            {
                HostName = _appConfiguration.RabbitMQSettings.HostName,
                UserName = _appConfiguration.RabbitMQSettings.UserName,
                Password = _appConfiguration.RabbitMQSettings.Password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
        }
    }
}
