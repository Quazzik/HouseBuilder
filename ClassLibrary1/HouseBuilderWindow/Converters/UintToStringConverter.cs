using System;
using System.Globalization;
using System.Windows.Data;

namespace HouseBuilderWindow.Converters
{
    public class UintToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not uint uintValue)
                return "";

            return uintValue switch
            {
                > 10 => "10",
                uint number => $"{number}"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string strValue)
                return 0u;

            if (!uint.TryParse(strValue, out var uintVal))
                return 0u;

            return uintVal > 10 ? 10 : uintVal;
        }
    }
}
