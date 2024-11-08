using System;

namespace SharedLibrary
{
    /// <summary>
    /// This is a class defined in a NETSTANDARD2.0 library that can be used in .NET8.0 and .NET4.8 applications.
    /// </summary>
    public class SystemSettingsReport
    {
        private readonly IAppSettings _appSettings;
        private readonly IConnectionStrings _connectionStrings;

        public SystemSettingsReport(IAppSettings appSettings, IConnectionStrings connectionStrings)
        {
            _appSettings = appSettings;
            _connectionStrings = connectionStrings;
        }

        public void WriteSettings()
        {
            Console.WriteLine("Settings:");
            foreach (var key in _appSettings.AllKeys)
            {
                Console.WriteLine($"  Key: {key}, Value: {_appSettings[key]}");
            }

            Console.WriteLine("Connection Strings:");
            foreach (var connectionSettings in _connectionStrings)
            {
                Console.WriteLine($"  Name: {connectionSettings.Name}, Value: {connectionSettings}");
            }

            Console.WriteLine("Done!");
        }
    }
}
