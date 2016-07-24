using GalaSoft.MvvmLight;

namespace CommuneCalculator.EntityViewModels
{
    public class EntityViewModelBase<TEntity> : ViewModelBase
    {
        public TEntity Entity { get; set; }
    }
}