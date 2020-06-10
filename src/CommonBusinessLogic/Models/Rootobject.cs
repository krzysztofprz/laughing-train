using System;
using System.Collections.Generic;
using System.Text;

namespace CommonBusinessLogic.Models
{
    public class Rootobject
    {
        public Content[] Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public object LogId { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public Validationerrors ValidationErrors { get; set; }
    }

    public class Validationerrors
    {
    }

    public class Content
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object MerchantComment { get; set; }
        public Billingaddress BillingAddress { get; set; }
        public Shippingaddress ShippingAddress { get; set; }
        public float SubTotalInclVat { get; set; }
        public float SubTotalVat { get; set; }
        public float ShippingCostsVat { get; set; }
        public float TotalInclVat { get; set; }
        public float TotalVat { get; set; }
        public float OriginalSubTotalInclVat { get; set; }
        public float OriginalSubTotalVat { get; set; }
        public float OriginalShippingCostsInclVat { get; set; }
        public float OriginalShippingCostsVat { get; set; }
        public float OriginalTotalInclVat { get; set; }
        public float OriginalTotalVat { get; set; }
        public Line[] Lines { get; set; }
        public object Phone { get; set; }
        public string Email { get; set; }
        public object CompanyRegistrationNo { get; set; }
        public object VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public float ShippingCostsInclVat { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public object ChannelCustomerNo { get; set; }
        public Extradata ExtraData { get; set; }
    }

    public class Billingaddress
    {
        public object Line1 { get; set; }
        public object Line2 { get; set; }
        public object Line3 { get; set; }
        public string Gender { get; set; }
        public object CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public object HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string CountryIso { get; set; }
        public object Original { get; set; }
    }

    public class Shippingaddress
    {
        public object Line1 { get; set; }
        public object Line2 { get; set; }
        public object Line3 { get; set; }
        public string Gender { get; set; }
        public object CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public object HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string CountryIso { get; set; }
        public object Original { get; set; }
    }

    public class Extradata
    {
        public string ExtraData { get; set; }
    }

    public class Line
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string MerchantProductNo { get; set; }
        public string Gtin { get; set; }
        public float UnitVat { get; set; }
        public float LineTotalInclVat { get; set; }
        public float LineVat { get; set; }
        public float OriginalUnitPriceInclVat { get; set; }
        public float OriginalUnitVat { get; set; }
        public float OriginalLineTotalInclVat { get; set; }
        public float OriginalLineVat { get; set; }
        public object BundleProductMerchantProductNo { get; set; }
        public object[] ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public float UnitPriceInclVat { get; set; }
        public float FeeFixed { get; set; }
        public float FeeRate { get; set; }
        public string Condition { get; set; }
    }
}
