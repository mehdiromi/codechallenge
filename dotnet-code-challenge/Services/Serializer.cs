using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    }
}
