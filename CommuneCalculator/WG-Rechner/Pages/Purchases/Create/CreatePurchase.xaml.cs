using System;
using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Pages.Purchases.Create
{
    /// <summary>
    ///     Interaction logic for CreatePurchase.xaml
    /// </summary>
    public partial class CreatePurchase : DisposableUserControl
    {
        public CreatePurchase()
        {
            InitializeComponent();
        }

        ///// <summary>
        /////     BtnAbbrechen()-Methode: Durch das Betätigen des Buttons wechselt die Oberfläche wieder in die Home-Ansicht.
        /////     Ebenso werden die bereits eigegenben/ausgewählten Daten durch die ResetForm()-Methode auf 0 gesetzt.
        ///// </summary>
        //private void BtnAbbrechen_OnClick(object sender, RoutedEventArgs e)

        //{
        //    var mainWindow = Application.Current.MainWindow as ModernWindow;

        //    ResetForm();
        //    if (mainWindow != null)
        //    {
        //        mainWindow.ContentSource = new Uri("Pages/Home.xaml", UriKind.Relative);
        //    }
        //}

        ///// <summary>
        /////     BtnSpeichern()-Methode: Sobald der Button betätigt wird, prüft die Methode ob alle Felder richtig ausefüllt sind.
        /////     Wenn dies nicht der Fall ist, wird die jeweile ShowMessage angezeigt.
        /////     Bei korrekter Eingabe wird der "Kassenzettel in der Datenbank gespeichert.
        ///// </summary>
        //private void BtnSpeichern_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var beleg = new BelegEntity();
        //    var b = new Beleg();
        //    if (cbxGeschaeft.SelectedIndex == -1)
        //    {
        //        ModernDialog.ShowMessage("Bitte wähle ein Geschäft aus.", "Bitte überprüfen", MessageBoxButton.OK);
        //        return;
        //    }

        //    beleg.Kategorie = (Kategorie) cbxGeschaeft.SelectedItem;
        //    decimal betragOut;

        //    if (!decimal.TryParse(tbxBetrag.Text, out betragOut))
        //    {
        //        ModernDialog.ShowMessage("Der eingegebene Wert für den Betrag ist ungültig", "Bitte überprüfen", MessageBoxButton.OK);
        //        return;
        //    }

        //    beleg.Betrag = betragOut;

        //    if (!dpKassenbelegdatum.SelectedDate.HasValue)
        //    {
        //        ModernDialog.ShowMessage("Es ist kein Datum ausgewählt", "Bitte überprüfen", MessageBoxButton.OK);
        //        return;
        //    }
        //    beleg.Datum = dpKassenbelegdatum.SelectedDate.Value;
        //    beleg.BewohnerEntity = LogInDialog.LoginUser;

        //    b.BelegEintragen(beleg);

        //    Background = Brushes.SkyBlue;
        //    ModernDialog.ShowMessage("Dein Kassenbeleg wurde erfolgreich eingetragen", "Check", MessageBoxButton.OK);
        //    ResetForm();
        //}

        ///// <summary>
        /////     Eingaben werden auf Anfangszustand zurückgesetzt
        ///// </summary>
        //private void ResetForm()
        //{
        //    tbxBetrag.Text = string.Empty;
        //    cbxGeschaeft.SelectedIndex = -1;
        //    dpKassenbelegdatum.SelectedDate = null;
        //    Background = Brushes.White;
        //}
        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}