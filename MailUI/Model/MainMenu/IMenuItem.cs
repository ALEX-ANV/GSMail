using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailUI.View;
using MailUI.ViewModel;

namespace MailUI.Model.MainMenu
{
    public interface IMenuItem
    {
        void AttachMenu(MainWindowViewModel viewModel, MainWindow view);
    }
}
