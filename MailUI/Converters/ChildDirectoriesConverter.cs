﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace MailUI.Converters
{
    class ChildDirectoriesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string)
                {
                    return new DirectoryInfo((string)value).GetDirectories();
                }
                if (value is DirectoryInfo)
                {
                    return ((DirectoryInfo)value).GetDirectories();
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
