using System;
using System.Globalization;
using System.Windows.Data;

namespace PictureViewer_WPF
{
    internal class ZoomValueToPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToInt32(value) * 100 / 500 - 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
             return System.Convert.ToDouble(((int)value + 100) / 0.01 * 500);
        }
    }
}
