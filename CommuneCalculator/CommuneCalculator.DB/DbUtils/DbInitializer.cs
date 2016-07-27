using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.DB.DbUtils
{
    public class DbInitializer : CreateDatabaseIfNotExists<ComCalcContext>
    {
        protected override void Seed(ComCalcContext context)
        {
            context.Roommates.Add(new Roommate
            {
                MoveInDate = DateTime.Today,
                FirstName = "admin",
                LastName = "admin"
            });

            context.SaveChanges();

#if DEBUG
            try
            {
                context.Shops.AddOrUpdate(shop => shop.ShopId, new Shop {ShopId = 1, ShopName = "REAL"});

                context.SaveChanges();

                context.Categories.AddOrUpdate(category => category.CategoryId, new Category {CategoryId = 1, Name = "Futter"});

                context.SaveChanges();

                context.Purchases.AddOrUpdate(purchase => purchase.PurchaseId, new Purchase
                {
                    PurchaseId = 1,
                    Category = context.Categories.First(),
                    Shop = context.Shops.First(),
                    Amount = 23,
                    PurchasedBy = context.Roommates.First()
                });

                context.SaveChanges();
            }
            catch (DbEntityValidationException deve)
            {
                Console.Out.WriteLine(deve.Message);
            }
            catch (Exception)
            {
                
            }
            
#endif


        }
    }
}