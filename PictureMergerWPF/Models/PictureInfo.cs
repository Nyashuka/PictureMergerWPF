
namespace PictureMergerWPF.Models
{
    internal class PictureInfo
    {
        public PictureInfo(int id, string name, string path)
        {
            Id = id;
            Name = name;
            Path = path;
        }

        public int Id { get; }
        public string Name { get; }
        public string Path{ get; }
    }
}
