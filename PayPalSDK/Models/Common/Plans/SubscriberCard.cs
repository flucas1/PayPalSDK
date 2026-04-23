using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents a subscriber's card information used for billing purposes.
/// </summary>
[DataContract]
public class SubscriberCard
{
    /// <summary>
    /// Gets or sets the name on the card.
    /// </summary>
    /// <remarks>
    /// The name can have a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(300)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the card number.
    /// </summary>
    /// <remarks>
    /// The card number is required and can have a maximum length of 19 characters.
    /// </remarks>
    [JsonPropertyName("number")]
    [StringLength(19)]
    public required string Number { get; set; }

    /// <summary>
    /// Gets or sets the security code of the card.
    /// </summary>
    [JsonPropertyName("security_code")]
    public string SecurityCode { get; set; }

    /// <summary>
    /// Gets or sets the expiry date of the card.
    /// </summary>
    /// <remarks>
    /// The expiry date is required and must follow the format "YYYY-MM" (e.g., 2023-09).
    /// </remarks>
    [JsonPropertyName("expiry")]
    [StringLength(7)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])$")]
    public required string Expiry { get; set; }

    /// <summary>
    /// Gets or sets the billing address associated with the card.
    /// </summary>
    [JsonPropertyName("billing_address")]
    public Address BillingAddress { get; set; }
}