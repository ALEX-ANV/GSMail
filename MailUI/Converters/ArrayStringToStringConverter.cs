using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace MailUI.Converters
{
    [ValueConversion(typeof(string[]), typeof(string))]
    public class ArrayStringToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = value as string[];
            return array?.Aggregate("", (current, item) => current + item + "\r\n");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            return str?.Split('\n');
        }
    }
}
