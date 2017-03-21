using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Data;
using System.Windows.Markup;

namespace MailUI.Utils.Languages
{
    public class Localization
    {
        public enum Cultures { En, Ru }

        private static readonly Dictionary<Cultures, string> ResourceFiles = new Dictionary<Cultures, string>
        {
            { Cultures.En, "MailUI.Utils.Languages.StringsEn" },
            { Cultures.Ru, "MailUI.Utils.Languages.StringsRu" }
        };

        private static ResourceManager _resourceManager = new ResourceManager(ResourceFiles[Culture], Assembly.GetExecutingAssembly());

        private static Cultures _uiCulture;

        public static Cultures Culture 
        {
            get { return _uiCulture; }
            set
            {
                _uiCulture = value;
                InitializeResourceManager(value);
            }
        }

        static Localization()
        {
            Culture = Cultures.Ru;
        }

        public static void InitializeResourceManager(Cultures culture)
        {
            _resourceManager = new ResourceManager(ResourceFiles[Culture], Assembly.GetExecutingAssembly());
        }

        public static string Get(string name)
        {
            return _resourceManager.GetString(name);
        }
    }

    [ValueConversion(typeof(string), typeof(string))]
    public class LocalizationConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Localization.Get((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

