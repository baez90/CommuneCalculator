using System.Windows.Input;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Auswertung;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.Pages.Roommates.Overview;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages
{
    public class HomeModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public HomeModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand NavigateToPurchasesCommand => new RelayCommand(() => _navigator.NavigateTo<PurchasesOverview>());

        public ICommand NavigateToRoommatesCommand => new RelayCommand(() => _navigator.NavigateTo<RoommateOverview>(OpeningMode.Window));

        public ICommand NavigateToStatsCommand => new RelayCommand(() => _navigator.NavigateTo<AusgabenVerlauf>());
    }
}