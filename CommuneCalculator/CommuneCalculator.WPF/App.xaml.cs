using System.Data.Entity;
using System.Windows;
using CommuneCalculator.DB.DbUtils;
using CommuneCalculator.ViewModel;

namespace CommuneCalculator
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer(new DbInitializer());
            Exit += (sender, args) => { ViewModelLocator.Cleanup(); };
        }
    }
}