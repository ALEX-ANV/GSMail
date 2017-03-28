using System;
using System.Globalization;
using System.Windows.Data;

namespace MailUI.Converters
{
    [ValueConversion(typeof(TimeSpan), typeof(string))]
    public class TimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strLine = (string)value;
            TimeSpan date;
            TimeSpan.TryParse(strLine, out date);
            return date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            TimeSpan date;
            if (value is TimeSpan)
            {
                date = (TimeSpan)value;
                if (parameter != null)
                {
                    return date.ToString((string)parameter);
                }
            }
            return "";
        }
    }
}
