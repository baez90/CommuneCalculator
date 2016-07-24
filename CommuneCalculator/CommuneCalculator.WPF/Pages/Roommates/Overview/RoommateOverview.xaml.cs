using System;
using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Pages.Roommates.Overview
{
    /// <summary>
    ///     Interaction logic for RoommateOverview.xaml
    /// </summary>
    public partial class RoommateOverview : DisposableUserControl
    {
        public RoommateOverview()
        {
            InitializeComponent();
        }

        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}