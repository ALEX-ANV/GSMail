using System.Windows.Controls;
using MailUI.ViewModel.ManagmentViewModels;

namespace MailUI.View.ManagmentControls
{
    /// <summary>
    /// Interaction logic for NippoControl.xaml
    /// </summary>
    public partial class NippoControlView : UserControl
    {
        public NippoViewModel Model { get; set; }

        public NippoControlView(NippoViewModel model)
        {
            InitializeComponent();
            Model = model;
            DataContext = Model;
        }
    }
}
