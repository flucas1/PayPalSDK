using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Billing;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents the pricing scheme for a subscription plan.
/// </summary>
[DataContract]
public class PlanPricingScheme
{
    /// <summary>
    /// Gets or sets the sequence number of the billing cycle associated with the pricing scheme.
    /// </summary>
    [JsonPropertyName("billing_cycle_sequence")]
    public required int BillingCycleSequence { get; set; }

    /// <summary>
    /// Gets or sets the pricing scheme details for the subscription plan.
    /// </summary>
    [JsonPropertyName("pricing_scheme")]
    public required PricingScheme PricingScheme { get; set; }
}