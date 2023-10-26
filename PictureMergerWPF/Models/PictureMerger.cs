using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PictureMergerWPF.Infrastructure;

namespace PictureMergerWPF.Models
{
    internal class PictureMerger
    {
        private RenderTargetBitmap _bmp;
        private string[] _files;
        public bool BitmapCreated { get; private set; }
        private Pathes _pathes;
        private string _configPath = "config.json";

        public PictureMerger()
        {
            _bmp = new RenderTargetBitmap(1, 1, 1, 1, PixelFormats.Pbgra32);
            _files = new string[] { };
            BitmapCreated = false;
            _pathes = LoadPathes();
        }

        private void SavePathes(string savePath, string loadPath)
        {
            _pathes = new Pathes(savePath, loadPath);
            Serializator.Instance.Serialize(_pathes, _configPath);
        }

        private Pathes LoadPathes()
        {
            if (!File.Exists(_configPath))
                return new Pathes("", "");

            return Serializator.Instance.Deserialize<Pathes>(_configPath);
        }

        public void LoadFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = _pathes.LoadPath;
            openFileDialog.Filter = "Image Files(*.jpg;*.png;*.webp)|*.jpg;*.png;*.webp";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                _files = openFileDialog.FileNames;
                if (_files.Length > 0)
                    SavePathes(_pathes.SavePath, Path.GetDirectoryName(_files[0]));
            }
        }

        public List<PictureInfo> GetFileList()
        {
            if (_files.Length == 0)
                return new List<PictureInfo>();

            List<PictureInfo> pictures = new List<PictureInfo>();

            for (int i = 0; i < _files.Length; i++)
            {
                pictures.Add(new PictureInfo(i, Path.GetFileName(_files[i]), _files[i]));
            }

            return pictures;
        }

        public void StartSavePictureToFile()
        {
            CallSaveFileDialog();
        }

        private void SavePictureToFile(string pathForFile)
        {
            try
            {
                BitmapEncoder encoder = CreateEncoderByFileType(Path.GetExtension(pathForFile));

                _bmp = CreateMergedImage();

                if (_files.Length == 0 || BitmapCreated == false)
                    return;

                encoder.Frames.Add(BitmapFrame.Create(_bmp));

                

                using (Stream stream = File.Create(pathForFile))
                    encoder.Save(stream);

                MessageBox.Show($"Succesfully saved in \n\"{pathForFile}\"");

                string? path = Path.GetDirectoryName(pathForFile);
                if (!string.IsNullOrEmpty(path))
                {
                    SavePathes(path, _pathes.LoadPath);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Save error: {error}");
            }
            finally
            {
                _bmp.Clear();
            }
        }

        private BitmapEncoder CreateEncoderByFileType(string fileType)
        {
            BitmapEncoder encoder;
            if (fileType == ".png")
                encoder = new PngBitmapEncoder();
            else
                throw new Exception("Unvailable file format");

            return encoder;
        }

        private void CallSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = _pathes.SavePath;
            saveFileDialog.Filter = "Images (*.png)|*.png";

            if (saveFileDialog.ShowDialog() == true)
            {
                Task.Run(() =>
                {
                    SavePictureToFile(saveFileDialog.FileName);
                });  
            }
        }

        private int GetWidth(string[] pathes)
        {
            int width = 0;

            for (int i = 0; i < pathes.Length; i++)
            {
                var bitmap = new BitmapImage();
                var stream = File.OpenRead(pathes[i]);

                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                if (width < bitmap.PixelWidth)
                    width = bitmap.PixelWidth;
                stream.Close();
                stream.Dispose();
            }

            return width;
        }

        public void ChangePos(int firstId, int secondId)
        {
            (_files[firstId], _files[secondId]) = (_files[secondId], _files[firstId]);
        }

        public RenderTargetBitmap CreateMergedImage()
        {
            int width = GetWidth(_files);

            int lastHeight = 0;
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                for (int i = 0; i < _files.Length; i++)
                {
                    BitmapFrame frame = 
                        BitmapDecoder.Create(new Uri(_files[i]), BitmapCreateOptions.None, BitmapCacheOption.Default).Frames[0];
                    drawingContext.DrawImage(frame, new Rect(0, lastHeight, frame.PixelWidth, frame.PixelHeight));
                    lastHeight += frame.PixelHeight;
                }
            }

            RenderTargetBitmap bmp = new RenderTargetBitmap(width, lastHeight, 72, 72, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            BitmapCreated = true;

            return bmp;
        }
    }
}
