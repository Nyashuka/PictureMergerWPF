using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureMergerWPF.Models
{
    [Serializable]
    public class Pathes
    {
        [JsonConstructor]
        public Pathes([JsonProperty("save_path")] string savePath, [JsonProperty("load_path")] string loadPath)
        {
            SavePath = savePath;
            LoadPath = loadPath;
        }

        [JsonProperty("save_path")]
        public string SavePath { get; }
        
        [JsonProperty("load_path")]
        public string LoadPath { get; }
    }
}
