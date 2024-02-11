using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookup.Models
{
    public class RatingDto
    {
        public string Organization { get; set; }       
        public string OrganizationCode { get; set; }
        public string Link { get; set; }
        public string RatingValue { get; set; }      
    }
}
