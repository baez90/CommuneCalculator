using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class RoommateModel : EntityViewModelBase<Roommate>
    {
        private ObservableCollection<AbsenceTimeModel> _absenceTimesProxy;

        public RoommateModel()
        {
            Entity = new Roommate();
        }

        public int RoommateId => Entity.RoommateId;

        public string LastName
        {
            get { return Entity.LastName; }
            set
            {
                Entity.LastName = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName
        {
            get { return Entity.FirstName; }
            set
            {
                Entity.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string Login
        {
            get { return Entity.Login; }
            set
            {
                Entity.Login = value;
                RaisePropertyChanged();
            }
        }

        public bool IsTreasurer
        {
            get { return Entity.IsTreasurer; }
            set
            {
                Entity.IsTreasurer = value;
                RaisePropertyChanged();
            }
        }

        public DateTime MoveInDate
        {
            get { return Entity.MoveInDate; }
            set
            {
                Entity.MoveInDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? MoveOutDate
        {
            get { return Entity.MoveOutDate; }
            set
            {
                Entity.MoveOutDate = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<AbsenceTimeModel> AbsenceTimes
        {
            get
            {
                return _absenceTimesProxy ?? (_absenceTimesProxy = new ObservableCollection<AbsenceTimeModel>(Entity.AbsenceTimes.Select(time => new AbsenceTimeModel
                {
                    Entity = time
                })));
            }
            set
            {
                _absenceTimesProxy = value;
                RaisePropertyChanged();
            }
        }

        public void UpdateAbsenceTimesCollection()
        {
            Entity.AbsenceTimes = _absenceTimesProxy.Select(model => model.Entity).ToList();
        }
    }
}