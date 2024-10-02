using System;
using System.Configuration;
using SharedLibrary;

namespace Service48
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var appSettings = new AppSettingsWrapper(ConfigurationManager.AppSettings);
            var connectionStrings = new ConnectionStringsWrapper(ConfigurationManager.ConnectionStrings);

            Console.WriteLine("Reading app.config file (.NET 4.8)");

            SettingsConsumer.WriteSettings(appSettings, connectionStrings);
        }
    }
}
