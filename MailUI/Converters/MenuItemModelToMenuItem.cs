using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using MailUI.Model.MainMenu;

namespace MailUI.Converters
{
    [ValueConversion(typeof(MenuItemModel), typeof(MenuItem))]
    public class MenuItemModelToMenuItem : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
}
