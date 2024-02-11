using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookup.Models
{
    public class LegislatorSummaryDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }       
        public string Gender { get; set; }       
        public string Party { get; set; }
        public string StateName { get; set; }
        public string District { get; set; }
        public string Chamber { get; set;  }
        public string Url { get; set; }
        public string Phone { get; set; }
    }
}
