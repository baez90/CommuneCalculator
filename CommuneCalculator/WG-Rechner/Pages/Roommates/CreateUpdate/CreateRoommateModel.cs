using System;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Models;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Roommates.Overview;
using CryptSharp;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Roommates.CreateUpdate
{
    public class CreateRoommateModel : ViewModelBase
    {
        private readonly IDataRepo<Roommate> _roommateRepo;
        private readonly INavigator _navigator;
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

        public ICommand SaveRoommateCommand => new RelayCommand<PasswordRequest>(async request =>
        {
            if (request.Password.Equals(request.PasswordRepeat))
            {
                _roommate.Entity.PasswordHash = Crypter.Blowfish.Crypt(request.Password);
                try
                {
                    if (_isInEditMode)
                    {
                        await _roommateRepo.UpdateEntityAsync(_roommate.Entity);
                        _navigator.NavigateTo<RoommateOverview>();
                    }
                    else
                    {
                        await _roommateRepo.CreateEntityAsync(_roommate.Entity);
                        _navigator.NavigateTo<RoommateOverview>();
                    }
                }
                catch (Exception e)
                {
                    ModernDialog.ShowMessage(e.Message, "Error while saving", MessageBoxButton.OK);
                }
                
            }
            else
            {
                ModernDialog.ShowMessage("Passwords do not match", "Password match error", MessageBoxButton.OK);
            }
        });
    }
}