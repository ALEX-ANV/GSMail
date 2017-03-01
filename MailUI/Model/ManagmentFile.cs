using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MailUI.Context;

namespace MailUI.Model
{
    class ManagmentFileModel
    {
        public string Header { get; set; }

        public UserControl Control { get; set; }
       

        public ManagmentFileModel(string header, UserControl control)
        {
            Header = header;
            Control = control;
        }
    }
}
