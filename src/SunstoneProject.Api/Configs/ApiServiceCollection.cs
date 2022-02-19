using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SunstoneProject.Api.Resources.l18n;
using SunstoneProject.Application.Configuration;
using SunstoneProject.Application.Interfaces;
using SunstoneProject.Application.Services.Gemstones.Interfaces;
using SunstoneProject.Application.UseCases.GemstoneUseCase;
using SunstoneProject.Infrastructure.Gemstone;
using SunstoneProject.Infrastructure.Persistence.EntityFramework.Context;
using SunstoneProject.Infrastructure.Persistence.EntityFramework.Repository;
using SunstoneProject.Infrastructure.RabbitMQ;

namespace SunstoneProject.Api.Configs
{
    ///<inheritdoc/>
    public static class ApiServiceCollection
    {
        ///<inheritdoc/>
        public static void AddApiContext(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfiguration = new AppConfiguration();
            configuration.Bind(appConfiguration);
            
            services.AddDbContext<SunstoneContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<SunstoneContext>();

            services.AddScoped<IGemstoneUseCase, GemstoneUseCase>();
            services.AddScoped<IGemstoneService, GemstoneService>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IGemstoneRepository, GemstoneRepository>();

            services.AddSingleton<IMessages, Messages>();

        }
    }
}
