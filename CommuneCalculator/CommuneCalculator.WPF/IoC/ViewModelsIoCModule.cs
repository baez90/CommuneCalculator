using Autofac;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages;
using CommuneCalculator.Pages.Purchases.Create;
using CommuneCalculator.Pages.Purchases.Overview;
using CommuneCalculator.Pages.Roommates.Absences.CreateUpdate;
using CommuneCalculator.Pages.Roommates.CreateUpdate;
using CommuneCalculator.Pages.Roommates.Overview;
using CommuneCalculator.Pages.Settings.DbChooser;
using CommuneCalculator.Pages.Shops.CreateShop;
using CommuneCalculator.Pages.Shops.ShopOverview;
using CommuneCalculator.ViewModel;

namespace CommuneCalculator.IoC
{
    internal class ViewModelsIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MainViewModel())
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new HomeModel(context.Resolve<INavigator>()))
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new CreatePurchaseModel(
                context.Resolve<INavigator>(),
                context.Resolve<IDataRepo<Roommate>>(),
                context.Resolve<IDataRepo<Purchase>>(),
                context.Resolve<IDataRepo<Shop>>()))
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new PurchaseOverviewModel(context.Resolve<INavigator>(), context.Resolve<IDataRepo<Purchase>>()))
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new CreateRoommateModel(context.Resolve<IDataRepo<Roommate>>(), context.Resolve<INavigator>()))
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new RoommateOverviewModel(context.Resolve<IDataRepo<Roommate>>(), context.Resolve<INavigator>()))
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new CreateShopModel(context.Resolve<INavigator>(), context.Resolve<IDataRepo<Shop>>()))
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new ShopOverviewModel(context.Resolve<INavigator>(), context.Resolve<IDataRepo<Shop>>()))
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new CreateUpdateAbsenceModel(context.Resolve<IDataRepo<AbsenceTime>>()))
                .AsSelf()
                .InstancePerDependency();

            builder.Register(context => new DbChooserModel())
                .AsSelf()
                .SingleInstance();
        }
    }
}