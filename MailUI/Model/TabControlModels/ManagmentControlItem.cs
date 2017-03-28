using System.ComponentModel.Composition;
using System.Windows.Controls;
using MailUI.Utils.Languages;
using MailUI.View.MainWindowUserControls;
using MailUI.View.Settings;

namespace MailUI.Model.TabControlModels
{
    [Export(typeof(ITabControl))]
    public class ManagmentControlItem : ITabControl
    {
        public string Header { get { return Localization.Get("TabItem_Managment"); } }

        public UserControl Control { get { return new ManagmentControl(); } }

        public int Order { get { return 2; } }

        public UserControl Settings
        {
            get
            {
                return new SettingsManagmentControl();
            }
        }
    }
}
