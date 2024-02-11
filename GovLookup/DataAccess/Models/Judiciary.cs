using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class Judiciary : GovEmployeeBase
    {
       
        public string Title { get; set; }
        public string AppointedBy { get; set; }
        public string TenureYears { get; set; }
        public string TenureMonths { get; set; }
        public List<KeyDecisions> KeyDecisions { get; set; }
        public List<KeyDecisionsOpinions> KeyDecisionsOpinions { get; set; }
        public List<School> Education { get; set; }


    }
}