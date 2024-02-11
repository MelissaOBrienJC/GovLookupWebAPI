using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class Cabinet : GovEmployeeBase
    {
       
        public string Title { get; set; }
        public string FormerPosition { get; set; }
        public string Summary { get; set; }
        public string BirthLocation { get; set; }
        public string TwitterFeed { get; set; }
        public string TwitterFeedTitle { get; set; }
        public List<School> Education { get; set; }
        public List<JobPosition> JobHistory { get; set; }
        public string AssumedOffice { get; set; }


    }
}