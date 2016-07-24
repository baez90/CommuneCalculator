using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using CommuneCalculator.Utils;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;

namespace CommuneCalculator
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    var loginDialog = new LogInDialog
        //    {
        //        Owner = Application.Current.MainWindow
        //    };

        //    //LogInDialog wird angezeigt
        //    loginDialog.ShowDialog();

        //    var contentFrame = this.FindChild<ModernFrame>("ContentFrame");
        //    var kassenwartViews = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "KassenwartViews.txt"))
        //        .Replace("\r", "")
        //        .Replace("\n", "")
        //        .Split(';')
        //        .Select(forbiddenView => forbiddenView.ToLower())
        //        .ToArray();

        //    contentFrame.Navigating += (s, args) =>
        //    {
        //        if (LogInDialog.LoginUser.Kassenwart == false)
        //        {
        //            if (args.NavigationType == NavigationType.New)
        //            {
        //                var targetView = args.Source.ToString().ToLower();
        //                if (kassenwartViews.Any(forbiddenView => targetView.Contains(forbiddenView)))
        //                {
        //                    args.Cancel = true;
        //                    ModernDialog.ShowMessage("Diese Funktion steht nur dem Kassenwart zur verfügung",
        //                        "Zugang verweigert", MessageBoxButton.OK, Application.Current.MainWindow);
        //                }
        //            }
        //        }
        //    };
        //}

        
    }
}