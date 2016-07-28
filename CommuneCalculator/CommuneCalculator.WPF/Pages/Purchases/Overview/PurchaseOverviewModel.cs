using System.Collections.Generic;
using System.Linq;
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

        public PurchaseOverviewModel(INavigator navigator, IDataRepo<Purchase> purchasesRepo)
        {
            _navigator = navigator;
            _purchasesRepo = purchasesRepo;
            CreatePurchaseCommand = new RelayCommand(() => _navigator.NavigateTo<CreatePurchase>());
            UpdatePurchasesCommand = new RelayCommand(() => RaisePropertyChanged(() => Purchases));
        }

        #region Commands

        public ICommand CreatePurchaseCommand { get; }

        public ICommand UpdatePurchasesCommand { get; }


        #endregion

        #region bindable properties

        public List<PurchaseModel> Purchases => _purchasesRepo.All().Select(purchase => new PurchaseModel {Entity = purchase}).ToList();


        #endregion
    }
}