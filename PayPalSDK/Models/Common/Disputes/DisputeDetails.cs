using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Disputes.Details;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Disputes;

/// <summary>
/// Represents the full details of a PayPal dispute, including participants,
/// financial data, lifecycle state, evidence, and response options.
/// </summary>
[DataContract]
public class DisputeDetails
{
    /// <summary>
    /// Gets or sets the unique identifier of the dispute.
    /// </summary>
    [JsonPropertyName("dispute_id")]
    [StringLength(255)]
    public string? DisputeId { get; set; }
    
    /// <summary>
    /// Gets or sets the transactions associated with the dispute.
    /// </summary>
    [JsonPropertyName("disputed_transactions")]
    public List<DisputedTransaction>? DisputedTransactions { get; set; }
    
    /// <summary>
    /// Gets or sets an external reason code provided by upstream systems.
    /// </summary>
    [JsonPropertyName("external_reason_code")]
    [StringLength(2000)]
    public string? ExternalReasonCode { get; set; }
    
    /// <summary>
    /// Gets or sets adjudication records created during dispute processing.
    /// </summary>
    [JsonPropertyName("adjudications")]
    public List<DisputeAdjudication>? Adjudications { get; set; }
    
    /// <summary>
    /// Gets or sets fund movement records related to the dispute.
    /// </summary>
    [JsonPropertyName("fund_movements")]
    public List<DisputeFundMovement>? FundMovements { get; set; }
    
    /// <summary>
    /// Gets or sets messages exchanged within the dispute conversation.
    /// </summary>
    [JsonPropertyName("messages")]
    public List<DisputeMessage>? Messages { get; set; }
    
    /// <summary>
    /// Gets or sets evidence submitted for the dispute.
    /// </summary>
    [JsonPropertyName("evidences")]
    public List<Evidence>? Evidences { get; set; }
    
    /// <summary>
    /// Gets or sets additional supporting information attached to the dispute.
    /// </summary>
    [JsonPropertyName("supporting_info")]
    public List<DisputeSupportingInfo>? SupportingInfo { get; set; }
    
    /// <summary>
    /// Gets or sets HATEOAS links related to dispute operations.
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
    /// Gets or sets the most recent update timestamp in ISO 8601 / RFC 3339 format.
    /// </summary>
    [JsonPropertyName("update_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? UpdateTime { get; set; }
    
    /// <summary>
    /// Gets or sets the normalized reason code for the dispute.
    /// </summary>
    [JsonPropertyName("reason")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Reason { get; set; }
    
    /// <summary>
    /// Gets or sets the current status code of the dispute.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Status { get; set; }
    
    /// <summary>
    /// Gets or sets the monetary amount currently in dispute.
    /// </summary>
    [JsonPropertyName("dispute_amount")]
    public Money? DisputeAmount { get; set; }
    
    /// <summary>
    /// Gets or sets asset-level details related to the disputed amount.
    /// </summary>
    [JsonPropertyName("dispute_asset")]
    public Asset? DisputeAsset { get; set; }
    
    // TODO: Add fee_policy, It is an object but I can't find what should be in it.
    /*[JsonPropertyName("fee_policy")]
    public object? FeePolicy { get; set; }*/
    
    /// <summary>
    /// Gets or sets the final or interim dispute outcome information.
    /// </summary>
    [JsonPropertyName("dispute_outcome")]
    public DisputeOutcome? DisputeOutcome { get; set; }
    
    /// <summary>
    /// Gets or sets the dispute lifecycle stage code.
    /// </summary>
    [JsonPropertyName("dispute_life_cycle_stage")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? LifeCycleStage { get; set; }
    
    /// <summary>
    /// Gets or sets the channel through which the dispute was initiated.
    /// </summary>
    [JsonPropertyName("dispute_channel")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Channel { get; set; }
    
    /// <summary>
    /// Gets or sets additional dispute extension data.
    /// </summary>
    [JsonPropertyName("extensions")]
    public DisputeExtensions? Extensions { get; set; }
    
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
    
    /// <summary>
    /// Gets or sets the current offer details in the dispute flow.
    /// </summary>
    [JsonPropertyName("offer")]
    public DisputeOffer? Offer { get; set; }
    
    /// <summary>
    /// Gets or sets refund information associated with the dispute.
    /// </summary>
    [JsonPropertyName("refund_details")]
    public DisputeRefundDetails? RefundDetails { get; set; }
    
    /// <summary>
    /// Gets or sets communication metadata and conversation details for the dispute.
    /// </summary>
    [JsonPropertyName("communication_details")]
    public DisputeCommunicationDetails? CommunicationDetails { get; set; }
    
    /// <summary>
    /// Gets or sets the set of response actions currently available to the caller.
    /// </summary>
    [JsonPropertyName("allowed_response_options")]
    public DisputeAllowedResponseOptions? AllowedResponseOptions { get; set; }
}