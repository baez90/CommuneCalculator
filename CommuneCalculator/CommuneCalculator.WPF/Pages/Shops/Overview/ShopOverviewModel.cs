using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Shops.Create;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Shops.Overview
{
    public class ShopOverviewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataRepo<Shop> _shopsRepo;

        public ShopOverviewModel(INavigator navigator, IDataRepo<Shop> shopsRepo)
        {
            _navigator = navigator;
            _shopsRepo = shopsRepo;

            AddShopCommand = new RelayCommand(() => _navigator.NavigateTo<CreateShop>());
        }

        #region properties

        public List<ShopModel> Shops => _shopsRepo.All().Select(shop => new ShopModel {Entity = shop}).ToList();

        #endregion

        #region commands

        public ICommand AddShopCommand { get; }

        #endregion
    }
}