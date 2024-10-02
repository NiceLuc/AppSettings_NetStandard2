namespace SharedLibrary
{
    // new interface to replace ConnectionStringSettingsCollection dependency
    public interface IConnectionStringSettings
    {
        string Name { get; }
        string ConnectionString { get; }
        string ProviderName { get; }
    }
}