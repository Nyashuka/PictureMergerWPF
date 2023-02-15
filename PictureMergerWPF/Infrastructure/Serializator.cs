using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace Assets.notebook_project.CodeBase
{
    internal class Serializator
    {
        private static Serializator _instance;
        public static Serializator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Serializator();

                return _instance;
            }
        }

        public void Serialize<T>(T model, string path)
        {
            var jsonContent = JsonConvert.SerializeObject(model);

            File.WriteAllText(path, jsonContent);
        }

        public T Deserialize<T>(string path)
        {
            var jsonContent = File.ReadAllText(path);

            if (jsonContent == null || jsonContent == "")
                throw new System.NullReferenceException();

            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
