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
            _pictureMerger.StartSavePictureToFile();
        }
        #endregion

        #region Change image position
        public ICommand ChangeToUpFilePositionCommand { get; }
        public ICommand ChangeToDownFilePositionCommand { get; }

        private bool CanChangeFilePositionCommand(object p) => true;
        private void OnToUpChangeFilePositionCommand(object p)
        {
            if (SelectedPictures == null)
                return;

            PictureInfo obj = p as PictureInfo;

            if (obj == null)
                return;

            if(obj.Id > 0)
            {
                _pictureMerger.ChangePos(obj.Id, obj.Id - 1);
            }
            else if(obj.Id == 0)
            {
                _pictureMerger.ChangePos(obj.Id, SelectedPictures.Count - 1);
            }

            SelectedPictures = _pictureMerger.GetFileList();
        }
        private void OnToDownChangeFilePositionCommand(object p)
        {
            if (SelectedPictures == null)
                return;

            PictureInfo obj = p as PictureInfo;

            if (obj == null)
                return;

            if (obj.Id < SelectedPictures.Count - 1)
            {
                _pictureMerger.ChangePos(obj.Id, obj.Id + 1);
            }
            else if(obj.Id == SelectedPictures.Count - 1)
            {
                _pictureMerger.ChangePos(obj.Id, 0);
            }

            SelectedPictures = _pictureMerger.GetFileList();
        }
        #endregion


        

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            LoadFilesCommand = new LambdaCommand(OnLoadFilesCommandExecute, CanLoadFilesCommandExecute);
            SaveMergedPictureCommand = new LambdaCommand(OnSaveMergedPictureCommandExecute, CanSaveMergedPictureCommandExecute);
            ChangeToUpFilePositionCommand = new LambdaCommand(OnToUpChangeFilePositionCommand, CanChangeFilePositionCommand);
            ChangeToDownFilePositionCommand = new LambdaCommand(OnToDownChangeFilePositionCommand, CanChangeFilePositionCommand);
            
            _pictureMerger = new PictureMerger();
            _selectedPictures = new List<PictureInfo>();
        }
        #endregion
    }
}
