using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using MailUI.Model;
using MailUI.Model.TabControlModels;
using MailUI.ViewModel.ManagmentViewModels;

namespace MailUI.ViewModel
{
    [Export(typeof(ISettingsItem))]
    public class ManagmentViewModel : BaseViewModel, ISettingsItem
    {
        public ObservableCollection<ManagmentFileModel> ManagmentFiles { get; set; }

        [ImportMany(typeof(ITemplateView))]
        private IEnumerable<ITemplateView> TemplateViews { get; set; }

        public ManagmentViewModel()
        {
            ManagmentFiles = new ObservableCollection<ManagmentFileModel>();
            var templates = new Templates();
            AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var templateView in TemplateViews)
            {
                templateView.Attach(this, templates.TemplateFiles[templateView.InstanceType]);
            }
        }

        public void AttachSettings(ManagmentViewModel mainView)
        {
            throw new System.NotImplementedException();
        }
    }
}
