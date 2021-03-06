﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace MailUI.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class ToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return ((string) value).ToUpper();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
