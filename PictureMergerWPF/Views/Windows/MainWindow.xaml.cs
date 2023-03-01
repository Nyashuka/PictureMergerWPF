using PictureMergerWPF.Models;
using PictureMergerWPF.ViewModels;
using System.Windows;

namespace PictureMergerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowViewModel _mainViewModel;
        public MainWindow()
        {
            InitializeComponent();

            _mainViewModel = (MainWindowViewModel)App.Current.MainWindow.DataContext;
        }

        public void OnToUpButton_Click(object p, RoutedEventArgs e)
        {
            if (_mainViewModel.SelectedPictures == null)
                return;

            PictureInfo obj = ((FrameworkElement)p).DataContext as PictureInfo;
            
            if (obj == null)
                return;

            if (obj.Id > 0)
            {
                

                _mainViewModel.SelectedPictures[obj.Id] = new PictureInfo(obj.Id,
                                                                          _mainViewModel.SelectedPictures[obj.Id - 1].Name,
                                                                          _mainViewModel.SelectedPictures[obj.Id - 1].Path);
                _mainViewModel.SelectedPictures[obj.Id - 1] = new PictureInfo(obj.Id - 1,
                                                                          obj.Name,
                                                                          _mainViewModel.SelectedPictures[obj.Id - 1].Path);
            }

            FilesList_DataGrid.ItemsSource = null;
            FilesList_DataGrid.ItemsSource = _mainViewModel.SelectedPictures;
        }
    }
}
