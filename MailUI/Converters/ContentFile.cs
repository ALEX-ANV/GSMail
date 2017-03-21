using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MailUI.Model;

namespace MailUI.Converters
{
    [ValueConversion(typeof(FileInfo), typeof(string))]
    public class ContentFile : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FileInfo)
            {
                return File.ReadAllText(((FileInfo)value).FullName, Encoding.Default);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
