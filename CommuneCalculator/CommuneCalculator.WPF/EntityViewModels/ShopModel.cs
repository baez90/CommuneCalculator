using System.Collections.ObjectModel;
using System.Linq;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class ShopModel : EntityViewModelBase<Shop>
    {
        private ObservableCollection<CategoryModel> _categoriesProxy;
        public int ShopId => Entity.ShopId;

        public string ShopName
        {
            get { return Entity.ShopName; }
            set
            {
                Entity.ShopName = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CategoryModel> Categories
        {
            get
            {
                return _categoriesProxy ?? (_categoriesProxy = new ObservableCollection<CategoryModel>(Entity.Categories.Select(category => new CategoryModel
                {
                    Entity = category
                })));
            }
            set
            {
                _categoriesProxy = value;
                RaisePropertyChanged();
            }
        }

        public void UpdateCategoriesCollection()
        {
            Entity.Categories = _categoriesProxy.Select(model => model.Entity).ToList();
        }
    }
}