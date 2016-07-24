using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using CommuneCalculator.Models;

namespace CommuneCalculator.Converters
{
    public class PasswordRequestConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                return new PasswordRequest
                {
                    PasswordBox = values[0] as PasswordBox,
                    PasswordRepeatBox = values[1] as PasswordBox
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}