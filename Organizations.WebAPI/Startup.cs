using Common.StandardInfrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Common.StandardInfrastructure.ConfigExtensions;
using Organizations.Service.Extensions;
using Organizations.WebAPI.AppExtensions;
using Newtonsoft.Json;
using Organizations.Service.Interfaces;
using Organizations.Service.Services;

namespace Organizations.WebAPI
{
    /// <inheritdoc />
    public class Startup
    {
        /// <inheritdoc />
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <inheritdoc />
        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {          
            services.ServicesRegisterCommonConfiguration(Configuration);
            services.ServicesRegisterConfiguration(Configuration);
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).AddDataAnnotationsLocalization();
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Define a class that provides the mechanisms to configure an application's request pipline</param>
        /// <param name="env">Provides information about the web hosting environment an application is running in</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();
            AppServicesHelper.Services = app.ApplicationServices;
            app.ConfigureApp(env, Configuration);
        }
    }
}
