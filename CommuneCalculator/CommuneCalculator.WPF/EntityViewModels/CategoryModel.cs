using System.ComponentModel.DataAnnotations;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class CategoryModel : EntityViewModelBase<Category>
    {
        public int CategoryId => Entity.CategoryId;

        [StringLength(30, ErrorMessage = "Name must be shorter than 30 characters"), Required(ErrorMessage = "Name is required")]
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