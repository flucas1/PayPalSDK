using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Utils;

namespace Tavstal.PayPalSDK.Models.Tracking.Bodies;


/// <summary>
/// Represents shipment tracking information associated with a PayPal transaction,
/// including carrier details, tracking identifiers, shipment metadata, and status.
/// </summary>
[DataContract]
public class Tracker
{
    /// <summary>
    /// Gets or sets the transaction identifier associated with this tracker.
    /// </summary>
    [JsonPropertyName("transaction_id")]
    [StringLength(50)]
    public string? TransactionId { get; set; }
   
    /// <summary>
    /// Gets or sets the shipment tracking number provided by the carrier.
    /// </summary>
    [JsonPropertyName("tracking_number")]
    [StringLength(64)]
    public string? TrackingNumber { get; set; }
    
    /// <summary>
    /// Gets or sets a custom carrier name when the carrier is not covered by predefined values.
    /// </summary>
    [JsonPropertyName("carrier_name_other")]
    [StringLength(64)]
    public string? CarrierNameOther { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether the buyer should be notified about tracking updates.
    /// </summary>
    [JsonPropertyName("notify_buyer")]
    public bool NotifyBuyer { get; set; }
    
    /// <summary>
    /// Gets or sets the shipment direction (for example, outbound or return).
    /// </summary>
    [JsonPropertyName("shipment_direction")]
    [StringLength(50)]
    public string? ShipmentDirection { get; set; }
    
    /// <summary>
    /// Gets or sets the URL where tracking details can be viewed.
    /// </summary>
    [JsonPropertyName("tracking_url")]
    [StringLength(250)]
    [RegularExpression("^.*$")]
    public string? TrackingUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the fulfillment provider handling the shipment.
    /// </summary>
    [JsonPropertyName("fulfillment_provider")]
    [StringLength(64)]
    public string? FulfillmentProvider { get; set; }
    
    /// <summary>
    /// Gets or sets the tracking number type.
    /// </summary>
    [JsonPropertyName("tracking_number_type")]
    [StringLength(64)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? TrackingNumberType { get; set; }
    
    /// <summary>
    /// Gets or sets the current tracking status.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(64)]
    [RegularExpression("^[A-Z_]+$")]
    public string? Status { get; set; }
    
    /// <summary>
    /// Gets or sets the shipment date in <c>yyyy-MM-dd</c> format.
    /// </summary>
    [JsonPropertyName("shipment_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? ShipmentDate { get; set; }
    
    /// <summary>
    /// Gets or sets the carrier identifier or name.
    /// </summary>
    [JsonPropertyName("carrier")]
    [StringLength(64)]
    [RegularExpression("^.*$")]
    public string? Carrier { get; set; }
    
    /// <summary>
    /// Gets or sets the last tracking update time as an ISO 8601 string.
    /// </summary>
    [JsonPropertyName("last_update_time")]
    [StringLength(maximumLength:64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? LastUpdateTime { get; set; }
    
    /// <summary>
    /// Gets the parsed <see cref="DateTime"/> representation of <see cref="LastUpdateTime"/>, if valid.
    /// </summary>
    public DateTime? LastUpdateTimeAsDateTime => DateTimeHelper.FromISO8601(LastUpdateTime);
}