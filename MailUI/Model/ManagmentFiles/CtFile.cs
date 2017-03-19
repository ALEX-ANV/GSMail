using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using MailUI.Utils;

namespace MailUI.Model.ManagmentFiles
{
    public class CtFile : ManagmentFile
    {
        private ObservableCollection<ManagmentFile> _ctWorking;

        public ObservableCollection<ManagmentFile> CtWorking
        {
            get { return _ctWorking; }
            set { SetProperty(ref _ctWorking, value);}
        }
    }

    public class LineCtWorkingDay : ManagmentFile
    {
        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set { SetProperty(ref _startTime, value); }
        }

        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set { SetProperty(ref _endTime, value); }
        }

        private string _startDinner;
        public string StartDinner
        {
            get { return _startDinner; }
            set { SetProperty(ref _startDinner, value); }
        }

        private string _endDinner;
        public string EndDinner
        {
            get { return _endDinner; }
            set { SetProperty(ref _endDinner, value); }
        }

        private DateTime _day;
        public DateTime Day
        {
            get { return _day; }
            set { SetProperty(ref _day, value);}
        }
    }
}
