using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class CategoryModel : EntityViewModelBase<Category>
    {
        public int CategoryId => Entity.CategoryId;

        public string Name
        {
            get { return Entity == null ? "" : Entity.Name; }
            set
            {
                Entity.Name = value;
                RaisePropertyChanged();
            }
        }
    }
}