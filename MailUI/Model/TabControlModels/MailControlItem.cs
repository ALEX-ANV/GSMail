using System.ComponentModel.Composition;
using System.Windows.Controls;
using MailUI.Utils.Languages;
using MailUI.View.MainWindowUserControls;
using MailUI.View.Settings;

namespace MailUI.Model.TabControlModels
{
    [Export(typeof(ITabControl))]
    public class MailControlItem : ITabControl
    {
        public string Header { get { return Localization.Get("TabItem_Mail"); } }

        public UserControl Control { get { return new MailControl(); } }

        public int Order { get { return 1; } }

        public UserControl Settings
        {
            get { return new SettingsMailControl(); }
        }
    }
}
