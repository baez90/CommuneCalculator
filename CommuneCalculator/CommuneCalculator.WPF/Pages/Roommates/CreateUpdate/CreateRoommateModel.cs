using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Roommates.Overview;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Roommates.CreateUpdate
{
    public class CreateRoommateModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataRepo<Roommate> _roommateRepo;
        private bool _isInEditMode;
        private RoommateModel _roommate;
        private bool _isSaving;

        public CreateRoommateModel(IDataRepo<Roommate> roommateRepo, INavigator navigator)
        {
            _roommateRepo = roommateRepo;
            _navigator = navigator;
            _roommate = new RoommateModel();

            MessengerInstance.Register(this, new Action<RoommateModel>(model =>
            {
                Roommate = model;
                _isInEditMode = true;
            }));

            SaveRoommateCommand = new RelayCommand(async () => await SaveRoommate());
            CancelCommand = new RelayCommand(() => _navigator.NavigateTo<RoommateOverview>());
        }

        #region properties

        public RoommateModel Roommate
        {
            get { return _roommate; }
            set
            {
                _roommate = value;
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

        #region commands

        public ICommand SaveRoommateCommand { get; }

        public ICommand CancelCommand { get; }

        #endregion

        #region private methods

        private async Task SaveRoommate()
        {
            IsSaving = true;
            try
            {
                if (_isInEditMode)
                {
                    await _roommateRepo.UpdateEntityAsync(_roommate.Entity);
                }
                else
                {
                    await _roommateRepo.CreateEntityAsync(Roommate.Entity);
                }
                _navigator.NavigateTo<RoommateOverview>();
            }
            catch (Exception)
            {
                Application.Current.Dispatcher.Invoke(() => ModernDialog.ShowMessage("Failed to create or update roommate", "Persistence error", MessageBoxButton.OK));
            }
            finally
            {
                IsSaving = false;
            }
        }

        #endregion
    }
}