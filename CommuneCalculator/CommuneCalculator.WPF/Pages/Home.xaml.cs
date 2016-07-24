using System;
using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Pages
{
    /// <summary>
    ///     Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : DisposableUserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}