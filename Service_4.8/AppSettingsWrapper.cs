using System.Collections.Specialized;
using SharedLibrary;

namespace Service48
{
    internal class AppSettingsWrapper : IAppSettings
    {
        private readonly NameValueCollection _appSettings;

        public AppSettingsWrapper(NameValueCollection appSettings)
        {
            _appSettings = appSettings;
        }

        public string this[string name]
        {
            get => _appSettings[name];
            set => _appSettings[name] = value;
        }

        public string[] AllKeys => _appSettings.AllKeys;

        public string Get(string name) => _appSettings.Get(name);
    }
}