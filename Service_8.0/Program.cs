using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Service_80;
using SharedLibrary;

var provider = ConfigureServices(args, services =>
{
    // configure DI
    services.AddApplicationServices();
});

Console.WriteLine("Reading appsettings.json file (.NET 8.0)");
var report = provider.GetRequiredService<SystemSettingsReport>(); // <== netstandard2.0 type
report.WriteSettings();

#region Boilerplate Code

static IServiceProvider ConfigureServices(string[] args, Action<IServiceCollection>? configure)
{
    var builder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            // Add environment variables
            config.AddEnvironmentVariables();

            // Add (.NET8) appsettings.json settings
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            // Add (.NET48) machine.config settings
            var machineConfigPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                @"..\Microsoft.NET\Framework\v4.0.30319\Config\Machine.config");

            if (File.Exists(machineConfigPath))
                config.AddXmlFile(machineConfigPath, optional: false, reloadOnChange: true);

            // Add (.NET48) app.config settings
            var appConfig = ConfigurationManager.AppSettings;
            if (appConfig is {Count: > 0})
            {
                var appConfigDict = new Dictionary<string, string>();
                foreach (var key in appConfig.AllKeys)
                {
                    appConfigDict[key ?? ""] = appConfig[key] ?? string.Empty;
                }

                config.AddInMemoryCollection(appConfigDict!);
            }
        })
        .ConfigureServices((context, services) =>
        {
            configure?.Invoke(services);
        });

    var host = builder.Build();
    return host.Services;
}

#endregion
