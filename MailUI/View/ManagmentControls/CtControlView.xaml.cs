using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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
using MailUI.Model;
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
