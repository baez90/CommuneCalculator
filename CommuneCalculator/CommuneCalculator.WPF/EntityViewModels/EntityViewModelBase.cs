using CommuneCalculator.ViewModel;
using GalaSoft.MvvmLight;

namespace CommuneCalculator.EntityViewModels
{
    public class EntityViewModelBase<TEntity> : ValidateableViewModelBase
    {
        public TEntity Entity { get; set; }
    }
}