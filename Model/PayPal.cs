using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace blazor_paypal.Model
{
    public class SubscriptionData
    {
        [JsonPropertyName("orderID")]
        public string OrderID { get; set; }

        [JsonPropertyName("subscriptionID")]
        public string SubscriptionID { get; set; }

        [JsonPropertyName("facilitatorAccessToken")]
        public string FacilitatorAccessToken { get; set; }
    }
    
    public class PayPal
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("intent")]
        public string Intent { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("purchase_units")]
        public List<PurchaseUnit> PurchaseUnits { get; set; }

        [JsonPropertyName("payer")]
        public Payer Payer { get; set; }

        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonPropertyName("links")]
        public List<Link> Links { get; set; }
    }

    public class Amount
    {
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Payee
    {
        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonPropertyName("address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonPropertyName("admin_area_2")]
        public string AdminArea2 { get; set; }

        [JsonPropertyName("admin_area_1")]
        public string AdminArea1 { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
    }

    public class Shipping
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class SellerProtection
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("dispute_categories")]
        public List<string> DisputeCategories { get; set; }
    }

    public class Capture
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [JsonPropertyName("final_capture")]
        public bool FinalCapture { get; set; }

        [JsonPropertyName("seller_protection")]
        public SellerProtection SellerProtection { get; set; }

        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }
    }

    public class Payments
    {
        [JsonPropertyName("captures")]
        public List<Capture> Captures { get; set; }
    }

    public class PurchaseUnit
    {
        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [JsonPropertyName("payee")]
        public Payee Payee { get; set; }

        [JsonPropertyName("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonPropertyName("shipping")]
        public Shipping Shipping { get; set; }

        [JsonPropertyName("payments")]
        public Payments Payments { get; set; }
    }

    public class Payer
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("payer_id")]
        public string PayerId { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("rel")]
        public string Rel { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }
    }
}