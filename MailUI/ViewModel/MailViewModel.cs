using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MailUI.ViewModel.ManagmentViewModels;

namespace MailUI.ViewModel
{
    [Export(typeof(ISettingsItem))]
    public class MailViewModel : BaseViewModel, ISettingsItem
    {
        public void AttachSettings(ManagmentViewModel mainView)
        {
            throw new NotImplementedException();
        }
    }
}
