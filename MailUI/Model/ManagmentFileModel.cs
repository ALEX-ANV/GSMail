using System.Windows.Controls;

namespace MailUI.Model
{
    public class ManagmentFileModel
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
