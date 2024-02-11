using GovLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookup.Models
{
    public class JudiciaryDetailDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string AppointedBy { get; set; }
        public string TenureYears { get; set; }
        public string TenureMonths { get; set; }
      
        public IEnumerable<KeyDecisionsDto> KeyDecisions { get; set; }
        public IEnumerable<KeyDecisionsOpinionsDto> KeyDecisionsOpinions { get; set; }
    }
}
