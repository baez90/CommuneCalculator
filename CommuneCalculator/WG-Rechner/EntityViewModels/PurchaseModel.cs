using System;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class PurchaseModel : EntityViewModelBase<Purchase>
    {
        private CategoryModel _categoryProxy;
        private ShopModel _shopProxy;

        public int ReceiptId => Entity.ReceiptId;

        public decimal Amount
        {
            get { return Entity.Amount; }
            set
            {
                Entity.Amount = value;
                RaisePropertyChanged();
            }
        }

        public DateTime PurchaseDate
        {
            get { return Entity.PurchaseDate; }
            set
            {
                Entity.PurchaseDate = value;
                RaisePropertyChanged();
            }
        }

        public CategoryModel Category
        {
            get
            {
                return _categoryProxy ?? (_categoryProxy = new CategoryModel
                {
                    Entity = Entity.Category
                });
            }
            set
            {
                _categoryProxy = value;
                Entity.Category = _categoryProxy.Entity;
                RaisePropertyChanged();
            }
        }

        public ShopModel Shop
        {
            get
            {
                return _shopProxy ?? (_shopProxy = new ShopModel
                {
                    Entity = Entity.Shop
                });
            }
            set
            {
                _shopProxy = value;
                Entity.Shop = value.Entity;
                RaisePropertyChanged();
            }
        }
    }
}