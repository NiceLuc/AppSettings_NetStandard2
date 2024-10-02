using Microsoft.Extensions.Configuration;
using SharedLibrary;

namespace Service_80;

public class AppSettingsWrapper : IAppSettings
{
    private readonly IConfiguration _configuration;

    public AppSettingsWrapper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string this[string name]
    {
        get => _configuration[$"AppSettings:{name}"] ?? string.Empty;
        set => _configuration[$"AppSettings:{name}"] = value;
    }

    public string[] AllKeys => _configuration.AsEnumerable().Select(x => x.Key).ToArray();

    public string Get(string name) => _configuration[name] ?? string.Empty;
}