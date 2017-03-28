using System;
using System.Windows.Controls;
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
