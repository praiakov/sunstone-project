using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using SunstoneProject.Api.Configs;
using SunstoneProject.Api.Filters;
using SunstoneProject.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace SunstoneProject.Api
{
    ///<inheritdoc/>
    public class Startup
    {
        ///<inheritdoc/>
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        ///<inheritdoc/>
        public IConfiguration Configuration { get; }

        ///<inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.Configure<AppConfiguration>(Configuration);

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

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = ApiVersionInformation.FormatPattern;
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                foreach (var item in ApiVersionInformation.Versions)
                {
                    c.SwaggerDoc(item.ToString(ApiVersionInformation.FormatPattern), new OpenApiInfo
                    {
                        Title = ApiVersionInformation.Name,
                        Version = item.ToString(ApiVersionInformation.FormatPattern),
                        Description = ApiVersionInformation.Description,
                        Contact = new OpenApiContact
                        {
                            Url = ApiVersionInformation.ContactUri,
                            Name = ApiVersionInformation.ContactName
                        }
                    });
                }

                // Set the comments path for the Swagger JSON and UI.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });

            services.Configure<AppConfiguration>(Configuration);
            services.AddApiContext(Configuration);

        }

        ///<inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = string.Concat(ApiVersionInformation.ApiRoutePrefixDocumentation, "/swagger/{documentName}/swagger.json");
                });
                app.UseSwaggerUI(c =>
                {
                    c.EnableFilter();
                    c.ShowExtensions();
                    c.RoutePrefix = ApiVersionInformation.ApiRoutePrefixDocumentation;

                    foreach (var item in ApiVersionInformation.Versions)
                        c.SwaggerEndpoint(
                            string.Concat(ApiVersionInformation.ApiRoutePrefixDocumentation,
                                $"/swagger/{item.ToString(ApiVersionInformation.FormatPattern)}/swagger.json"),
                                $"{item.ToString(ApiVersionInformation.FormatPattern)}");
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
