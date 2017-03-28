using System.Windows;
using System.Windows.Controls;
using MailUI.ViewModel.ManagmentViewModels;

namespace MailUI.View.ManagmentControls
{
    /// <summary>
    /// Interaction logic for CtControl.xaml
    /// </summary>
    public partial class CtControlView : UserControl
    {
        public CtViewModel Model { get; set; }

        public CtControlView(CtViewModel model)
        {
            InitializeComponent();
            Model = model;
            DataContext = Model;
        }

        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
