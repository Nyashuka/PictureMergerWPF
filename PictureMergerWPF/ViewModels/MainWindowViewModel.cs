using PictureMergerWPF.Infrastructure.Commands;
using PictureMergerWPF.Models;
using PictureMergerWPF.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace PictureMergerWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Title
        private string _title = "Picture Merger =)";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Picture Merger
        private PictureMerger _pictureMerger;
        private List<PictureInfo> _selectedPictures;

        public List<PictureInfo> SelectedPictures
        {
            get => _selectedPictures;
            set => Set(ref _selectedPictures, value); 
        }

        #endregion

        #region Commands
        #region LoadFilesCommand
        public ICommand LoadFilesCommand { get; }

        private bool CanLoadFilesCommandExecute(object p) => true;
        private void OnLoadFilesCommandExecute(object p)
        {
            _pictureMerger.LoadFiles();
            SelectedPictures = _pictureMerger.GetFileList();
        }
        #endregion

        #region SaveMergedPictureCommand
        public ICommand SaveMergedPictureCommand { get; }

        private bool CanSaveMergedPictureCommandExecute(object p) => true;
        private void OnSaveMergedPictureCommandExecute(object p)
        {
            _pictureMerger.SavePicture();
        }
        #endregion

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            LoadFilesCommand = new LambdaCommand(OnLoadFilesCommandExecute, CanLoadFilesCommandExecute);
            SaveMergedPictureCommand = new LambdaCommand(OnSaveMergedPictureCommandExecute, CanSaveMergedPictureCommandExecute);
            _pictureMerger = new PictureMerger();
            _selectedPictures = new List<PictureInfo>();
        }
        #endregion
    }
}
