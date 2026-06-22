using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Disputes;

/// <summary>
/// Represents a dispute summary record returned by the disputes API.
/// </summary>
[DataContract]
public class Dispute
{
    /// <summary>
    /// Gets or sets the unique identifier of the dispute.
    /// </summary>
    [JsonPropertyName("dispute_id")]
    [StringLength(255)]
    public string? DisputeId { get; set; }
    
    /// <summary>
    /// Gets or sets related HATEOAS links for dispute operations.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link>? Links { get; set; }
    
    /// <summary>
    /// Gets or sets the dispute creation timestamp in ISO 8601 / RFC 3339 format.
    /// </summary>
    [JsonPropertyName("create_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? CreateTime { get; set; }
    
    /// <summary>
    /// Gets or sets the last update timestamp in ISO 8601 / RFC 3339 format.
    /// </summary>
    [JsonPropertyName("update_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? UpdateTime { get; set; }
    
    /// <summary>
    /// Gets or sets the dispute reason code.
    /// </summary>
    [JsonPropertyName("reason")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Reason { get; set; }
    
    /// <summary>
    /// Gets or sets the current dispute status code.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Status { get; set; }
    
    /// <summary>
    /// Gets or sets the broader dispute state classification.
    /// </summary>
    [JsonPropertyName("dispute_state")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? DisputeState { get; set; }
    
    /// <summary>
    /// Gets or sets the monetary amount currently in dispute.
    /// </summary>
    [JsonPropertyName("dispute_amount")]
    public Money? DisputeAmount { get; set; }
    
    /// <summary>
    /// Gets or sets asset-level details associated with the disputed amount.
    /// </summary>
    [JsonPropertyName("dispute_asset")]
    public Asset? DisputeAsset { get; set; }
    
    /// <summary>
    /// Gets or sets the dispute lifecycle stage code.
    /// </summary>
    [JsonPropertyName("dispute_life_cycle_stage")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? LifeCycleStage { get; set; }
    
    /// <summary>
    /// Gets or sets the channel through which the dispute was raised.
    /// </summary>
    [JsonPropertyName("dispute_channel")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? DisputeChannel { get; set; }
    
    /// <summary>
    /// Gets or sets the buyer response due date in ISO 8601 / RFC 3339 format.
    /// </summary>
    [JsonPropertyName("buyer_response_due_date")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? BuyerResponseDueDate { get; set; }
    
    /// <summary>
    /// Gets or sets the seller response due date in ISO 8601 / RFC 3339 format.
    /// </summary>
    [JsonPropertyName("seller_response_due_date")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? SellerResponseDueDate { get; set; }
}