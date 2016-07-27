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

        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}