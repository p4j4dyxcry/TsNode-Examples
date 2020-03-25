using System;
using System.Globalization;
using System.Windows.Data;

namespace Example_Customize_ScrollViewer
{
    public class PercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
                value = d * 100d;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
                value = d / 100d;
            return value;
        }
    }
}