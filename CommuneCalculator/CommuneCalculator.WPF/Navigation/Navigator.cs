using System.Windows;
using Autofac;
using CommuneCalculator.Pages.Base;
using CommuneCalculator.Utils;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace CommuneCalculator.Navigation
{
    public class Navigator : INavigator
    {
        private readonly ModernFrame _frame;
        private readonly IMessenger _messenger;

        public Navigator()
        {
            _frame = Application.Current.MainWindow.FindChild<ModernFrame>("ContentFrame");
            _messenger = Messenger.Default;
        }

        public void NavigateTo<TView>(OpeningMode openingMode = OpeningMode.ContentFrame) where TView : DisposableUserControl => NavigateToView<TView>(openingMode);

        public void NavigateTo<TView, TParam>(TParam param, OpeningMode openingMode = OpeningMode.ContentFrame) where TView : DisposableUserControl
        {
            NavigateToView<TView>(openingMode);
            _messenger.Send(param);
        }

        private void NavigateToView<TView>(OpeningMode openingMode) where TView : DisposableUserControl
        {
            var view = AppContext.Container.Resolve<TView>();
            switch (openingMode)
            {
                case OpeningMode.Window:
                    var newWindow = new ModernDialog {Content = view};
                    newWindow.ShowDialog();
                    break;
                default:
                    _frame.Content = view;
                    break;
            }
        }
    }
}