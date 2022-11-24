using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SunstoneProject.Api.Resources.l18n;
using SunstoneProject.Application.Configuration;
using SunstoneProject.Domain.Interfaces;
using SunstoneProject.Application.UseCases.AddGemstoneUseCase;
using SunstoneProject.Application.UseCases.GetAllGemstoneUseCase;
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

            #region UC
            services.AddScoped<IAddGemstoneUseCase, AddGemstoneUseCase>();
            services.AddScoped<IGetAllGemstoneUseCase, GetAllGemstoneUseCase>();
            #endregion

            #region Service
            services.AddScoped<IGemstoneService, GemstoneService>();
            #endregion

            #region Infra
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IGemstoneRepository, GemstoneRepository>();
            #endregion

            services.AddSingleton<IMessages, Messages>();

        }
    }
}
