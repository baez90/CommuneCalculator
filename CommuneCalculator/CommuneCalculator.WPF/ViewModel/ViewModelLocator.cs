/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WG_Rechner"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommuneCalculator.Pages;
using CommuneCalculator.Pages.Roommates.Absences.CreateUpdate;
using CommuneCalculator.Pages.Roommates.CreateUpdate;
using CommuneCalculator.Pages.Roommates.Overview;
using Microsoft.Practices.ServiceLocation;

namespace CommuneCalculator.ViewModel
{
    /// <summary>
    ///     This class contains static references to all the view models in the
    ///     application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///     Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(AppContext.Container));
        }

        public MainViewModel Main => AppContext.Container.Resolve<MainViewModel>();

        public HomeModel Home => AppContext.Container.Resolve<HomeModel>();

        public CreateRoommateModel CreateRoommate => AppContext.Container.Resolve<CreateRoommateModel>();

        public RoommateOverviewModel RoommateOverview => AppContext.Container.Resolve<RoommateOverviewModel>();

        public CreateUpdateAbsenceModel CreateUpdateAbsence => AppContext.Container.Resolve<CreateUpdateAbsenceModel>();

        public static void Cleanup()
        {
            AppContext.Container.Dispose();
        }
    }
}