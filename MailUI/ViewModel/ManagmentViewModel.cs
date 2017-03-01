using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailUI.Model;
using MailUI.View.ManagmentControls;
using MailUI.ViewModel.ManagmentViewModels;

namespace MailUI.ViewModel
{
    class ManagmentViewModel : BaseViewModel
    {
        public ObservableCollection<ManagmentFileModel> ManagmentFiles
        {
            get
            {
                var file = Templates.TemplateFiles["ct"];
                var list = new ObservableCollection<ManagmentFileModel>
                {
                    new ManagmentFileModel("ct", new CtControl(new CtViewModel(file)))
                };
                return list;
            }
        }

        public ManagmentViewModel()
        {
            
        }
    }
}
