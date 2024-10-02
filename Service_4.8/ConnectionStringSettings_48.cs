using System.Configuration;
using SharedLibrary;

namespace Service48
{
    internal class ConnectionStringSettings_48 : IConnectionStringSettings
    {
        public static ConnectionStringSettings_48 Create(ConnectionStringSettings connectionStringSettings) =>
            new ConnectionStringSettings_48
            {
                Name = connectionStringSettings.Name,
                ConnectionString = connectionStringSettings.ConnectionString,
                ProviderName = connectionStringSettings.ProviderName
            };

        public string Name { get; private set; }
        public string ConnectionString { get; private set; }
        public string ProviderName { get; private set; }
    }
}