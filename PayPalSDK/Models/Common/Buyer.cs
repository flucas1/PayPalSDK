using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a buyer entity involved in a PayPal transaction.
/// </summary>
[DataContract]
public class Buyer
{
    /// <summary>
    /// Gets or sets the display name of the buyer.
    /// </summary>
    [JsonPropertyName("name")]
    [StringLength(2000)]
    public string? Name { get; set; }
}