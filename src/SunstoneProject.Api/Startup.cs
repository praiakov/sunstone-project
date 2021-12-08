using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SunstoneProject.Api.Configs;
using SunstoneProject.Application.Configuration;
using System.Collections.Generic;
using System.Globalization;

namespace SunstoneProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();

            services
                .AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());  ;

            services.Configure<RequestLocalizationOptions>(opt => 
            {
                var supportedCultures = new List<CultureInfo> {
                                                        new CultureInfo("en-US"),
                                                        new CultureInfo("pt-BR"),
                                                     };
                opt.DefaultRequestCulture = new RequestCulture("pt-BR");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
                opt.RequestCultureProviders.Clear();
                opt.RequestCultureProviders.Add(new CustomRequestCulture());

            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SunstoneProject.Api", Version = "v1" });
            });

            services.Configure<AppConfiguration>(Configuration);
            services.AddApiContext(Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SunstoneProject.Api v1"));
            }

            app.UseRouting();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
