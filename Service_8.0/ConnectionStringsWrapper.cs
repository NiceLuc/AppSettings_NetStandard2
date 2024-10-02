using System.Collections;
using Microsoft.Extensions.Configuration;
using SharedLibrary;

namespace Service_80;

public class ConnectionStringsWrapper : IConnectionStringsV2
{
    private readonly IConfiguration _configuration;

    public ConnectionStringsWrapper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConnectionStringSettings this[string name] 
        => ConnectionStringSettings_80.Create(name, _configuration.GetConnectionString(name) ?? "null", "Unknown");

    public IEnumerator<IConnectionStringSettings> GetEnumerator() 
        => new ConnectionStringSettings_80_Enumerator(_configuration.GetSection("ConnectionStrings"));

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}