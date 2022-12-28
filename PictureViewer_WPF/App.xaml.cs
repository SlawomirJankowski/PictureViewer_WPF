using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PictureViewer_WPF.ViewModels;
using PictureViewer_WPF.Views;
using SplashScreen = PictureViewer_WPF.Views.SplashScreen;

namespace PictureViewer_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var splashScreen = new SplashScreen();
            splashScreen.Show();

            Thread.Sleep(4000);

            var mainWindow = new MainWindow();
            mainWindow.Show();
            splashScreen.Close();
            
        }
    }
}
