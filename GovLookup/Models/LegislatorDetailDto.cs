using GovLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovLookup.Models
{
    public class LegislatorDetailDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Party { get; set; }
        public string StateName { get; set; }
        public string District { get; set; }
        public string Chamber { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public string LeadershipRole { get; set; }
        public string NextElection { get; set; }
        public string TwitterAccount { get; set; }
        public string FacebookAccount { get; set; }
        public string YoutubeAccount { get; set; }
        public string VoteSmartId { get; set; }
        public VoteStatDto VoteStat { get; set; }
        public IEnumerable<RatingDto> Ratings { get; set; }
        public IEnumerable<KeyVoteDto> KeyVotes { get; set; }
        public IEnumerable<BillDto> Bills { get; set; }
        public IEnumerable<CommiteeDto> Committees { get; set; }

        public IEnumerable<IndustryFinanceDto> IndustryFinance { get; set; }
        public PieChart IndustryFinanceChart { get; set; }
        public PieChartOptions IndustryFinanceChartOptions { get; set; }
    }
}
