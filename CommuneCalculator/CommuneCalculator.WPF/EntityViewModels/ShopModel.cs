using System.ComponentModel.DataAnnotations;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class ShopModel : EntityViewModelBase<Shop>
    {
        public int ShopId => Entity.ShopId;

        [Required(ErrorMessage = "The name is required"), StringLength(30, ErrorMessage = "Maximum length is 30")]
        public string ShopName
        {
            get { return Entity.ShopName; }
            set
            {
                Entity.ShopName = value;
                RaisePropertyChanged();
            }
        }
    }
}