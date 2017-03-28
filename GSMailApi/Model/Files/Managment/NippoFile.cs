using System;
using System.Collections.ObjectModel;

namespace GSMailApi.Model.Files.Managment
{
    public class NippoFile : ManagmentFile
    {
        private ObservableCollection<ManagmentFile> _activities;
        public ObservableCollection<ManagmentFile> Activities
        {
            get { return _activities; }
            set { SetProperty(ref _activities, value);}
        }

    }

    public class Activity : ManagmentFile
    {
        private string _taskName;
        public string TaskName
        {
            get { return _taskName; }
            set { SetProperty(ref _taskName, value);}
        }

        private TimeSpan _beginWork;
        public TimeSpan BeginWork
        {
            get { return _beginWork; }
            set { SetProperty(ref _beginWork, value);}
        }

        private TimeSpan _endWork;
        public TimeSpan EndWork
        {
            get { return _endWork; }
            set { SetProperty(ref _endWork, value);}
        }

        private string _customer;
        public string Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value);}
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value);}
        }
    }
}
