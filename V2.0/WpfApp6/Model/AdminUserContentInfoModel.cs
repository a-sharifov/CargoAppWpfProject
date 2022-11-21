using System.Collections.Generic;
using WpfApp6.Interface;

namespace WpfApp6.Model;
public class AdminUserContentInfoModel : ISerialization 
{
    public Dictionary<string, UserCargoModel>? AllUser { get; set; } = new();
    public UserCargoModel this[string key]
    {
        get => AllUser![key];
        set => AllUser![key] = value;
    }

    public void Add(string key, UserCargoModel value)
    {
        AllUser!.Add(key, value);
    }

    public bool ContainsKey(string key)
    {
        return AllUser!.ContainsKey(key);
    }

    public bool Remove(string key)
    {
        return AllUser!.Remove(key);
    }
}