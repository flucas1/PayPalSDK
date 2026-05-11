using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Billing;

/// <summary>
/// Represents a billing plan in the PayPal SDK.
/// </summary>
[DataContract]
public class BillingPlan
{
    /// <summary>
    /// Gets or sets the billing cycles associated with the billing plan.
    /// </summary>
    /// <remarks>
    /// This field is required and contains a list of billing cycles.
    /// </remarks>
    [JsonPropertyName("billing_cycles")]
    public required List<BillingCycle> BillingCycles { get; set; }

    /// <summary>
    /// Gets or sets the name of the billing plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(127)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the setup fee for the billing plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of the setup fee.
    /// </remarks>
    [JsonPropertyName("setup_fee")]
    public Money? SetupFee { get; set; }
}