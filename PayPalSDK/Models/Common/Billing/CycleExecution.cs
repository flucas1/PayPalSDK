using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Billing;

/// <summary>
/// Represents the execution details of a billing cycle.
/// </summary>
[DataContract]
public class CycleExecution
{
    /// <summary>
    /// Gets or sets the type of tenure for the billing cycle.
    /// </summary>
    /// <remarks>
    /// The tenure type must match one of the values defined in <see cref="Tavstal.PayPalSDK.Constants.TenureType"/>.
    /// </remarks>
    [JsonPropertyName("tenure_type")]
    [StringLength(24)]
    public required string TenureType { get; set; }

    /// <summary>
    /// Gets or sets the sequence number of the billing cycle.
    /// </summary>
    [JsonPropertyName("sequence")]
    public required int Sequence { get; set; }

    /// <summary>
    /// Gets or sets the number of cycles that have been completed.
    /// </summary>
    [JsonPropertyName("cycles_completed")]
    public required int CyclesCompleted { get; set; }

    /// <summary>
    /// Gets or sets the number of cycles remaining in the billing cycle.
    /// </summary>
    [JsonPropertyName("cycles_remaining")]
    public int CyclesRemaining { get; set; }

    /// <summary>
    /// Gets or sets the version of the current pricing scheme applied to the billing cycle.
    /// </summary>
    [JsonPropertyName("current_pricing_scheme_version")]
    public int CurrentPricingSchemeVersion { get; set; }

    /// <summary>
    /// Gets or sets the total number of cycles in the billing cycle.
    /// </summary>
    [JsonPropertyName("total_cycles")]
    public int TotalCycles { get; set; }
}