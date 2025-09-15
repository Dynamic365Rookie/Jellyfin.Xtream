using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class AccrualInterface
    {
        [JsonProperty("AccountingEntries")]
        public AccrualEntryInterface[] accrualEntryInterfaces { get; set; }
    }

    public class AccrualEntryInterface
    {
        [JsonProperty("EntryType")]
        public string EntryType { get; set;}

        [JsonProperty("EntryId")]
        public string EntryId { get;set;}

        [JsonProperty("AccountingDate")]
        public string AccountingDate { get; set; }

        [JsonProperty("LegalEntity")]
        public string LegalEntity { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("Lines")]
        public AccrualEntryLineInterface[] accrualEntryLineInterfaces {get;set; }
    }

    public class AccrualEntryLineInterface
    {
        [JsonProperty("MainAccount")]
        public string MainAccount { get; set; }

        [JsonProperty("AmountMST")]
        public string AmountMST { get; set; }

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
        [JsonProperty("AmountCur")]
        public string AmountCur { get; set; }

    }
}
