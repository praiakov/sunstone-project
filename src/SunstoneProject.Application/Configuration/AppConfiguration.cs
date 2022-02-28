namespace SunstoneProject.Application.Configuration
{
    public class AppConfiguration
    {
       public RabbitMQSettings RabbitMQSettings { get; set; }
    }

    public class RabbitMQSettings
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Queue { get; set; }
    }
}
