using System;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Roommates.Absences.CreateUpdate
{
    public class CreateUpdateAbsenceModel : ViewModelBase
    {

        private bool _isInEditMode;
        private readonly IDataRepo<AbsenceTime> _absenceRepo;

        public CreateUpdateAbsenceModel(IDataRepo<AbsenceTime> absenceRepo)
        {
            _absenceRepo = absenceRepo;
            Absence = new AbsenceTimeModel();
            MessengerInstance.Register(this, new Action<AbsenceTimeModel>(model =>
            {
                Absence = model;
                if (Absence.Entity.AbsenceId != default(int))
                {
                    _isInEditMode = true;
                }
            }));
        }

        public AbsenceTimeModel Absence { get; set; }

        public ICommand SaveCommand => new RelayCommand(async () =>
        {
            if (_isInEditMode)
            {
                await _absenceRepo.UpdateEntityAsync(Absence.Entity);
            }
            else
            {
                await _absenceRepo.CreateEntityAsync(Absence.Entity);
            }
        });
    }
}