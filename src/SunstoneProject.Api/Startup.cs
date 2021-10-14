using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SunstoneProject.Application.Configuration;
using SunstoneProject.Application.Interfaces;
using SunstoneProject.Application.Services.Gemstones.Interfaces;
using SunstoneProject.Application.UseCases.GemstoneUseCase;
using SunstoneProject.Infrastructure.Gemstone;
using SunstoneProject.Infrastructure.RabbitMQ;

namespace SunstoneProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SunstoneProject.Api", Version = "v1" });
            });

            services.AddScoped<IGemstoneUseCase, GemstoneUseCase>();
            services.AddScoped<IGemstoneService, GemstoneService>();
            services.AddScoped<IEventBus, EventBus>();

            services.Configure<AppConfiguration>(Configuration.GetSection("RabbitMQSettings"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SunstoneProject.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
