using System.Windows.Controls;
using MailUI.View;

namespace MailUI.ViewModel
{
    public interface ITabControl
    {
        string Header { get; }

        void AddTabItem(MainWindow baseView);
    }
}