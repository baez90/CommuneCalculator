using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.Utils;
using CommuneCalculator.ViewModel;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Purchases.Create
{
    public class CreatePurchaseModel : ValidateableViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataRepo<Roommate> _roommatesRepo;
        private readonly IDataRepo<Purchase> _purchasesRepo;
        private readonly IDataRepo<Shop> _shopsRepo;
        private readonly IDataRepo<Category> _categoriesRepo;

        private List<RoommateModel> _roommates;
        private List<ShopModel> _shops;
        private List<CategoryModel> _categories;

        public CreatePurchaseModel(INavigator navigator, IDataRepo<Roommate> roommatesRepo, IDataRepo<Purchase> purchasesRepo, IDataRepo<Shop> shopsRepo, IDataRepo<Category> categoriesRepo)
        {
            _navigator = navigator;
            _roommatesRepo = roommatesRepo;
            _purchasesRepo = purchasesRepo;
            _shopsRepo = shopsRepo;
            _categoriesRepo = categoriesRepo;

            SaveCommand = new RelayCommand(async () => await SavePurchase());
            CancelCommand = new RelayCommand(() => _navigator.NavigateTo<PurchasesOverview>());

            Task.Run(async () => await InitializeAsync()).ConfigureAwait(false);
        }

        #region Commands

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        #endregion

        #region bindable properties

        public List<RoommateModel> Roommates
        {
            get { return _roommates; }
            set
            {
                _roommates = value;
                RaisePropertyChanged();
            }
        }

        public List<ShopModel> Shops
        {
            get { return _shops; }
            set
            {
                _shops = value;
                RaisePropertyChanged();
            }
        }

        public List<CategoryModel> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged();
            }
        }

        public PurchaseModel Purchase { get; } = new PurchaseModel { Entity = new Purchase() };

        #endregion

        #region private methods

        private async Task InitializeAsync()
        {
            var roommates = await _roommatesRepo.All().Select(roommate => new RoommateModel { Entity = roommate }).ToListAsync();
            var shops = await _shopsRepo.All().Select(shop => new ShopModel { Entity = shop }).ToListAsync();
            var categories = await _categoriesRepo.All().Select(category => new CategoryModel {Entity = category}).ToListAsync();

            Application.Current.Dispatcher.Invoke(() =>
            {
                Roommates = roommates;
                Shops = shops;
                Categories = categories;
            });
        }

        private async Task SavePurchase()
        {
            if (Purchase.ValidPropertiesCount != Purchase.TotalPropertiesWithValidationCount)
            {
                ModernDialog.ShowMessage("There are validation errors", "Validation error", MessageBoxButton.OK);
                return;
            }
            await _purchasesRepo.CreateEntityAsync(Purchase.Entity);
            _navigator.NavigateTo<PurchasesOverview>();
            this.RaiseBroadcastPropertyChanged<PurchaseOverviewModel, List<PurchaseModel>>(model => model.Purchases);
        }

        #endregion
    }
}