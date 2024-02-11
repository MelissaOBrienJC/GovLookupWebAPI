using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookup.Models
{
    public class CabinetSummaryDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
    }
}
