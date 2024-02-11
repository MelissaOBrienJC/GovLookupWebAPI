using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class KeyDecisionsOpinionsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleDesc { get; set; }
        public string Year { get; set; }
        public string Docket { get; set; }
        public string Description { get; set; }
        public string Outcome { get; set; }
        public string Tally { get; set; }
        public string VoteCast { get; set; }
        public string Type { get; set; }
        public string Quote { get; set; }
        public int SeqNo { get; set; }



    }
}