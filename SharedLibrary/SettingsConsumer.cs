using System;

namespace SharedLibrary
{
    public class SettingsConsumer
    {
        public static void WriteSettings(IAppSettings appSettings, IConnectionStringsV2 connectionStrings)
        {
            Console.WriteLine("Settings:");
            foreach (var key in appSettings.AllKeys)
            {
                Console.WriteLine($"  Key: {key}, Value: {appSettings[key]}");
            }

            Console.WriteLine("Connection Strings:");
            foreach (var connectionSettings in connectionStrings)
            {
                Console.WriteLine($"  Name: {connectionSettings.Name}, Value: {connectionSettings}");
            }

            Console.WriteLine("Done!");
        }
    }
}
