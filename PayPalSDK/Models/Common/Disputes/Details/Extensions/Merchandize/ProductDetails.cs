using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Utils;

namespace Tavstal.PayPalSDK.Models.Common.Disputes.Details.Extensions.Merchandize;

/// <summary>
/// Represents the details of a product in a PayPal dispute, including description, product received status, sub-reasons, purchase URL, product received time, expected delivery date, and return details.
/// </summary>
[DataContract]
public class ProductDetails
{
    /// <summary>
    /// Gets or sets the description of the product in the dispute.
    /// </summary>
    [JsonPropertyName("description")]
    [StringLength(2000)]
    public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether the product was received in the dispute.
    /// </summary>
    [JsonPropertyName("product_received")]
    [StringLength(255)]
    public string? ProductReceived { get; set; }
    
    /// <summary>
    /// Gets or sets the sub-reasons associated with the product in the dispute.
    /// </summary>
    [JsonPropertyName("sub_reasons")]
    public List<string>? SubReasons { get; set; }
    
    /// <summary>
    /// Gets or sets the purchase URL of the product in the dispute.
    /// </summary>
    [JsonPropertyName("purchase_url")]
    public string? PurchaseUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the time when the product was received in the dispute, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("product_received_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? ProductReceivedTime { get; set; }
    
    /// <summary>
    /// Gets or sets the expected delivery date of the product in the dispute, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("expected_delivery_date")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? ExpectedDeliveryDate { get; set; }
    
    /// <summary>
    /// Gets or sets the return details associated with the product in the dispute.
    /// </summary>
    [JsonPropertyName("return_details")]
    public ReturnDetails? ReturnDetails { get; set; }
    
    /// <summary>
    /// Gets the time when the product was received as a <see cref="DateTime"/> object, if valid.
    /// </summary>
    public DateTime? ProductReceivedTimeAsDateTime => DateTimeHelper.FromISO8601(ProductReceivedTime);
    
    /// <summary>
    /// Gets the expected delivery date as a <see cref="DateTime"/> object, if valid.
    /// </summary>
    public DateTime? ExpectedDeliveryDateAsDateTime => DateTimeHelper.FromISO8601(ExpectedDeliveryDate);
}