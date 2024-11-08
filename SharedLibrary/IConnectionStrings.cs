using System.Collections.Generic;

namespace SharedLibrary
{
    // suggested new interface for NETSTANDARD2.0 support!
    public interface IConnectionStrings : IEnumerable<IConnectionStringSettings>
    {
        IConnectionStringSettings this[string name] { get; }
    }
}