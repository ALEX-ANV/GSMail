using MailUI.View;
using MailUI.ViewModel;

namespace MailUI.Model.MainMenu
{
    public interface IMenuItem
    {
        void AttachMenu(MainWindowViewModel viewModel, MainWindow view);
    }
}
