using PictureViewer_WPF.ViewModels;
using System.Windows;

namespace PictureViewer_WPF.Views

{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            DataContext = new SplashScreenViewModel();
        }


    }
}
