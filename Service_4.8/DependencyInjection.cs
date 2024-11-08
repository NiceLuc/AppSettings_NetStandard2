using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary;

namespace Service48
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppSettings>(_ 
                => new AppSettingsWrapper(ConfigurationManager.AppSettings));

            services.AddSingleton<IConnectionStrings>(_ 
                => new ConnectionStringsWrapper(ConfigurationManager.ConnectionStrings));

            services.AddSingleton<SystemSettingsReport>();
            return services;
        }
    }
}