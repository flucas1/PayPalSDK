using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents the payment preferences for a plan in the PayPal SDK.
/// </summary>
[DataContract]
public class PlanPaymentPreference
{
    /// <summary>
    /// Gets or sets a value indicating whether to automatically bill outstanding amounts.
    /// </summary>
    /// <remarks>
    /// This field is required and determines if outstanding amounts are automatically billed.
    /// </remarks>
    [JsonPropertyName("auto_bill_outstanding")]
    public bool AutoBillOutstanding { get; set; }

    /// <summary>
    /// Gets or sets the action to take when the setup fee fails.
    /// </summary>
    /// <remarks>
    /// This field is required and specifies the action to take in case of setup fee failure.
    /// </remarks>
    [JsonPropertyName("setup_fee_failure_action")]
    [StringLength(24)]
    public string SetupFeeFailureAction { get; set; }

    /// <summary>
    /// Gets or sets the threshold for payment failures.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the number of payment failures allowed before action is taken.
    /// </remarks>
    [JsonPropertyName("payment_failure_threshold")]
    public int PaymentFailureThreshold { get; set; }

    /// <summary>
    /// Gets or sets the setup fee for the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of the setup fee.
    /// </remarks>
    [JsonPropertyName("setup_fee")]
    public Money SetupFee { get; set; }
}