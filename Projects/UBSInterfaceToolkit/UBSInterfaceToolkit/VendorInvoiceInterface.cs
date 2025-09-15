using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class VendorInvoiceInterface
    {
        [JsonProperty("Invoices")]
        public VendorInvoiceHeaderInterface[] vendorInvoiceHeaderInterfaces { get; set; }
    }

    public class VendorInvoiceHeaderInterface
    {
        [JsonProperty("InvoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("InvoiceDate")]
        public string InvoiceDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("VendorAccount")]
        public string VendorAccount { get; set; }

        [JsonProperty("InvoiceRecId")]
        public string InvoiceRecId { get; set; }

        [JsonProperty("InvoiceURL")]
        public string InvoiceURL { get; set; }

        [JsonProperty("LegalEntity")]
        public string LegalEntity { get; set; }

        [JsonProperty("InvoiceDescription")]
        public string InvoiceDescription { get; set; }

        [JsonProperty("VendorBankAccountAccountNum")]
        public string VendorBankAccountAccountNum { get; set; }

        [JsonProperty("VendorBankAccountIBAN")]
        public string VendorBankAccountIBAN { get; set; }

        [JsonProperty("VendorBankAccountSWIFT")]
        public string VendorBankAccountSWIFT { get; set; }

        [JsonProperty("InvoiceType")]
        public string InvoiceType { get; set; }

        [JsonProperty("DocumentDate")]
        public string DocumentDate { get; set; }

        [JsonProperty("Lines")]
        public VendorInvoiceLineInterface[] vendorInvoiceLineInterfaces { get; set; }
    }

    public class VendorInvoiceLineInterface
    {
        [JsonProperty("MainAccount")]
        public string MainAccount { get; set; }

        [JsonProperty("AmountCur")]
        public string AmountCur { get; set; }

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

        [JsonProperty("TaxCode")]
        public string TaxCode { get; set; }
    }
}
