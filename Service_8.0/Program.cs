using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Service_80;
using SharedLibrary;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        // Add appsettings.json settings
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        // Add Machine.config
        var machineConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.System),
            @"..\Microsoft.NET\Framework\v4.0.30319\Config\Machine.config");

        if (File.Exists(machineConfigPath)) 
            config.AddXmlFile(machineConfigPath, optional: false, reloadOnChange: true);

        // Add environment variables
        config.AddEnvironmentVariables();

        // Add app.config settings
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
    });

var host = builder.Build();
var configuration = host.Services.GetRequiredService<IConfiguration>();

Console.WriteLine("Reading appsettings.json file (.NET 8.0)");

var appSettings = new AppSettingsWrapper(configuration);
var connectionStrings = new ConnectionStringsWrapper(configuration);
SettingsConsumer.WriteSettings(appSettings, connectionStrings);