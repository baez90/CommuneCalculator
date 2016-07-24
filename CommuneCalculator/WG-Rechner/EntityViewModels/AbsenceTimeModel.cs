using System;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class AbsenceTimeModel : EntityViewModelBase<AbsenceTime>
    {
        private RoommateModel _roommateProxy;

        public int AbsenceId => Entity.AbsenceId;

        public string Reason
        {
            get { return Entity.Reason; }
            set
            {
                Entity.Reason = value;
                RaisePropertyChanged();
            }
        }

        public DateTime AbsenceStart
        {
            get { return Entity.AbsenceStart; }
            set
            {
                Entity.AbsenceStart = value;
                RaisePropertyChanged();
            }
        }

        public DateTime AbsenceEnd
        {
            get { return Entity.AbsenceEnd; }
            set
            {
                Entity.AbsenceEnd = value;
                RaisePropertyChanged();
            }
        }

        public virtual RoommateModel Roommate
        {
            get
            {
                return _roommateProxy ?? (_roommateProxy = new RoommateModel
                {
                    Entity = Entity.Roommate
                });
            }
            set
            {
                _roommateProxy = value;
                Entity.Roommate = _roommateProxy.Entity;
                RaisePropertyChanged();
            }
        }
    }
}