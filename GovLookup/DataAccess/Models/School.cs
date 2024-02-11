using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class School
    {
        public int SeqNo { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string Award  { get; set; }
    }
}