using GovLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookup.Models
{
    public class CabinetDetailDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string Party { get; set; }

        public string Phone { get; set; }
        public string Gender { get; set; }
        public string TwitterAccount { get; set; }
        public string FacebookAccount { get; set; }
        public string YoutubeAccount { get; set; }

        public string Url { get; set; }

        public string AssumedOffice { get; set; }       
        public string FormerPosition { get; set; }
            
        public string BirthLocation { get; set; }
        public string TwitterFeed { get; set; }
        
        public IEnumerable<SchoolDto> Education { get; set; }
        public IEnumerable<JobPositionDto> JobHistory { get; set; }
       
    
    }
}
