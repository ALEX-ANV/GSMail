using System.Windows.Controls;
using MailUI.ViewModel;

namespace MailUI.View.MainWindowUserControls
{
    /// <summary>
    /// Interaction logic for ManagmentControl.xaml
    /// </summary>
    public partial class ManagmentControl : UserControl
    {
        public ManagmentControl()
        {
            InitializeComponent();
            var managment = new ManagmentViewModel();
            DataContext = managment;
        }
    }
}
