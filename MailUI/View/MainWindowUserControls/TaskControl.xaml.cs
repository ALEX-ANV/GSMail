using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using MahApps.Metro.Controls;
using MailUI.ViewModel;

namespace MailUI.View.MainWindowUserControls
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public TaskControl()
        {
            InitializeComponent();
            var treeTasks = new TaskViewModel(@"c:\Tempest");
            DataContext = treeTasks;
        }

        public string Header { get; }

        public void AddTabItem(MainWindow baseView)
        {
            throw new NotImplementedException();
        }
    }
}
