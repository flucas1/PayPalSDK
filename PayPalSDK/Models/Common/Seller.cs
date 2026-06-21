using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a seller or merchant entity involved in a PayPal transaction.
/// </summary>
[DataContract]
public class Seller
{
    /// <summary>
    /// Gets or sets the unique merchant identifier for the seller.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    [StringLength(255)]
    public string? MerchantId { get; set; }
    
    /// <summary>
    /// Gets or sets the display name of the seller.
    /// </summary>
    [JsonPropertyName("name")]
    [StringLength(2000)]
    public string? Name { get; set; }
    
    /// <summary>
    /// Gets or sets the email address of the seller.
    /// </summary>
    [JsonPropertyName("email")]
    [StringLength(254, MinimumLength = 3)]
    [RegularExpression("^(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$")]
    public string? Email { get; set; }
}