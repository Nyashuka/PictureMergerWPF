using System.IO;
using Newtonsoft.Json;

namespace PictureMergerWPF.Infrastructure
{
    internal class Serializator
    {
        public static Serializator Instance { get; } = new Serializator(); 

        public void Serialize<T>(T model, string path)
        {
            var jsonContent = JsonConvert.SerializeObject(model);

            File.WriteAllText(path, jsonContent);
        }

        public T Deserialize<T>(string path)
        {
            var jsonContent = File.ReadAllText(path);

            if (string.IsNullOrEmpty(jsonContent))
                throw new System.NullReferenceException();

            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
