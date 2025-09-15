using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class FinancialDimensionLegalEntityInterface
    {
        [JsonProperty("financialDimension")]
        public string FinancialDimension { get; set; }

        [JsonProperty("dimensionValue")]
        public string DimensionValue { get; set; }

        [JsonProperty("LegalEntityId")]
        public string LegalEntityId { get; set; }

        [JsonProperty("isSuspended")]
        public Boolean IsSuspended { get; set; }
    }
}
