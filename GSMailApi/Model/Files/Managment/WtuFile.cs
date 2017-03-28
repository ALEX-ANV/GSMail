using System;
using System.Collections.Generic;

namespace GSMailApi.Model.Files.Managment
{
    public class WtuFile : ManagmentFile
    {
        public List<BaseModel> TimeWorkingDay { get; set; }
    }

    public class WorkingDay : ManagmentFile
    {
        public TimeSpan BeginWork { get; set; }

        public TimeSpan EndWork { get; set; }
    }
}
