using System;
using MailUI.Utils;

namespace MailUI.Model.ManagmentFiles
{
    public class WtuFile : ManagmentFile
    {
        public StringList<BaseModel> TimeWorkingDay { get; set; }
    }

    public class WorkingDay : ManagmentFile
    {
        public TimeSpan BeginWork { get; set; }

        public TimeSpan EndWork { get; set; }
    }
}
