using Autofac;
using CommuneCalculator.Pages;
using CommuneCalculator.Pages.Auswertung;
using CommuneCalculator.Pages.Purchases.Create;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.Pages.Roommates.Absences.CreateUpdate;
using CommuneCalculator.Pages.Roommates.CreateUpdate;
using CommuneCalculator.Pages.Roommates.Overview;

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
            builder.Register(context => new CreatePurchase());
            builder.Register(context => new Home());
            builder.Register(context => new CreateUpdateAbsence());
        }
    }
}