using System;
using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Pages.Purchases.Overview
{
    /// <summary>
    ///     Interaction logic for Beleg_verwalten.xaml
    /// </summary>
    /// o
    public partial class PurchasesOverview : DisposableUserControl
    {
        public PurchasesOverview()
        {
            InitializeComponent();
        }

        ///// <summary>
        /////     HoleBelege-Methode: Holt alle eingegebenen Belege aus der Datenbank und wandelt diese in eine Liste um.
        ///// </summary>
        //private void HoleBelege()
        //{
        //    Task.Run(() =>
        //    {
        //        using (var context = new WGRechnerContext())
        //        {
        //            return belegUebersicht.AlleBelegeHolen(context).ToList();
        //        }
        //    }).ContinueWith(task => { gridBelege.ItemsSource = task.Result; }, TaskScheduler.FromCurrentSynchronizationContext());
        //}

        ///// <summary>
        /////     BtnAbbrechen()-Methode: Durch das Betätigen des Buttons wechselt die Oberfläche wieder in die Home-Ansicht.
        /////     Ebenso werden die bereits eigegenben/ausgewählten Daten durch die ResetForm()-Methode auf 0 gesetzt.
        ///// </summary>
        //private void BtnAbbrechen_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var mainWindow = Application.Current.MainWindow as ModernWindow;

        //    if (mainWindow != null)
        //    {
        //        mainWindow.ContentSource = new Uri("Pages/Home.xaml", UriKind.Relative);
        //    }
        //}

        ///// <summary>
        /////     BtnNeuenBeleg-Methode: Durch diese Methode wird das Fenster CreatePurchase geöffnet.
        ///// </summary>
        //private void BtnNeuenBeleg_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var mainWindow = Application.Current.MainWindow as ModernWindow;

        //    if (mainWindow != null)
        //    {
        //        mainWindow.ContentSource = new Uri("/Pages/Belege/CreatePurchase.xaml", UriKind.Relative);
        //    }
        //}

        ///// <summary>
        /////     BtnAktual-Methode: neu eingegebene Belege werden in das GridBelege.ItemSource geladen
        ///// </summary>
        //private void BtnAktual_OnClick(object sender, RoutedEventArgs e)
        //{
        //    HoleBelege();
        //}
        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}