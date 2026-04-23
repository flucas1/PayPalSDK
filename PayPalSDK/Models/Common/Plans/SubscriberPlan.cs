using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Billing;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents a subscription plan for a subscriber.
/// </summary>
[DataContract]
public class SubscriberPlan
{
    /// <summary>
    /// Gets or sets the billing cycles associated with the subscription plan.
    /// </summary>
    /// <remarks>
    /// Each billing cycle defines the frequency and amount for billing the subscriber.
    /// </remarks>
    [JsonPropertyName("billing_cycles")]
    public List<BillingCycle> BillingCycles { get; set; }

    /// <summary>
    /// Gets or sets the payment preferences for the subscription plan.
    /// </summary>
    /// <remarks>
    /// Payment preferences include details such as auto-billing and accepted payment methods.
    /// </remarks>
    [JsonPropertyName("payment_preferences")]
    public PlanPaymentPreference PaymentPreferences { get; set; }

    /// <summary>
    /// Gets or sets the tax information for the subscription plan.
    /// </summary>
    /// <remarks>
    /// Taxes define the applicable tax rates and rules for the subscription plan.
    /// </remarks>
    [JsonPropertyName("taxes")]
    public Taxes Taxes { get; set; }
}