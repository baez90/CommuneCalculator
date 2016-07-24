using System;
using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Pages.Roommates.CreateUpdate
{
    /// <summary>
    ///     Logik für CreateUpdateRoommate.xaml
    /// </summary>
    public partial class CreateUpdateRoommate : DisposableUserControl
    {
        public CreateUpdateRoommate()
        {
            InitializeComponent();
        }

        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}