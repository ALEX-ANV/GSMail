using System.Windows;
using MailUI.ViewModel;

namespace MailUI.View.MainWindowUserControls
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings 
    {
        public Settings()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
