using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;


namespace MailUI.ViewModel
{
    [Export(typeof(ISettingsItem))]
    public class TaskViewModel : BaseViewModel, ISettingsItem
    {
        public ObservableCollection<DirectoryInfo> Directories { get; set; }

        public TaskViewModel(string pathDirectory)
        {
            if (!Directory.Exists(pathDirectory))
            {
                return;
            }
            var directories = new DirectoryInfo(pathDirectory).GetDirectories();
            
            Directories = new ObservableCollection<DirectoryInfo>(directories);
        }

        public TaskViewModel() { }


        public void AttachSettings(ManagmentViewModel mainView)
        {
            throw new NotImplementedException();
        }
    }
}
