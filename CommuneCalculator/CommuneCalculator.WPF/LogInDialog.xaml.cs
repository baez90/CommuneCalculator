using System.Windows.Controls;
using FirstFloor.ModernUI.Windows.Controls;

namespace CommuneCalculator
{
    /// <summary>
    ///     Logik für LogInDialog.xaml
    /// </summary>
    public partial class LogInDialog : ModernDialog
    {
        public LogInDialog()
        {
            InitializeComponent();
            Buttons = new Button[] {};
        }


//        private void HoleLogin()
//        {
//            //Multi-threading mit Task Parallel Library von .NET
//            Task.Run(() =>
//            {
//                using (var context = new WGRechnerContext())
//                {
//                    var b = new Bewohner();
//                    return b.AlleBewohnerHolen(context).ToList();
//                }
//            }).ContinueWith(task =>
//            {
//                cbxBewohner.ItemsSource = task.Result;
//                cbxBewohner.SelectedIndex = 0;
//                btnLogIn.IsEnabled = true;
//                cbxBewohner.IsEnabled = true;
//            }, TaskScheduler.FromCurrentSynchronizationContext());
//        }


//        private void btnLoginClick(object sender, RoutedEventArgs e)
//        {
//            LoginUser = cbxBewohner.SelectedItem as BewohnerEntity;
//            var password = tbxPasswort.Password;

//            if (LoginUser != null)
//            {
//#if DEBUG
//                Close();
//                return;
//#endif
//                if (Crypter.CheckPassword(password, LoginUser.Passwort))
//                {
//                    Close();
//                }
//                ShowMessage("Passwort oder Bewohner ist falsch", "Login Error", MessageBoxButton.OK);
//            }
//        }

//        //Wenn Abbrechen-Button gedrückt wird, wird die gesamte Anwendung heruntergefahren
//        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
//        {
//            Application.Current.Shutdown();
//        }

//        private void testclick(object sender, RoutedEventArgs e)
//        {
//            new Navigator().NavigateTo<AusgabenVerlauf>();
//        }
    }
}