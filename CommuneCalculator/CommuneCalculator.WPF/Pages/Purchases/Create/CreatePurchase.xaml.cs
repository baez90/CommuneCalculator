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

        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}