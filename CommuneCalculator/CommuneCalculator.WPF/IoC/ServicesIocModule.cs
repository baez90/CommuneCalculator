using System.Data.Entity;
using Autofac;
using CommuneCalculator.DB;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.Navigation;

namespace CommuneCalculator.IoC
{
    internal class ServicesIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new ComCalcContext())
                .As<DbContext>()
                .AsSelf()
                .SingleInstance();

            builder.Register(context => new BaseDataRepo<Roommate>(context.Resolve<DbContext>()))
                .As<IDataRepo<Roommate>>()
                .SingleInstance();

            builder.Register(context => new Navigator())
                .As<INavigator>()
                .SingleInstance();
        }
    }
}