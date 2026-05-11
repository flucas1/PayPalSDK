using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;

/// <summary>
/// Represents a network token object in the PayPal SDK.
/// </summary>
[DataContract]
public class NetworkToken
{
    /// <summary>
    /// Gets or sets the network token number.
    /// </summary>
    /// <remarks>
    /// This field is required, has a maximum length of 19 characters, and represents the tokenized card number.
    /// </remarks>
    [JsonPropertyName("number")]
    [StringLength(19)]
    public required string Number { get; set; }

    /// <summary>
    /// Gets or sets the cryptogram associated with the network token.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 32 characters, and represents the cryptographic value for the token.
    /// </remarks>
    [JsonPropertyName("cryptogram")]
    [StringLength(32)]
    public string? Cryptogram { get; set; }

    /// <summary>
    /// Gets or sets the token requestor ID.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 11 characters, and identifies the entity requesting the token.
    /// </remarks>
    [JsonPropertyName("token_requestor_id")]
    [StringLength(11)]
    public string? TokenRequestorId { get; set; }

    /// <summary>
    /// Gets or sets the expiry date of the network token.
    /// </summary>
    /// <remarks>
    /// This field is required, has a maximum length of 7 characters, and must match the format YYYY-MM (e.g., 2023-12).
    /// </remarks>
    [JsonPropertyName("expiry")]
    [StringLength(7)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])$")]
    public required string Expiry { get; set; }

    /// <summary>
    /// Gets or sets the Electronic Commerce Indicator (ECI) flag.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 255 characters, and must match the regular expression ^[0-9A-Z_]+$.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.EciFlags"/> for possible values.
    /// </remarks>
    [JsonPropertyName("eci_flag")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? EciFlag { get; set; }
}