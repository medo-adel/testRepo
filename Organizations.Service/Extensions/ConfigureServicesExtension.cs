using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizations.Service.AutoMapper;
using Organizations.Data;
using Organizations.DataAccess;
using Organizations.Data.SeedData;
using Organizations.Service.Services;
using System.Reflection;
using Common.StandardInfrastructure.Repository;
using NetCore.AutoRegisterDi;
using Organizations.DataAccess.Repositories;
using Common.StandardInfrastructure.RestSharp;
using Common.StandardInfrastructure.Communication;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using Common.StandardInfrastructure;
using Organizations.Service.Interfaces;

namespace Organizations.Service.Extensions
{
  public static  class ConfigureServicesExtension
    {
        public static string key = "securityIsFirstin2024For100of100";

        public static IServiceCollection ServicesRegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        { 
            services.Configure<CommuncationSetting>(configuration.GetSection("Communcations"));
            services.DatabaseConfig(configuration);
            services.AddAutoMapper(typeof(OrganizationsProfile));
            services.ServicesConfig();
            return services;
        }

        private static void DatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Helper.DecryptString(configuration.GetConnectionString("TAMS"));

            services.AddDbContext<OrganizationsContext>
                (options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging().EnableDetailedErrors());
            services.AddScoped<DbContext, OrganizationsContext>();
        }
        private static void ServicesConfig(this IServiceCollection services)
        {
            services.AddSingleton<IRestSharpContainerAdvanced, RestSharpContainerAdvanced>();
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(DataAccess.Repositories.Base.RepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppDetailsService, AppDetailsService>();
            services.AddSingleton<IDataInitialize, DataInitialize>();
            var assemblyToScan = Assembly.GetAssembly(typeof(OrganizationService));
            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
              .Where(c => c.Name.EndsWith("Service"))
              .AsPublicImplementedInterfaces();
        }

    }
}
