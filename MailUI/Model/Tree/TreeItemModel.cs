using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace MailUI.Model.Tree
{
    public class TreeItemModel
    {
        [XmlAttribute("directoryPath")]
        public string FullName { get; set; }
        
        [XmlAttribute("hashCode")]
        public int HashCode { get; set; }

        [XmlAttribute("taskName")]
        public string NameTask { get; set; }

        [XmlArray("tasks"), XmlArrayItem("task")]
        public ObservableCollection<TreeItemModel> ChildDirectories { get; set; }

        public TreeItemModel(string name, string path, int hash)
        {
            NameTask = name;
            FullName = path;
            HashCode = hash;
        }

        public TreeItemModel() { }
    }
}
