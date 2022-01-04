using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace blazor_paypal.Data
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class ShippingAmount
    {
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Name
    {
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

    public class ShippingAddress
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class Subscriber
    {
        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("payer_id")]
        public string PayerId { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }
    }

    public class OutstandingBalance
    {
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class CycleExecution
    {
        [JsonPropertyName("tenure_type")]
        public string TenureType { get; set; }

        [JsonPropertyName("sequence")]
        public int Sequence { get; set; }

        [JsonPropertyName("cycles_completed")]
        public int CyclesCompleted { get; set; }

        [JsonPropertyName("cycles_remaining")]
        public int CyclesRemaining { get; set; }

        [JsonPropertyName("current_pricing_scheme_version")]
        public int CurrentPricingSchemeVersion { get; set; }

        [JsonPropertyName("total_cycles")]
        public int TotalCycles { get; set; }
    }

    public class Amount
    {
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class LastPayment
    {
        [JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }

    public class BillingInfo
    {
        [JsonPropertyName("outstanding_balance")]
        public OutstandingBalance OutstandingBalance { get; set; }

        [JsonPropertyName("cycle_executions")]
        public List<CycleExecution> CycleExecutions { get; set; }

        [JsonPropertyName("last_payment")]
        public LastPayment LastPayment { get; set; }

        [JsonPropertyName("next_billing_time")]
        public DateTime NextBillingTime { get; set; }

        [JsonPropertyName("final_payment_time")]
        public DateTime FinalPaymentTime { get; set; }

        [JsonPropertyName("failed_payments_count")]
        public int FailedPaymentsCount { get; set; }
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

    public class RootSubscriber
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("status_update_time")]
        public DateTime StatusUpdateTime { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("plan_id")]
        public string PlanId { get; set; }

        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        [JsonPropertyName("shipping_amount")]
        public ShippingAmount ShippingAmount { get; set; }

        [JsonPropertyName("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonPropertyName("billing_info")]
        public BillingInfo BillingInfo { get; set; }

        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonPropertyName("plan_overridden")]
        public bool PlanOverridden { get; set; }

        [JsonPropertyName("links")]
        public List<Link> Links { get; set; }
    }


}