using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.Addressing;

/// <summary>
/// Represents shipping information for a transaction.
/// </summary>
[DataContract]
public class ShippingInfo
{
    /// <summary>
    /// Gets or sets the business name associated with the shipping information.
    /// </summary>
    /// <remarks>
    /// The business name must not exceed 300 characters.
    /// </remarks>
    [JsonPropertyName("business_name")]
    [StringLength(300)]
    public string BusinessName { get; set; }

    /// <summary>
    /// Gets or sets the name information of the recipient.
    /// </summary>
    [JsonPropertyName("name")]
    public NameInfo Name { get; set; }

    /// <summary>
    /// Gets or sets the address information for shipping.
    /// </summary>
    [JsonPropertyName("address")]
    public Address Address { get; set; }
}