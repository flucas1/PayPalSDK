using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Billing;

/// <summary>
/// Represents the frequency of a billing cycle in the PayPal SDK.
/// </summary>
[DataContract]
public class BillingFrequency
{
    /// <summary>
    /// Gets or sets the unit of the interval for the billing frequency.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the unit of time (e.g., day, week, month) for the interval.
    /// </remarks>
    [JsonPropertyName("interval_unit")]
    [StringLength(24)]
    public required string IntervalUnit { get; set; }

    /// <summary>
    /// Gets or sets the count of intervals for the billing frequency.
    /// </summary>
    /// <remarks>
    /// This field is optional and defaults to 1. It represents the number of intervals for the frequency.
    /// </remarks>
    [JsonPropertyName("interval_count")]
    public int IntervalCount { get; set; } = 1;
}