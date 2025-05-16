using System;
using Common.StandardInfrastructure.Events;
using Microsoft.Extensions.Options;

namespace Common.StandardInfrastructure
{
    public static class AppServicesHelper
    {
        private static IServiceProvider _services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get => _services;
            set
            {
                if (_services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                _services = value;
            } 
        }
        /// <summary>
        /// Configuration settings from app-setting.json.
        /// </summary>
        public static RabbitMqSetting RabbitMqConfig
        {
            get
            {
                //This works to get file changes.
                var setting = _services.GetService(typeof(IOptionsMonitor<RabbitMqSetting>)) as IOptionsMonitor<RabbitMqSetting>;
                var config = setting?.CurrentValue;

                return config;
            }
        }
    }
}
