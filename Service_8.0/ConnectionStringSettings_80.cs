using SharedLibrary;

namespace Service_80;

internal class ConnectionStringSettings_80 : IConnectionStringSettings
{
    public static IConnectionStringSettings Create(string name, string connectionString, string provider) =>
        new ConnectionStringSettings_80
        {
            Name = name,
            ConnectionString = connectionString,
            ProviderName = provider
        };

    public string Name { get; private set; }
    public string ConnectionString { get; private set; }
    public string ProviderName { get; private set; }

}