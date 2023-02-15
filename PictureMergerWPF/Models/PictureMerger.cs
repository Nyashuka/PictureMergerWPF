using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PictureMergerWPF.Models
{
    internal class PictureMerger
    {
        private RenderTargetBitmap _bmp;
        private string[] _files;
        public bool BitmapCreated { get; private set; }
        
        public PictureMerger()
        {
            _bmp = new RenderTargetBitmap(1, 1, 1, 1, PixelFormats.Pbgra32);
            _files = new string[] { };
            BitmapCreated = false;
        }

        public void LoadFiles()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.jpg;*.png)|*.jpg;*.png";
            fileDialog.Multiselect = true;

            if (fileDialog.ShowDialog() == true)
            {
                _files = fileDialog.FileNames;
            }
            else
                return;
        }

        public List<PictureInfo> GetFileList()
        {
            if (_files.Length == 0)
                return new List<PictureInfo>();

            List<PictureInfo> pictures = new List<PictureInfo>();

            for(int i = 0; i < _files.Length; i++)
            {
                pictures.Add(new PictureInfo(i, Path.GetFileName(_files[i]), _files[i]));
            }

            return pictures;
        }

        public void SavePicture()
        {
            _bmp = CreateMergedImage();

            if (_files.Length == 0 || BitmapCreated == false)
                return;

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(_bmp));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Users\Nyashuka\Desktop";
            saveFileDialog.Filter = "Images (*.png)|*.png";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (Stream stream = File.Create(saveFileDialog.FileName))
                        encoder.Save(stream);

                    MessageBox.Show($"Succesfully saved in \n\"{saveFileDialog.FileName}\"");
                }
                catch (Exception error)
                {
                    MessageBox.Show($"Save error: {error.Message}");
                }

            }
        }  

        private int GetWidth(string[] pathes)
        {
            int width = 0;

            for (int i = 0; i < pathes.Length; i++)
            {
                BitmapImage image = new BitmapImage(new Uri(pathes[i]));
                if (width < image.PixelWidth)
                    width = image.PixelWidth;
            }

            return width;
        }

        public RenderTargetBitmap CreateMergedImage()
        {
            int height = 0;
            int width = GetWidth(_files);

            for (int i = 0; i < _files.Length; i++)
            {
                BitmapImage image = new BitmapImage(new Uri(_files[i]));
                height += image.PixelHeight;
            }

            int lastHeight = 0;
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                for (int i = 0; i < _files.Length; i++)
                {
                    BitmapFrame frame1 = BitmapDecoder.Create(new Uri(_files[i]), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                    drawingContext.DrawImage(frame1, new Rect(0, lastHeight, frame1.PixelWidth, frame1.PixelHeight));
                    lastHeight += frame1.PixelHeight;
                }
            }

            RenderTargetBitmap bmp = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            BitmapCreated = true;

            return bmp;
        }
    }
}
