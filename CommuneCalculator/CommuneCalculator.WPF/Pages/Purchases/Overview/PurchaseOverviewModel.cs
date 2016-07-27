using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Purchases.Create;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Purchases.Overview
{
    public class PurchaseOverviewModel : ViewModelBase
    {

        private readonly INavigator _navigator;
        private readonly IDataRepo<Purchase> _purchasesRepo;
        private List<PurchaseModel> _purchases;

        public PurchaseOverviewModel(INavigator navigator, IDataRepo<Purchase> purchasesRepo)
        {
            _navigator = navigator;
            _purchasesRepo = purchasesRepo;
            CreatePurchaseCommand = new RelayCommand(() => _navigator.NavigateTo<CreatePurchase>());
            UpdatePurchasesCommand = new RelayCommand(async () => await UpdatePurchases());
            Task.Run(async () => await UpdatePurchases()).ConfigureAwait(false);
        }

        #region Commands

        public ICommand CreatePurchaseCommand { get; }

        public ICommand UpdatePurchasesCommand { get; }

        #endregion

        #region bindable properties

        public List<PurchaseModel> Purchases
        {
            get { return _purchases; }
            set
            {
                _purchases = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region private methods

        private async Task UpdatePurchases()
        {
            Purchases = await _purchasesRepo.All().Select(purchase => new PurchaseModel {Entity = purchase}).ToListAsync();
        }

        #endregion
    }
}