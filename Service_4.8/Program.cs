using System;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary;

namespace Service48
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var provider = ConfigureServices(services =>
            {
                // configure DI
                services.AddApplicationServices();
            });

            Console.WriteLine("Reading app.config file (.NET 4.8)");
            var report = provider.GetService<SystemSettingsReport>(); // <== netstandard2.0 type
            report.WriteSettings();
        }

        #region Boilerplate Code
        private static IServiceProvider ConfigureServices(Action<IServiceCollection> configure)
        {
            var services = new ServiceCollection();
            configure?.Invoke(services);
            return services.BuildServiceProvider();
        }
        #endregion
    }
}
