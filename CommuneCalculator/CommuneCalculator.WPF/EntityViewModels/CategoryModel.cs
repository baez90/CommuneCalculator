using System.Collections.ObjectModel;
using System.Linq;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class CategoryModel : EntityViewModelBase<Category>
    {
        private ObservableCollection<ShopModel> _shopsProxy;

        public int CategoryId => Entity.CategoryId;

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ShopModel> Shops
        {
            get
            {
                return _shopsProxy ?? (_shopsProxy = new ObservableCollection<ShopModel>(Entity.Shops.Select(shop => new ShopModel
                {
                    Entity = shop
                })));
            }
            set
            {
                _shopsProxy = value;
                RaisePropertyChanged();
            }
        }

        public void UpdateShopsCollection()
        {
            Entity.Shops = _shopsProxy.Select(model => model.Entity).ToList();
        }
    }
}