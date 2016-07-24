using System.Windows;

namespace CommuneCalculator.Utils
{
    internal class DataContextProxy : Freezable
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(DataContextProxy));


        //Change this type to match your ViewModel Type/Interface
        //Then IntelliSense will help with binding validation
        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }
    }
}