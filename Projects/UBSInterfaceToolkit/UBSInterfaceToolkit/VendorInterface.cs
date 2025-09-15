using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{

    public class VendBankAccount
    {
        [JsonProperty("vendorAccountNumber")]
        public string VendorAccountNumber { get; set; }

        [JsonProperty("vendorBankAccountId")]
        public string VendorBankAccountId { get; set; }

        [JsonProperty("isDefaultBankAccount")]
        public string IsDefaultBankAccount { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("routingNumberType")]
        public string RoutingNumberType { get; set; }

        [JsonProperty("routingNumber")]
        public string RoutingNumber { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [JsonProperty("swiftCode")]
        public string SwiftCode { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("activeDate")]
        public string ActiveDate { get; set; }

        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty("bankMessage")]
        public string BankMessage { get; set; }

        [JsonProperty("currentCurrencyCode")]
        public string CurrentCurrencyCode { get; set; }

        [JsonProperty("addressDescription")]
        public string AddressDescription { get; set; }

        [JsonProperty("addressCountry")]
        public string AddressCountry { get; set; }

        [JsonProperty("addressCountryISOCode")]
        public string AddressCountryISOCode { get; set; }

        [JsonProperty("addressZipCode")]
        public string AddressZipCode { get; set; }

        [JsonProperty("addressStreet")]
        public string AddressStreet { get; set; }

        [JsonProperty("addressCity")]
        public string AddressCity { get; set; }

    }

    public class VendorInterface
    {
        [JsonProperty("vendorAccountNumber")]
        public string VendorAccountNumber { get; set; }

        [JsonProperty("vendorPartyType")]
        public string VendorPartyType { get; set; }

        [JsonProperty("vendorOrganizationName")]
        public string VendorOrganizationName { get; set; }

        [JsonProperty("personFirstName")]
        public string PersonFirstName { get; set; }

        [JsonProperty("personLastName")]
        public string PersonLastName { get; set; }

        [JsonProperty("organizationNumber")]
        public string OrganizationNumber { get; set; }

        [JsonProperty("vendorDUNSNumber")]
        public string VendorDUNSNumber { get; set; }

        [JsonProperty("addressDescription")]
        public string AddressDescription { get; set; }

        [JsonProperty("addressLocationRoles")]
        public string AddressLocationRoles { get; set; }

        [JsonProperty("addressCountryRegionId")]
        public string AddressCountryRegionId { get; set; }

        [JsonProperty("addressCountryRegionISOCode")]
        public string AddressCountryRegionISOCode { get; set; }

        [JsonProperty("addressZipCode")]
        public string AddressZipCode { get; set; }

        [JsonProperty("addressStreet")]
        public string AddressStreet { get; set; }

        [JsonProperty("addressCity")]
        public string AddressCity { get; set; }

        [JsonProperty("primaryEmailAddressDescription")]
        public string PrimaryEmailAddressDescription { get; set; }

        [JsonProperty("primaryEmailAddress")]
        public string PrimaryEmailAddress { get; set; }

        [JsonProperty("onHoldStatus")]
        public string OnHoldStatus { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("siretNumber")]
        public string SiretNumber { get; set; }

        [JsonProperty("nafCode")]
        public string NafCode { get; set; }

        [JsonProperty("salesTaxGroupCode")]
        public string SalesTaxGroupCode { get; set; }

        [JsonProperty("TaxExemptNumber")]
        public string taxExemptNumber { get; set; }

        [JsonProperty("defaultPaymentTermsName")]
        public string DefaultPaymentTermsName { get; set; }

        [JsonProperty("defaultVendorPaymentMethodName")]
        public string DefaultVendorPaymentMethodName { get; set; }

        [JsonProperty("bankAccountId")]
        public string BankAccountId { get; set; }

        [JsonProperty("bankAccountIds")]
        public VendBankAccount[] BankAccountIds { get; set; }
    }
}
