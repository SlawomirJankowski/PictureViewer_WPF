using Microsoft.Win32;
using PictureViewer_WPF.Commands;
using PictureViewer_WPF.Properties;
using System.IO;
using System.Windows.Input;

namespace PictureViewer_WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ImageLocationPath = Settings.Default.SavedImagePath;

            if (string.IsNullOrEmpty(ImageLocationPath))
                IsSliderEnabled = false;
            else 
                IsSliderEnabled = true; 

            OpenImageCommand = new RelayCommand(OpenImage);
            CloseImageCommand = new RelayCommand(CloseImage, CanCloseImage);
            OnWindowClosingCommand = new RelayCommand(OnCloseWindow);

            RefreshImageDetails();
        }


        public ICommand OpenImageCommand { get; set; }
        public ICommand CloseImageCommand { get; set; }
        public ICommand OnWindowClosingCommand { get; set; }


        private double _sliderValue;
        public double SliderValue
        {
            get { return _sliderValue; }
            set 
            { 
                _sliderValue = value;
                OnPropertyChanged();
            }
        }

        private bool _isSliderEnabled;
        public bool IsSliderEnabled
        {
            get { return _isSliderEnabled; }
            set 
            { 
                _isSliderEnabled = value;
                OnPropertyChanged();
            }
        }

        private string _imageLocationPath;
        public string ImageLocationPath
        {
            get { return _imageLocationPath; }
            set
            {
                _imageLocationPath = value;
                OnPropertyChanged();
            }
        }

        private string _imageDetails;
        public string ImageDetails
        {
            get { return _imageDetails; }
            set
            {
                _imageDetails = value;
                OnPropertyChanged();
            }
        }
        
        private bool CanCloseImage(object obj)
        {
            return !string.IsNullOrEmpty(ImageLocationPath);
        }

        private void CloseImage(object obj)
        {
            ClearImageData();
        }

        private void OpenImage(object obj)
        {
            var openImageDialog = new OpenFileDialog();
            openImageDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...|All files (*.*)|*.*";

            if (openImageDialog.ShowDialog() == true)
            {
                ImageLocationPath = openImageDialog.FileName;
            }

            RefreshImageDetails();
            IsSliderEnabled = true;
        }

        private void RefreshImageDetails()
        {
            try { ImageDetails = ImageInfo.ShowImageProperties(ImageLocationPath); }
            catch (FileNotFoundException) { ClearImageData(); }
        }

        private void OnCloseWindow(object obj)
        {
            Settings.Default.SavedImagePath = ImageLocationPath;
            Settings.Default.Save();
        }

        private void ClearImageData()
        {
            ImageLocationPath = null;
            ImageDetails= null;
            SliderValue = 500d;
            IsSliderEnabled = false;
        }
    }
}
