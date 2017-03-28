using System.Collections.Generic;
using System.Linq;

namespace GSMailApi.Model.Files.Managment
{
    public class DwtFile : ManagmentFile
    {
        public string FieldMonth { get; set; }

        public double WorkingDay { get; set; }

        public double WorkingDayPercent => 21 / WorkingDay * 100;

        public List<BaseModel> TaskBasis { get; set; }

        public double TaskBasisEfforts
        {
            get
            {
                if (TaskBasis != null && TaskBasis.Count > 0 && TaskBasis.First() is LineDwtBasis)
                {
                    return TaskBasis.Sum(lineDwtBasise => (lineDwtBasise as LineDwtBasis).Efforts);
                }
                return 0;
            }
        }

        public List<BaseModel> NippoBasis { get; set; }

        public double NippoBasisEfforts
        {
            get
            {
                if (NippoBasis != null && NippoBasis.Count > 0 && NippoBasis.First() is LineDwtBasis)
                {
                    return NippoBasis.Sum(lineDwtBasise => (lineDwtBasise as LineDwtBasis).Efforts);
                }
                return 0;
            }
        }

        public List<BaseModel> BtBasis { get; set; }

        public double BtBasisEfforts
        {
            get
            {
                if (BtBasis != null && BtBasis.Count > 0 && BtBasis.First() is LineDwtBasis)
                {
                    return BtBasis.Sum(lineDwtBasise => (lineDwtBasise as LineDwtBasis).Efforts);
                }
                return 0;
            }
        }

        public double Reserved => WorkingDay - (BtBasisEfforts + NippoBasisEfforts + TaskBasisEfforts);
    }

    public class LineDwtBasis : ManagmentFile
    {
        public string TaskName { get; set; }

        public string Member { get; set; }

        public double Efforts { get; set; }

        public string Description { get; set; }
    }
}
