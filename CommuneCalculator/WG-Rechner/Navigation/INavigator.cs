using CommuneCalculator.Pages.Base;

namespace CommuneCalculator.Navigation
{
    public interface INavigator
    {
        void NavigateTo<TView>(OpeningMode openingMode = OpeningMode.ContentFrame) where TView : DisposableUserControl;

        void NavigateTo<TView, TParam>(TParam param, OpeningMode openingMode = OpeningMode.ContentFrame) where TView : DisposableUserControl;
    }

    public enum OpeningMode
    {
        ContentFrame,
        Window
    }
}