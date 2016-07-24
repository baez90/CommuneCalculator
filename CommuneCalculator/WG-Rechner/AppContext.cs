using Autofac;
using CommuneCalculator.IoC;

namespace CommuneCalculator
{
    public static class AppContext
    {
        static AppContext()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<ViewModelsIoCModule>();
            containerBuilder.RegisterModule<ViewsIocModule>();
            containerBuilder.RegisterModule<ServicesIocModule>();

            Container = containerBuilder.Build();
        }

        public static IContainer Container { get; }
    }
}