using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class FinancialDimensionInterface
    {
        [JsonProperty("financialDimension")]
        public string FinancialDimension { get;set;}

        [JsonProperty("dimensionValue")]
        public string DimensionValue { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isSuspended")]
        public Boolean IsSuspended { get; set; }
    }
}
