using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.ViewModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Purchases.Create
{
    public class CreatePurchaseModel : ValidateableViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataRepo<Roommate> _roommatesRepo;
        private List<RoommateModel> _roommates;

        public CreatePurchaseModel(INavigator navigator, IDataRepo<Roommate> roommatesRepo)
        {
            _navigator = navigator;
            _roommatesRepo = roommatesRepo;

            SaveCommand = new RelayCommand(async () => await SavePurchase());
            CancelCommand = new RelayCommand(() => _navigator.NavigateTo<PurchasesOverview>());

            Initialize();
        }

        #region Commands

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        #endregion

        #region private methods

        private void Initialize()
        {
            var initTask = Task.Run(() => { return _roommatesRepo.All().Select(roommate => new RoommateModel {Entity = roommate}).ToList(); });
            initTask.ConfigureAwait(false);
            initTask.ContinueWith(task => { Roommates = task.Result; }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task SavePurchase()
        {
            
        }

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

        public PurchaseModel Purchase { get; } = new PurchaseModel { Entity = new Purchase() };

        public RoommateModel SelectedRoommate { get; set; }

        public decimal Amount { get; set; }

        #endregion
    }
}