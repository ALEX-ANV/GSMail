using System.Windows.Controls;
using MailUI.View.Settings;
using System.ComponentModel.Composition;
using MailUI.Utils.Languages;

namespace MailUI.Model.TabControlModels
{
    [Export(typeof(ITabControl))]
    public class CommonControlItem : ITabControl
    {
        public string Header { get { return Localization.Get("TabItem_Common_Settings"); } }
        public UserControl Control { get; }
        public int Order { get { return 0; } }
        public UserControl Settings { get {return new SettingsCommon();} }
    }
}
