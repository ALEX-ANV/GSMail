using System;
using MailUI.Utils;

namespace MailUI.Model.ManagmentFiles
{
    public class NippoFile : ManagmentFile
    {
        public StringList<BaseModel> Activities { get; set; }
    }

    public class Activity : ManagmentFile
    {
        public string TaskName { get; set; }

        public TimeSpan BeginWork { get; set; }

        public TimeSpan EndWork { get; set; }

        public string Customer { get; set; }

        public string Description { get; set; }
    }
}
