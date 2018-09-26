namespace dotnet_code_challenge.Services
{
    public interface ISerializer
    {
        T JsonDeserializer<T>(string filePath) where T : class;

        T XmlDeserializer<T>(string filePath) where T : class;

    }
}