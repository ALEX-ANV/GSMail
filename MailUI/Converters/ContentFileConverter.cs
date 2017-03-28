using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace MailUI.Converters
{
    [ValueConversion(typeof(FileInfo), typeof(string))]
    public class ContentFileConverter : IValueConverter
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
