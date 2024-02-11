using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovLookup.Models
{
    public class CurrentBills
    {
            public int id { get; set; }

            public string time_period { get; set; }
            public string number { get; set; }
       
            public string title { get; set; }
           
            public string url { get; set; }
     
            public DateTime? record_add_dt { get; set; }



    }
}