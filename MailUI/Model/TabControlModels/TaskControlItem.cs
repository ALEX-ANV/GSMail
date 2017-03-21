using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MailUI.Utils.Languages;
using MailUI.View;
using MailUI.View.MainWindowUserControls;
using MailUI.ViewModel;

namespace MailUI.Model.TabControlModels
{
    [Export(typeof(ITabControl))]
    public class TaskControlItem : ITabControl
    {
        public string Header { get { return Localization.Get("TabItem_Tasks"); } }
        public UserControl Control { get { return new TaskControl(); } }
        public int Order { get { return 3; } }
    }
}
