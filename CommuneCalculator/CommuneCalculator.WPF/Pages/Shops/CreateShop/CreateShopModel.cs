using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Shops.CreateShop
{
    public class CreateShopModel : ValidateableViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataRepo<Shop> _shopsRepo;

        public CreateShopModel(INavigator navigator, IDataRepo<Shop> shopsRepo)
        {
            _navigator = navigator;
            _shopsRepo = shopsRepo;

            CancelCommand = new RelayCommand(() => _navigator.NavigateTo<ShopOverview.ShopOverview>());
        }

        #region properties

        public ShopModel Shop { get; set; }

        #endregion

        #region command

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        #endregion
    }
}