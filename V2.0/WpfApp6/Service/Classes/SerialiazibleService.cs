using Newtonsoft.Json;
using WpfApp6.Interface;

namespace WpfApp6.Service.Classes;
public static class SerialiazibleService
{
    private static JsonSerializerSettings _settings;
    static SerialiazibleService()
    {
        _settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore,
        };
    }
    public static string Serialization(ISerialization item)
    {
        return JsonConvert.SerializeObject(item, _settings);
    }

    public static T? Deserialization<T>(string? item)
    {
        return JsonConvert.DeserializeObject<T?>(item!, _settings);
    }
}