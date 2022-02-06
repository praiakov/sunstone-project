using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using SunstoneProject.Api.Configs;
using SunstoneProject.Api.Filters;
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
                .AddControllers(opt => 
                {
                    opt.Filters.Add(typeof(ExceptionFilter));
                    opt.Filters.Add(typeof(ValidateModelStateFilter));
                })
                .AddNewtonsoftJson(x => x.SerializerSettings.Converters.Add(new StringEnumConverter()))
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>()); ;

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

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                 opt.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGenNewtonsoftSupport();
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
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SunstoneProject.Api v1");
                    c.RoutePrefix = string.Empty;
                });
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
