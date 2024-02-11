using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GovLookup.DataModel;

namespace GovLookup.Models
{
    public class PieChart
    {
        public List<string> labels { get; set; }
        public List<PieChartDataset> datasets { get; set; }
    }
    public class PieChartOptions
    {
        public PieChartTitle title { get; set; }
        public PieChartLegend legend { get; set; }

    }


    public class PieChartTitle
    {
        public bool display { get; set; }
        public string text { get; set; }
        public int fontsize { get; set; }
    }

    public class PieChartLegend
    {
        public string position { get; set; }
    }
}