using System.Collections;
using Microsoft.Extensions.Configuration;
using SharedLibrary;

namespace Service_80;

public class ConnectionStringsWrapper(IConfiguration configuration) : IConnectionStringsV2
{
    public IConnectionStringSettings this[string name] 
        => ConnectionStringSettings_80.Create(name, configuration.GetConnectionString(name) ?? "null", "Unknown");

    public IEnumerator<IConnectionStringSettings> GetEnumerator() 
        => new ConnectionStringSettings_80_Enumerator(configuration.GetSection("ConnectionStrings"));

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}