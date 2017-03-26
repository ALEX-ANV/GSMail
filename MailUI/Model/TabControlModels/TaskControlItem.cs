using System.ComponentModel.Composition;
using System.Windows.Controls;
using MailUI.Utils.Languages;
using MailUI.View.MainWindowUserControls;
using MailUI.View.Settings;

namespace MailUI.Model.TabControlModels
{
    [Export(typeof(ITabControl))]
    public class TaskControlItem : ITabControl
    {
        public string Header { get { return Localization.Get("TabItem_Tasks"); } }
        public UserControl Control { get { return new TaskControl(); } }
        public int Order { get { return 3; } }
        public UserControl Settings { get { return new SettingsTaskControl(); } }
    }
}
