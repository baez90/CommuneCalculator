using Autofac;
using CommuneCalculator.Pages;
using CommuneCalculator.Pages.Categories.Create;
using CommuneCalculator.Pages.Categories.Overview;
using CommuneCalculator.Pages.Purchases.Create;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.Pages.Roommates.Absences.CreateUpdate;
using CommuneCalculator.Pages.Roommates.CreateUpdate;
using CommuneCalculator.Pages.Roommates.Overview;
using CommuneCalculator.Pages.Shops.Create;
using CommuneCalculator.Pages.Shops.Overview;
using CommuneCalculator.Pages.Statistics.Expenditure;

namespace CommuneCalculator.IoC
{
    public class ViewsIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(context => new ExpenditureTrend())
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new Home())
                .AsSelf()
                .SingleInstance();

            #region roommates

            builder.Register(context => new CreateUpdateRoommate())
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new RoommateOverview())
                .AsSelf()
                .SingleInstance();

            #endregion

            #region purchases

            builder.Register(context => new CreatePurchase())
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new PurchasesOverview())
                .AsSelf()
                .SingleInstance();

            #endregion

            #region shops

            builder.Register(context => new CreateShop())
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new ShopOverview())
                .AsSelf()
                .SingleInstance();

            #endregion

            #region absence times

            builder.Register(context => new CreateUpdateAbsence())
                .AsSelf()
                .InstancePerDependency();

            #endregion

            #region categories

            builder.Register(context => new CreateCategory())
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new CategoryOverview())
                .AsSelf()
                .SingleInstance();

            #endregion
        }
    }
}