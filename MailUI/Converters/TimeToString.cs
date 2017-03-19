using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MahApps.Metro.Controls;

namespace MailUI.Converters
{
    public class TimeToString : IValueConverter
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
