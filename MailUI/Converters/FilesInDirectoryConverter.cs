using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace MailUI.Converters
{
    [ValueConversion(typeof(DirectoryInfo), typeof(FileInfo[]))]
    public class FilesInDirectoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            if (value is DirectoryInfo)
            {
                return ((DirectoryInfo) value).GetFiles();

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
