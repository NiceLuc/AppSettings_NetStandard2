using System.Collections.Generic;

namespace SharedLibrary
{
    // suggested new interface for NETSTANDARD2.0 support!
    public interface IConnectionStringsV2 : IEnumerable<IConnectionStringSettings>
    {
        IConnectionStringSettings this[string name] { get; }
    }
}