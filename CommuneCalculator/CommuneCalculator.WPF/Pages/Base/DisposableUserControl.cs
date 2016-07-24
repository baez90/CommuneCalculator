using System;
using System.Windows.Controls;

namespace CommuneCalculator.Pages.Base
{
    public abstract class DisposableUserControl : UserControl, IDisposable
    {
        public void Dispose()
        {
            (DataContext as IDisposable)?.Dispose();
            OnDisposing();
        }

        protected abstract void OnDisposing();
    }
}