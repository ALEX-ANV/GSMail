using System.Windows;
using MailUI.ViewModel;

namespace MailUI.View.MainWindowUserControls
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings
    {
        private SettingsViewModel Model;

        public Settings()
        {
            InitializeComponent();
            DataContext = Model = new SettingsViewModel();
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
           
        }


        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.OnRequestClose();
        }
    }
}
