using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovLookup.DataModel
{
    
        public class Address
        {
            public string address { get; set; }
        }

        public class Benchmark
        {
            public string id { get; set; }
            public bool isDefault { get; set; }
            public string benchmarkName { get; set; }
            public string benchmarkDescription { get; set; }
        }

        public class Input
        {
            public Address address { get; set; }
            public Benchmark benchmark { get; set; }
    }

        public class Coordinates
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class TigerLine
        {
            public string tigerLineId { get; set; }
            public string side { get; set; }
        }

    public class AddressComponents
    {
        public string state { get; set; }
        public string suffixQualifier { get; set; }
        public string fromAddress { get; set; }
        public string toAddress { get; set; }
        public string preQualifier { get; set; }
        public string preDirection { get; set; }
        public string preType { get; set; }
        public string streetName { get; set; }
        public string suffixType { get; set; }
        public string suffixDirection { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
    }

    public class AddressMatch
    {
        public string matchedAddress { get; set; }
        public Coordinates coordinates { get; set; }
        public TigerLine tigerLine { get; set; }
        public AddressComponents addressComponents { get; set; }
    }

    public class AddressResult
    {
        public Input input { get; set; }
        public List<AddressMatch> addressMatches { get; set; }
    }

   

    }