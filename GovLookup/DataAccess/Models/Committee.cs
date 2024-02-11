using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class Committee
    {
        public string name { get; set; }
        public string code { get; set; }
        public string side { get; set; }
        public string title { get; set; }
        public int rank_in_party { get; set; }

        public string begin_date { get; set; }
        public string end_date { get; set; }
        public DateTime record_add_date { get; set; }

    }
}