using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        private List<ShopModel> _shops;

        public ShopOverviewModel(INavigator navigator, IDataRepo<Shop> shopsRepo)
        {
            _navigator = navigator;
            _shopsRepo = shopsRepo;

            UpdateCommand = new RelayCommand(async () => await UpdateShops());
            AddShopCommand = new RelayCommand(() => _navigator.NavigateTo<CreateShop>());

            Task.Run(async () => await UpdateShops());
        }

        #region properties

        public List<ShopModel> Shops
        {
            get { return _shops; }
            set
            {
                _shops = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region commands

        public ICommand UpdateCommand { get; }

        public ICommand AddShopCommand { get; }

        #endregion

        #region private methods

        private async Task UpdateShops()
        {
            Shops = await _shopsRepo.All().Select(shop => new ShopModel {Entity = shop}).ToListAsync();
        }

        #endregion
    }
}