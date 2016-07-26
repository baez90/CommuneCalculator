using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB;
using CommuneCalculator.DB.DbUtils;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CommuneCalculator.Pages.Settings.DbChooser
{
    public class DbChooserModel : ViewModelBase
    {
        private string _dbLocation = DbConnectionUtil.DataSourcePath;

        public DbChooserModel()
        {
            OpenDatabaseCommand = new RelayCommand(ProcessOpenDatabase);
        }

        public string DbLocation
        {
            get { return _dbLocation; }
            set
            {
                if (value == null || value.Equals(_dbLocation)) return;
                _dbLocation = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenDatabaseCommand { get; }

        public ICommand ContinueCommand { get; } = new RelayCommand<DbChooserDialog>(async dialog =>
        {
            await Task.Run(() =>
            {
                using (var context = new ComCalcContext())
                {
                    context.Database.Initialize(false);
                }
            });
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            dialog.Close();
        });

        private void ProcessOpenDatabase()
        {
            using (var dialog = new CommonOpenFileDialog {IsFolderPicker = true})
            {
                if (dialog.ShowDialog() != CommonFileDialogResult.Ok) return;
                var newPath = Path.Combine(dialog.FileName, DbConnectionUtil.CommuneCalculatorDbName);
                DbLocation = File.Exists(newPath) ? newPath : ModernDialog.ShowMessage("The specified file does not exist. A new database will be created.", "Database path", MessageBoxButton.OKCancel) == MessageBoxResult.OK ? newPath : DbLocation;
            }
        }
    }
}