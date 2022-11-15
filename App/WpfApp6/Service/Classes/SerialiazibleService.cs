using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Interface;

namespace WpfApp6.Service.Classes
{
    public static class SerialiazibleService
    {
        public static string Serialization(ISerialization? item)
        {
            var Settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            return JsonConvert.SerializeObject(item, Settings);
        }

        public static T? Deserialization<T>(string? item) where T: class
        {
            var Settings = new JsonSerializerSettings()
            {                
                TypeNameHandling = TypeNameHandling.All,
            };

            if (item != null)
            {
                return JsonConvert.DeserializeObject<T>(item);
            }
            else return null;
        }

    }
}
