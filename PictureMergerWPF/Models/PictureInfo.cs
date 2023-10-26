
using System.Windows.Input;
using System.Windows;
using PictureMergerWPF.Infrastructure.Commands;
using System;

namespace PictureMergerWPF.Models
{
    internal class PictureInfo : IComparable<PictureInfo>
    {
        public PictureInfo(int id, string name, string path)
        {
            Id = id;
            Name = name;
            Path = path;

            ChangeFilePositionCommand = new LambdaCommand(OnToUpChangeFilePositionCommand, CanChangeFilePositionCommand);
        }

        public int Id { get; }
        public string Name { get; }
        public string Path { get; }

        public ICommand ChangeFilePositionCommand { get; }

        public int CompareTo(PictureInfo? other)
        {
            return other.Id.CompareTo(Id);
        }

        private bool CanChangeFilePositionCommand(object p) => true;
        private void OnToUpChangeFilePositionCommand(object p)
        {
            Application.Current.Shutdown();
        }
    }
}
