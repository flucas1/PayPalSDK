using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a card used in transactions within the PayPal SDK.
/// </summary>
public class Card
{
    /// <summary>
    /// Gets or sets the name associated with the card.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(300)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the card number.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 19 characters.
    /// </remarks>
    [JsonPropertyName("number")]
    [StringLength(19)]
    public required string Number { get; set; }

    /// <summary>
    /// Gets or sets the expiry date of the card.
    /// </summary>
    /// <remarks>
    /// This field is required and must match the format YYYY-MM, where YYYY is the year and MM is the month.
    /// </remarks>
    [JsonPropertyName("expiry")]
    [StringLength(7)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])$")]
    public required string Expiry { get; set; }

    /// <summary>
    /// Gets or sets the type of the card.
    /// </summary>
    /// <remarks>
    /// This field is optional and must match the regular expression pattern: ^[A-Z_]+$.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.CardType"/> for valid card types.
    /// </remarks>
    [JsonPropertyName("type")]
    [StringLength(255)]
    [RegularExpression("^[A-Z_]+$")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the brand of the card.
    /// </summary>
    /// <remarks>
    /// This field is optional and must match the regular expression pattern: ^[A-Z_]+$.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.CardNetwork"/> for valid card brands.
    /// </remarks>
    [JsonPropertyName("brand")]
    [StringLength(255)]
    [RegularExpression("^[A-Z_]+$")]
    public string? Brand { get; set; }

    /// <summary>
    /// Gets or sets the billing address associated with the card.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the billing address details.
    /// </remarks>
    [JsonPropertyName("billing_address")]
    public Address? BillingAddress { get; set; }
}