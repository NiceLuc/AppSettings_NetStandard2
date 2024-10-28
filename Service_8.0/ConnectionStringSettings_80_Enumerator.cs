using System.Collections;
using Microsoft.Extensions.Configuration;
using SharedLibrary;

namespace Service_80;

public class ConnectionStringSettings_80_Enumerator : IEnumerator<IConnectionStringSettings>
{
    private readonly Dictionary<string, string> _map;
    private Dictionary<string, string>.KeyCollection.Enumerator? _enumerator;

    public ConnectionStringSettings_80_Enumerator(IConfigurationSection connectionStrings)
    {
        _map = connectionStrings.GetChildren().ToDictionary(x => x.Key, x => x.Value ?? "null");
        _enumerator = null;
    }

    public bool MoveNext() => _enumerator?.MoveNext() ?? false;

    public void Reset() => _enumerator = _map.Keys.GetEnumerator();

    public IConnectionStringSettings Current
    {
        get
        {
            if(_enumerator == null)
                throw new InvalidOperationException("Call MoveNext() first");

            var name = _enumerator.Value.Current;
            return ConnectionStringSettings_80.Create(name, _map[name], "SqlProvider");
        }
    }

    object? IEnumerator.Current => Current;

    public void Dispose()
    {
        // no op
    }
}