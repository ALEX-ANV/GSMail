using System;
using MailUI.Utils;

namespace MailUI.Model.ManagmentFiles
{
    public class CtFile : ManagmentFile
    {
        public StringList<LineCtWorkingDay> CtWorking { get; set; } 
    }

    public class LineCtWorkingDay : ManagmentFile
    {
        private string _workingday;

        public string WorkingDay
        {
            get { return _workingday; }
            set
            {
                _workingday = value;
                OnPropertyChanged();
            }
        }

        private DateTime day;

        public DateTime Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged();
            }
        }
    }
}
