using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Utils;

namespace Tavstal.PayPalSDK.Models.Common.Disputes;

/// <summary>
/// Represents an adjudication event recorded during a dispute lifecycle.
/// </summary>
[DataContract]
public class DisputeAdjudication
{
    /// <summary>
    /// Gets or sets the adjudication type code.
    /// </summary>
    [JsonPropertyName("type")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public required string Type { get; set; }
    
    /// <summary>
    /// Gets or sets the adjudication timestamp in ISO 8601 / RFC 3339 format.
    /// </summary>
    [JsonPropertyName("adjudication_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public required string AdjudicationTime { get; set; }
    
    /// <summary>
    /// Gets or sets the reason code associated with this adjudication.
    /// </summary>
    [JsonPropertyName("reason")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Reason { get; set; }
    
    /// <summary>
    /// Gets or sets the dispute lifecycle stage at the time of adjudication.
    /// </summary>
    [JsonPropertyName("dispute_life_cycle_stage")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? DisputeLifeCycleStage { get; set; }
    
    /// <summary>
    /// Gets the <see cref="AdjudicationTime"/> value parsed as a <see cref="DateTime"/>, if valid.
    /// </summary>
    public DateTime? AdjucationTimeAsDateTime => DateTimeHelper.FromISO8601(AdjudicationTime);
}