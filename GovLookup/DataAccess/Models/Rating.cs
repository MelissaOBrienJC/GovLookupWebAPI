using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class Rating
    {
        public int SeqNo { get; set; }
        public string Organization { get; set; }
        public string OrganizationCode { get; set; }
        public string Issue { get; set; }
        public string  Type  { get; set; }
        public string RatingValue { get; set; }
        public string RatingDate { get; set; }
        public string RatingDescription { get; set; }
        public string Link { get; set; }
    }
}