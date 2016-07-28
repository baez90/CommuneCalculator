using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Shops.Overview;
using CommuneCalculator.Utils;
using CommuneCalculator.ViewModel;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Shops.Create
{
    public class CreateShopModel : ValidateableViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataRepo<Shop> _shopsRepo;
        private bool _isSaving;
        private ShopModel _shop = new ShopModel {Entity = new Shop()};

        public CreateShopModel(INavigator navigator, IDataRepo<Shop> shopsRepo)
        {
            _navigator = navigator;
            _shopsRepo = shopsRepo;

            CancelCommand = new RelayCommand(() => _navigator.NavigateTo<ShopOverview>());
            SaveCommand = new RelayCommand(async () => await SaveCategory());
        }

        #region private methods

        private async Task SaveCategory()
        {
            IsSaving = true;
            try
            {
                await _shopsRepo.CreateEntityAsync(Shop.Entity);
                _navigator.NavigateTo<ShopOverview>();
                this.RaiseBroadcastPropertyChanged<ShopOverviewModel, List<ShopModel>>(model => model.Shops);
                IsSaving = false;
            }
            catch (Exception)
            {
                Application.Current.Dispatcher.Invoke(() => ModernDialog.ShowMessage("Failed to create new shop", "Persistence error", MessageBoxButton.OK));
                IsSaving = false;
            }
        }

        #endregion

        #region properties

        public ShopModel Shop
        {
            get { return _shop; }
            set
            {
                _shop = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSaving
        {
            get { return _isSaving; }
            set
            {
                _isSaving = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region command

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        #endregion
    }
}