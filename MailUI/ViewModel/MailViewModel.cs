using System;
using System.ComponentModel.Composition;

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
