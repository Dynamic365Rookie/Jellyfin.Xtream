using RestSharp.Serializers.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class OutboundInterfaceListBuilder
    {
        public static List<FinancialDimensionInterface> ConstructFinancialDimensionList(ArrayList _objectFormD365)
        {
            List<FinancialDimensionInterface> financialDimensions = new List<FinancialDimensionInterface>();

            foreach (Object[] item in _objectFormD365)
            {
                string financialDimension = item[0] as string;
                string dimensionValue = item[1] as string;
                string description = item[2] as string;
                int isSuspendedInt = (int)item[3];

                Boolean isSuspended = isSuspendedInt != 0;

                financialDimensions.Add(new FinancialDimensionInterface
                {
                    Description = description,
                    DimensionValue = dimensionValue,
                    FinancialDimension = financialDimension,
                    IsSuspended = isSuspended
                });
            }
            return financialDimensions;
        }

        public static List<FinancialDimensionLegalEntityInterface> ConstructFinancialDimensionLegalEntityList(ArrayList _objectFormD365)
        {
            List<FinancialDimensionLegalEntityInterface> financialDimensions = new List<FinancialDimensionLegalEntityInterface>();

            foreach (Object[] item in _objectFormD365)
            {
                string fianancialDimension = item[0] as string;
                string dimensionValue = item[1] as string;
                string description = item[2] as string;
                int isSuspendedInt = (int)item[3];

                Boolean isSuspended = isSuspendedInt != 0;

                financialDimensions.Add(new FinancialDimensionLegalEntityInterface
                {
                    LegalEntityId = description,
                    DimensionValue = dimensionValue,
                    FinancialDimension = fianancialDimension,
                    IsSuspended = isSuspended
                });
            }
            return financialDimensions;
        }

        public static List<VendorInterface> ConstructVendorList(ArrayList _objectFormD365)
        {
            List<VendorInterface> vendors = new List<VendorInterface>();

            foreach (Object[] item in _objectFormD365)
            {
                string vendorAccountNumber = item[0] as string;
                string vendorPartyType = item[1] as string;
                string vendorOrganizationName = item[2] as string;
                string personFirstName = item[3] as string;
                string personLastName = item[4] as string;
                string organizationNumber = item[5] as string;
                string vendorDUNSNumber = item[6] as string;
                string addressDescription = item[7] as string;
                string addressLocationRoles = item[8] as string;
                string addressCountryRegionId = item[9] as string;
                string addressCountryRegionISOCode = item[10] as string;
                string addressZipCode = item[11] as string;
                string addressStreet = item[12] as string;
                string addressCity = item[13] as string;
                string primaryEmailAddressDescription = item[14] as string;
                string primaryEmailAddress = item[15] as string;
                string onHoldStatus = item[16] as string;
                string currencyCode = item[17] as string;
                string siretNumber = item[18] as string;
                string nafCode = item[19] as string;
                string salesTaxGroupCode = item[20] as string;
                string taxExemptNumber = item[21] as string;
                string defaultPaymentTermsName = item[22] as string;
                string defaultVendorPaymentMethodName = item[23] as string;
                string bankAccountId = item[24] as string;
                ArrayList bankAccountIdsList = item[25] as ArrayList;

                List<VendBankAccount> vendBankAccounts = new List<VendBankAccount>();

                foreach (Object[] bankAccountItem in bankAccountIdsList)
                {

                    string bankVendorAccountNumber = bankAccountItem[0] as string;
                    string vendorBankAccountId = bankAccountItem[1] as string;
                    string isDefaultBankAccount = bankAccountItem[2] as string;
                    string bankName = bankAccountItem[3] as string;
                    string routingNumberType = bankAccountItem[4] as string;
                    string routingNumber = bankAccountItem[5] as string;
                    string bankAccountNumber = bankAccountItem[6] as string;
                    string swiftCode = bankAccountItem[7] as string;
                    string iban = bankAccountItem[8] as string;
                    string activeDate = bankAccountItem[9] as string;
                    string expirationDate = bankAccountItem[10] as string;
                    string bankMessage = bankAccountItem[11] as string;
                    string currentCurrencyCode = bankAccountItem[12] as string;
                    string bankAddressDescription = bankAccountItem[13] as string;
                    string addressCountry = bankAccountItem[14] as string;
                    string addressCountryISOCode = bankAccountItem[15] as string;
                    string bankAddressZipCode = bankAccountItem[16] as string;
                    string bankAddressStreet = bankAccountItem[17] as string;
                    string bankAddressCity = bankAccountItem[18] as string;



                    vendBankAccounts.Add(new VendBankAccount
                    {
                        VendorAccountNumber = bankVendorAccountNumber,
                        VendorBankAccountId = vendorBankAccountId,
                        IsDefaultBankAccount = isDefaultBankAccount,
                        BankName = bankName,
                        RoutingNumberType = routingNumberType,
                        RoutingNumber = routingNumber,
                        BankAccountNumber = bankAccountNumber,
                        ExpirationDate = expirationDate,
                        SwiftCode = swiftCode,
                        Iban = iban,
                        ActiveDate = activeDate,
                        BankMessage = bankMessage,
                        CurrentCurrencyCode = currentCurrencyCode,
                        AddressDescription = bankAddressDescription,
                        AddressCountry = addressCountry,
                        AddressCountryISOCode = addressCountryISOCode,
                        AddressZipCode = bankAddressZipCode,
                        AddressStreet = bankAddressStreet,
                        AddressCity = bankAddressCity

                    }
                    );
                }



                    vendors.Add(new VendorInterface
                {
                    VendorAccountNumber = vendorAccountNumber,
                    VendorPartyType = vendorPartyType,
                    VendorOrganizationName = vendorOrganizationName,
                    PersonFirstName = personFirstName,
                    PersonLastName = personLastName,
                    OrganizationNumber = organizationNumber,
                    VendorDUNSNumber = vendorDUNSNumber,
                    AddressDescription = addressDescription,
                    AddressLocationRoles = addressLocationRoles,
                    AddressCountryRegionId = addressCountryRegionId,
                    AddressCountryRegionISOCode = addressCountryRegionISOCode,
                    AddressZipCode = addressZipCode,
                    AddressStreet = addressStreet,
                    AddressCity = addressCity,
                    PrimaryEmailAddressDescription = primaryEmailAddressDescription,
                    PrimaryEmailAddress = primaryEmailAddress,
                    OnHoldStatus = onHoldStatus,
                    CurrencyCode = currencyCode,
                    SiretNumber = siretNumber,
                    NafCode = nafCode,
                    SalesTaxGroupCode = salesTaxGroupCode,
                    taxExemptNumber = taxExemptNumber,
                    DefaultPaymentTermsName = defaultPaymentTermsName,
                    DefaultVendorPaymentMethodName = defaultVendorPaymentMethodName,
                    BankAccountId = bankAccountId,
                    BankAccountIds = vendBankAccounts.ToArray()
                });
            }
            return vendors;
        }

        public static StockInterface ConstructStockList(ArrayList _objectFormD365)
        {
            StockInterface stockInterface = new StockInterface();

            List<StockLineInterface> stockLines = new List<StockLineInterface>();

            stockInterface.Stocks = new StockLineInterface[0];

            foreach (Object[] item in _objectFormD365)
            {
                string mainAccount = item[0] as string;
                string amountMST = item[1] as string;
                string costCenter = item[2] as string;
                string expenseNature = item[3] as string;
                string groupChartOfAccount = item[4] as string;
                string project = item[5] as string;
                string vendor = item[6] as string;
                string transDate = item[7] as string;
                string legalEntity = item[8] as string;
                string eventType = item[9] as string;
                string amountCur = item[10] as string;
                string currencyCode = item[11] as string;

                stockLines.Add(new StockLineInterface
                {
                    MainAccount = mainAccount,
                    AmountMST = amountMST,
                    CostCenter = costCenter,
                    ExpenseNature = expenseNature,
                    GroupChartOfAccount = groupChartOfAccount,
                    Project = project,
                    Vendor = vendor,
                    TransDate = transDate,
                    LegalEntity = legalEntity,
                    EventType = eventType,
                    AmountCur = amountCur,
                    CurrencyCode = currencyCode
                });
            }

            stockInterface.Stocks = stockLines.ToArray();

            return stockInterface;
        }

        public static AccrualInterface ConstructAccrualList(ArrayList _ojectFormD365)
        {
            AccrualInterface accrualInterface = new AccrualInterface();

            List<AccrualEntryInterface> accrualEntryList = new List<AccrualEntryInterface>();
            List<AccrualEntryLineInterface> accrualEntryLinesList = new List<AccrualEntryLineInterface>();

            string currentEntryType = "";
            string currentEntryId = "";
            string currentAccountingDate = "";
            string currentLegalEntity = "";
            string currentCurrencyCode ="";

            foreach (Object[] item in _ojectFormD365)
            {
                string entryType = item[0] as string;
                string entryId = item[1] as string;
                string accountingDate = item[2] as string;
                string legalEntity = item[3] as string;
                string mainAccount = item[4] as string;
                string amountMST = item[5] as string;
                string costCenter = item[6] as string;
                string expenseNature = item[7] as string;
                string groupChartOfAccount = item[8] as string;
                string project = item[9] as string;
                string vendor = item[10] as string;
                string amountCur = item[11] as string;
                string currencyCode = item[12] as string;

                if(currentEntryType == "" && currentEntryId == "")
                {
                    currentEntryType = entryType;
                    currentEntryId = entryId;
                    currentAccountingDate = accountingDate;
                    currentLegalEntity = legalEntity;
                    currentCurrencyCode = currencyCode;
                }

                if(currentEntryId != entryId || currentEntryType != entryType || currentAccountingDate != accountingDate || currentLegalEntity != legalEntity ||  currentCurrencyCode != currencyCode)
                {
                    accrualEntryList.Add(new AccrualEntryInterface
                    {
                        EntryType = currentEntryType,
                        EntryId = currentEntryId,
                        AccountingDate = currentAccountingDate,
                        LegalEntity = currentLegalEntity,
                        accrualEntryLineInterfaces = accrualEntryLinesList.ToArray(),
                        CurrencyCode = currentCurrencyCode
                    }
                    );

                    currentEntryId = entryId;
                    currentEntryType = entryType;
                    currentAccountingDate = accountingDate;
                    currentLegalEntity = legalEntity;
                    currentCurrencyCode = currencyCode;

                    accrualEntryLinesList = new List<AccrualEntryLineInterface>();
                }

                accrualEntryLinesList.Add(new AccrualEntryLineInterface
                {
                    MainAccount = mainAccount,
                    AmountMST = amountMST,
                    CostCenter = costCenter,
                    ExpenseNature = expenseNature,
                    GroupChartOfAccount = groupChartOfAccount,
                    Project = project,
                    Vendor = vendor,
                    AmountCur = amountCur
                });

            }

            accrualEntryList.Add(new AccrualEntryInterface
            {
                EntryType = currentEntryType,
                EntryId = currentEntryId,
                AccountingDate = currentAccountingDate,
                LegalEntity = currentLegalEntity,
                CurrencyCode = currentCurrencyCode,
                accrualEntryLineInterfaces = accrualEntryLinesList.ToArray()
            }
            );

            accrualInterface.accrualEntryInterfaces = accrualEntryList.ToArray();

            return accrualInterface;
        }

        public static VendorInvoiceInterface ConstructVendorInvoiceList(ArrayList _ojectFormD365)
        {
            VendorInvoiceInterface vendorInvoice = new VendorInvoiceInterface();

            List<VendorInvoiceHeaderInterface> invoiceHeaderList = new List<VendorInvoiceHeaderInterface>();
            List<VendorInvoiceLineInterface> invoiceLineList = new List<VendorInvoiceLineInterface>();

            string currentInvoiceRecId = "";

            string invoiceId="";
            string invoiceDate="";
            string dueDate="";
            string currencyCode="";
            string vendorAccount="";
            string invoiceRecId="";
            string invoiceUrl="";
            string legalEntity="";
            string invoiceDescription="";
            string bankAccountNum="";
            string bankAccountIban="";
            string bankAccountSWIFT="";
            string invoiceType = "";
            string documentDate = "";

            foreach (Object[] item in _ojectFormD365)
            {

                invoiceRecId = item[5] as string;

                string mainAccount = item[12] as string;
                string amountCur = item[13] as string;
                string amountMST = item[14] as string;
                string costCenter = item[15] as string;
                string expenseNature = item[16] as string;
                string groupChartOfAccount = item[17] as string;
                string project = item[18] as string;
                string vendor = item[19] as string;
                string taxCode = item[20] as string;

                if (currentInvoiceRecId == "" )
                {
                    currentInvoiceRecId = invoiceRecId;
                }

                if (currentInvoiceRecId != invoiceRecId )
                {
                    invoiceHeaderList.Add(new VendorInvoiceHeaderInterface
                    {
                        InvoiceId = invoiceId,
                        InvoiceDate = invoiceDate,
                        DueDate = dueDate,
                        CurrencyCode = currencyCode,
                        VendorAccount = vendorAccount,
                        InvoiceRecId = currentInvoiceRecId,
                        InvoiceURL = invoiceUrl,
                        LegalEntity = legalEntity,
                        InvoiceDescription = invoiceDescription,
                        VendorBankAccountAccountNum = bankAccountNum,
                        VendorBankAccountIBAN = bankAccountIban,
                        VendorBankAccountSWIFT = bankAccountSWIFT,
                        InvoiceType = invoiceType,
                        DocumentDate = documentDate,
                        vendorInvoiceLineInterfaces = invoiceLineList.ToArray()
                    }
                    );

                    currentInvoiceRecId = invoiceRecId;

                    invoiceLineList = new List<VendorInvoiceLineInterface>();
                }

                invoiceId = item[0] as string;
                invoiceDate = item[1] as string;
                dueDate = item[2] as string;
                currencyCode = item[3] as string;
                vendorAccount = item[4] as string;
                invoiceUrl = item[6] as string;
                legalEntity = item[7] as string;
                invoiceDescription = item[8] as string;
                bankAccountNum = item[9] as string;
                bankAccountIban = item[10] as string;
                bankAccountSWIFT = item[11] as string;
                invoiceType = item[21] as string;
                documentDate = item[22] as string;


                invoiceLineList.Add(new VendorInvoiceLineInterface
                {
                    MainAccount = mainAccount,
                    AmountCur = amountCur,
                    AmountMST = amountMST,
                    CostCenter = costCenter,
                    ExpenseNature = expenseNature,
                    GroupChartOfAccount = groupChartOfAccount,
                    Project = project,
                    Vendor = vendor,
                    TaxCode = taxCode
                });

            }

            invoiceHeaderList.Add(new VendorInvoiceHeaderInterface
            {
                InvoiceId = invoiceId,
                InvoiceDate = invoiceDate,
                DueDate = dueDate,
                CurrencyCode = currencyCode,
                VendorAccount = vendorAccount,
                InvoiceRecId = invoiceRecId,
                InvoiceURL = invoiceUrl,
                LegalEntity = legalEntity,
                InvoiceDescription = invoiceDescription,
                VendorBankAccountAccountNum = bankAccountNum,
                VendorBankAccountIBAN = bankAccountIban,
                VendorBankAccountSWIFT = bankAccountSWIFT,
                InvoiceType = invoiceType,
                DocumentDate = documentDate,
                vendorInvoiceLineInterfaces = invoiceLineList.ToArray()
            }
            );

            vendorInvoice.vendorInvoiceHeaderInterfaces = invoiceHeaderList.ToArray();

            return vendorInvoice;
        }
    }
}
