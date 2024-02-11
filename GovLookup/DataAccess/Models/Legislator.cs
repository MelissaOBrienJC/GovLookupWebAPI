using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;
using GovLookup.Models;

namespace GovLookup.Models
{
    public class Legislator : GovEmployeeBase
    {

        
        public string Congress { get; set; }
        public string Chamber { get; set; }     
        public string LeadershipRole { get; set; }
        public string Seniority { get; set; }
        public string NextElection { get; set; }
        public string TotalVotes { get; set; }
        public string MissedVotes { get; set; }
        public string TotalPresent { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public string District { get; set; }
        public string AtLarge { get; set; }
        public string MissedVotesPct { get; set; }
        public string VotesWithPartyPct { get; set; }
        public string Map { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public string Zoom { get; set; }
        public IEnumerable<KeyVote> KeyVotes { get; set; }
        public IEnumerable<School> Education { get; set; }
        public IEnumerable<IndustryFinance> IndustryFinance { get; set; }
        public PieChart IndustryFinanceChart { get; set; }
        public PieChartOptions IndustryFinanceChartOptions { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<Bill> Bills { get; set; }
        public IEnumerable<Committee> Committees { get; set; }

    }
}