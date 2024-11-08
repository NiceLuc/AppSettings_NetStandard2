using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using SharedLibrary;

namespace Service48
{
    internal class ConnectionStringsWrapper : IConnectionStrings
    {
        private readonly ConnectionStringSettingsCollection _connectionStrings;

        public ConnectionStringsWrapper(ConnectionStringSettingsCollection connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public IEnumerator<IConnectionStringSettings> GetEnumerator() 
            => new ConnectionStringSettings_48_Enumerator(_connectionStrings);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IConnectionStringSettings this[string name] 
            => ConnectionStringSettings_48.Create(_connectionStrings[name]);
    }
}