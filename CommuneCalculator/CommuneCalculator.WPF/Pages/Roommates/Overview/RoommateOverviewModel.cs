using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Roommates.CreateUpdate;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Roommates.Overview
{
    public class RoommateOverviewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        private readonly IDataRepo<Roommate> _roommateRepo;
        private ObservableCollection<RoommateModel> _roommates;

        public RoommateOverviewModel(IDataRepo<Roommate> roommateRepo, INavigator navigator)
        {
            _roommateRepo = roommateRepo;
            _navigator = navigator;
        }

        #region properties

        public ObservableCollection<RoommateModel> Roommates
        {
            get { return _roommates; }
            set
            {
                _roommates = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region private methods

        private async Task UpdateRoommates()
        {
            var roommates = await _roommateRepo.All().Select(roommate => new RoommateModel
            {
                Entity = roommate
            }).ToListAsync();

            Application.Current.Dispatcher.Invoke(() => { Roommates = new ObservableCollection<RoommateModel>(roommates); });
        }

        #endregion

        #region Commands

        public ICommand UpdateCommand => new RelayCommand(async () => await UpdateRoommates());

        public ICommand SwitchToCreateRoommateView => new RelayCommand(() => _navigator.NavigateTo<CreateUpdateRoommate>());

        public ICommand EditRoommateCommand => new RelayCommand<RoommateModel>(model => _navigator.NavigateTo<CreateUpdateRoommate, RoommateModel>(model));

        #endregion
    }
}