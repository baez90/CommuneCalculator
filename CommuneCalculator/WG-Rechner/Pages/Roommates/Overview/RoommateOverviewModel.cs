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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Roommates.Overview
{
    public class RoommateOverviewModel : ViewModelBase
    {

        private readonly IDataRepo<Roommate> _roommateRepo;
        private readonly INavigator _navigator;
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

        #region Commands

        public ICommand UpdateCommand => new RelayCommand(async () => await UpdateRoommates());

        public ICommand SwitchToCreateRoommateView => new RelayCommand(() => _navigator.NavigateTo<CreateUpdate.CreateUpdateRoommate>());

        public ICommand EditRoommateCommand => new RelayCommand<RoommateModel>(model => _navigator.NavigateTo<CreateUpdate.CreateUpdateRoommate, RoommateModel>(model));

        #endregion

        #region private methods

        private async Task UpdateRoommates()
        {
            var roommates = await _roommateRepo.All().Select(roommate => new RoommateModel
            {
                Entity = roommate
            }).ToListAsync();

            Application.Current.Dispatcher.Invoke(() =>
            {
                Roommates = new ObservableCollection<RoommateModel>(roommates);
            });
        }

        #endregion
    }
}