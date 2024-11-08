using Microsoft.Extensions.DependencyInjection;
using SharedLibrary;

namespace Service_80;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IAppSettings, AppSettingsWrapper>();
        services.AddSingleton<IConnectionStrings, ConnectionStringsWrapper>();
        services.AddSingleton<SystemSettingsReport>();
        return services;
    }
}