using System;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.EntityViewModels
{
    public class PurchaseModel : EntityViewModelBase<Purchase>
    {
        private CategoryModel _categoryProxy;
        private ShopModel _shopProxy;
        private RoommateModel _roommateProxy;

        public int PurchaseId => Entity.PurchaseId;

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
                if(value == null) return;
                _categoryProxy = value;
                Entity.Category = _categoryProxy.Entity;
                RaisePropertyChanged();
            }
        }

        public ShopModel Shop
        {
            get { return _shopProxy ?? (_shopProxy = new ShopModel { Entity = Entity.Shop }); }
            set
            {
                if(value == null) return;
                _shopProxy = value;
                Entity.Shop = value.Entity;
                RaisePropertyChanged();
            }
        }

        public RoommateModel PurchasedBy
        {
            get { return _roommateProxy ?? (_roommateProxy = new RoommateModel {Entity = Entity.PurchasedBy}); }
            set
            {
                if(value == null) return;
                _roommateProxy = value;
                Entity.PurchasedBy = value.Entity;
                RaisePropertyChanged();
            }
        }
    }
}