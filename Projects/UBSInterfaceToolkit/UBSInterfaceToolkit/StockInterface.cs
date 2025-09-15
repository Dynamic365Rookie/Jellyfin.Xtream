using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class StockInterface
    {
        [JsonProperty("Stocks")]
        public StockLineInterface[] Stocks {get;set;}
    }

    [JsonObject("Line")]
    public class StockLineInterface
    {
        [JsonProperty("MainAccount")]
        public string MainAccount { get; set; }

        [JsonProperty("AmountMST")]
        public string AmountMST{ get; set; }

        [JsonProperty("CostCenter")]
        public string CostCenter { get; set; }

        [JsonProperty("ExpenseNature")]
        public string ExpenseNature { get; set; }

        [JsonProperty("GroupChartOfAccount")]
        public string GroupChartOfAccount { get; set; }

        [JsonProperty("Project")]
        public string Project { get; set; }

        [JsonProperty("Vendor")]
        public string Vendor { get; set; }

        [JsonProperty("TransDate")]
        public string TransDate { get; set; }

        [JsonProperty("LegalEntity")]
        public string LegalEntity { get; set; }

        [JsonProperty("EventType")]
        public string EventType {get; set; }

        [JsonProperty("AmountCur")]
        public string AmountCur { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }
    }

    
}
