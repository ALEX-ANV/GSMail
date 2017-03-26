using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MailUI.Model.TabControlModels;

namespace MailUI.ViewModel
{
    public class SettingsViewModel
    {
        public ObservableCollection<TabItem> Tabs { get; set; }

        [ImportMany(typeof(ITabControl))]
        private IEnumerable<ITabControl> TabCollection { get; set; }

        public ICommand Cancel { get; set; }

        public SettingsViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var customTabControl in TabCollection.OrderBy(tab => tab.Order).Where(t => t.Settings != null))
            {
                Tabs.Add(new TabItem() { Header = customTabControl.Header, Content = customTabControl.Settings });
            }
        }
    }
}
