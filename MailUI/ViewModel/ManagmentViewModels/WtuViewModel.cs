using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailUI.Model;
using MailUI.View.ManagmentControls;

namespace MailUI.ViewModel.ManagmentViewModels
{
    [Export(typeof(ITemplateView))]
    public class WtuViewModel : BaseViewModel, ITemplateView
    {
        public void Attach(ManagmentViewModel managmentView, TemplateModel contentTemplate)
        {
            var model = new ManagmentFileModel(InstanceType, new WtuControlView());
            managmentView.ManagmentFiles.Add(model);
        }

        public string InstanceType { get { return "wtu"; } }
        public TemplateModel Template { get; set; }
        public string[] Content { get; set; }
    }
}
