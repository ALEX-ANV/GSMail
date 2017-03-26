using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MailUI.Model.MainMenu
{
    public class MenuItemModel
    {
        public MenuItemModel(string header, object icon, bool visible, string toolTip, ICommand command)
        {
            Header = header;
            Icon = icon;
            Visible = visible;
            ToolTip = toolTip;
            Command = command;
        }

        public string Header { get; }
        
        public object Icon { get; }
        
        public bool Visible { get; }
        
        public string ToolTip { get; }

        public ICommand Command { get; }
    }
}
