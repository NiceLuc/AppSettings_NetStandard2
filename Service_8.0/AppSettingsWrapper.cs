using Microsoft.Extensions.Configuration;
using SharedLibrary;

namespace Service_80;

public class AppSettingsWrapper(IConfiguration configuration) : IAppSettings
{
    public string this[string name]
    {
        get => configuration[$"AppSettings:{name}"] ?? string.Empty;
        set => configuration[$"AppSettings:{name}"] = value;
    }

    public string[] AllKeys => configuration.AsEnumerable().Select(x => x.Key).ToArray();

    public string Get(string name) => configuration[name] ?? string.Empty;
}