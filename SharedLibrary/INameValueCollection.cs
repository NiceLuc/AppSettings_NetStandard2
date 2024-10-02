namespace SharedLibrary
{
    // matches interface in UCN.Common.Wrappers
    public interface INameValueCollection
    {
        string this[string name] { get; set; }

        string[] AllKeys { get; }
        string Get(string name);
    }
}