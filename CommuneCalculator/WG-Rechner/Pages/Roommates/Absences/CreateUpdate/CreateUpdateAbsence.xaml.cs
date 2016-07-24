using System;
using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Pages.Roommates.Absences.CreateUpdate
{
    /// <summary>
    ///     Interaction logic for CreateUpdateAbsence.xaml
    /// </summary>
    public partial class CreateUpdateAbsence : DisposableUserControl
    {
        public CreateUpdateAbsence()
        {
            InitializeComponent();
        }

        protected override void OnDisposing()
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}