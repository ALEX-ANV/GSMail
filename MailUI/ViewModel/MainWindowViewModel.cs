using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using MailUI.Model.MainMenu;
using MailUI.Model.TabControlModels;

namespace MailUI.ViewModel
{
    public class MainWindowViewModel
    {
        [ImportMany(typeof(ITabControl))]
        private IEnumerable<ITabControl> TabCollection { get; set; }

        
        public ObservableCollection<TabItem> Tabs { get; set; }

        public ObservableCollection<MenuItemModel> MenuItems { get; set; }

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            MenuItems = new ObservableCollection<MenuItemModel>();
            foreach (var customTabControl in TabCollection.Where(t => t.Control != null).OrderBy(tab => tab.Order))
            {
                Tabs.Add(new TabItem() { Header = customTabControl.Header, Content = customTabControl.Control });
            }
        }
    }
}
