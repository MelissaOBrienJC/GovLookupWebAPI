using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class Bill 
    {

        public string LegislatorId { get; set; }
        public string Congress { get; set; }
        public string BillType { get; set; }
        public string BillId { get; set; }
        public string shortTitle { get; set; }
        public DateTime CosponsoredDate { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string SponsorParty { get; set; }
        public DateTime LatestMajorActionDate { get; set; }
        public string LatestMajorAction { get; set; }
        public string SponsorType { get; set; }

    }
}