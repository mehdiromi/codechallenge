using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
namespace dotnet_code_challenge.Services
{
    public class Serializer : ISerializer
    {
        public T JsonDeserializer<T>(string filePath) where T : class
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public T XmlDeserializer<T>(string filePath) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filePath))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
