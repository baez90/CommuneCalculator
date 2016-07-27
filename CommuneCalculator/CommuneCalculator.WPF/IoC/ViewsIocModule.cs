using Autofac;
using CommuneCalculator.Pages;
using CommuneCalculator.Pages.Auswertung;
using CommuneCalculator.Pages.Purchases.Create;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.Pages.Roommates.Absences.CreateUpdate;
using CommuneCalculator.Pages.Roommates.CreateUpdate;
using CommuneCalculator.Pages.Roommates.Overview;
using CommuneCalculator.Pages.Shops.CreateShop;

namespace CommuneCalculator.IoC
{
    public class ViewsIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new AusgabenVerlauf());
            builder.Register(context => new CreateUpdateRoommate());
            builder.Register(context => new RoommateOverview());
            builder.Register(context => new PurchasesOverview());
            builder.Register(context => new Home());
            builder.Register(context => new CreateUpdateAbsence());

            builder.Register(context => new CreatePurchase())
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new CreateShopControl())
                .AsSelf()
                .InstancePerDependency();
        }
    }
}