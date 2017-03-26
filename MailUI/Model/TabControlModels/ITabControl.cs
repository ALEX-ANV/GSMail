using System.Windows.Controls;

namespace MailUI.Model.TabControlModels
{
    public interface ITabControl
    {
        string Header { get; }

        UserControl Control { get; }

        int Order { get; }

        UserControl Settings { get; }
    }
}