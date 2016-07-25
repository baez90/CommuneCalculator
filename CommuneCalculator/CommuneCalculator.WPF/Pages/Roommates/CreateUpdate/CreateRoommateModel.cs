using System;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
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
        }

        public RoommateModel Roommate
        {
            get { return _roommate; }
            set
            {
                _roommate = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveRoommateCommand => new RelayCommand(async () => { await _roommateRepo.UpdateEntityAsync(_roommate.Entity); });
    }
}