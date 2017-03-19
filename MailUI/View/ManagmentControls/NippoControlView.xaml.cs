using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
