using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using SharedLibrary;

namespace Service48
{
    internal class ConnectionStringSettings_48_Enumerator : IEnumerator<IConnectionStringSettings>
    {
        private readonly ConnectionStringSettingsCollection _enumerator;
        private int _currentIndex;

        public ConnectionStringSettings_48_Enumerator(ConnectionStringSettingsCollection enumerator)
        {
            _enumerator = enumerator;
        }

        public bool MoveNext()
        {
            if (_currentIndex >= _enumerator.Count)
                return false;

            _currentIndex++;

            return _currentIndex < _enumerator.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IConnectionStringSettings Current 
            => ConnectionStringSettings_48.Create(_enumerator[_currentIndex]);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // no op
        }
    }
}