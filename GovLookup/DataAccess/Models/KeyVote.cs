using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class KeyVote 
    {
        public string Congress { get; set; }
        public string Issue { get; set; }
        public string FinalTitle { get; set; }
        public string Status { get; set; }
        public DateTime VoteDate { get; set; }
        public string VoteCast { get; set; }
        public string Synopsis { get; set; }
        public string CongressYear { get; set; }
        public int Session { get; set; }
        public string VoteNumber { get; set; }
        public string IssueNo { get; set; }
    }
}