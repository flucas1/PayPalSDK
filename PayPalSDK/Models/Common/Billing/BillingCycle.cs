using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Plans;

namespace Tavstal.PayPalSDK.Models.Common.Billing;

/// <summary>
/// Represents a billing cycle in the PayPal SDK.
/// </summary>
[DataContract]
public class BillingCycle
{
    /// <summary>
    /// Gets or sets the tenure type of the billing cycle.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the type of tenure for the billing cycle.
    /// </remarks>
    [JsonPropertyName("tenure_type")]
    public required string TenureType { get; set; }

    /// <summary>
    /// Gets or sets the total number of cycles in the billing cycle.
    /// </summary>
    /// <remarks>
    /// This field is optional and defaults to 1.
    /// </remarks>
    [JsonPropertyName("total_cycles")]
    public int TotalCycles { get; set; } = 1;

    /// <summary>
    /// Gets or sets the sequence number of the billing cycle.
    /// </summary>
    /// <remarks>
    /// This field is optional and defaults to 1.
    /// </remarks>
    [JsonPropertyName("sequence")]
    public required int Sequence { get; set; } = 1;

    /// <summary>
    /// Gets or sets the pricing scheme associated with the billing cycle.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the pricing details for the billing cycle.
    /// </remarks>
    [JsonPropertyName("pricing_scheme")]
    public PlanPricingSchemeData? PricingScheme { get; set; }

    /// <summary>
    /// Gets or sets the start date of the billing cycle.
    /// </summary>
    /// <remarks>
    /// This field is optional and must follow the format YYYY-MM-DD.
    /// </remarks>
    [JsonPropertyName("start_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? StartDate { get; set; }
    
    /// <summary>
    /// Gets or sets the frequency of the billing cycle.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the frequency details for the billing cycle.
    /// </remarks>
    [JsonPropertyName("frequency")]
    public required BillingFrequency Frequency { get; set; }
}