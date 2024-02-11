using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string Position { get; set; }
        
    }
}