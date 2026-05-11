using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.GooglePay;

/// <summary>
/// Represents a decrypted token for Google Pay payment sources within the PayPal SDK.
/// </summary>
[DataContract]
public class GoogleDecryptedToken
{
    /// <summary>
    /// Gets or sets the unique identifier for the message.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 250 characters.
    /// </remarks>
    [JsonPropertyName("message_id")]
    [StringLength(250)]
    public string? MessageId { get; set; }

    /// <summary>
    /// Gets or sets the expiration timestamp of the message.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 13 characters.
    /// </remarks>
    [JsonPropertyName("message_expiration")]
    [StringLength(13)]
    public string? MessageExpiration { get; set; }

    /// <summary>
    /// Gets or sets the payment method used in the transaction.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 4 characters.
    /// </remarks>
    [JsonPropertyName("payment_method")]
    [StringLength(4)]
    public required string PaymentMethod { get; set; }

    /// <summary>
    /// Gets or sets the authentication method used for the transaction.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 50 characters.
    /// </remarks>
    [JsonPropertyName("authentication_method")]
    [StringLength(50)]
    public required string AuthenticationMethod { get; set; }

    /// <summary>
    /// Gets or sets the cryptogram associated with the transaction.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 2000 characters.
    /// </remarks>
    [JsonPropertyName("cryptogram")]
    [StringLength(2000)]
    public string? Cryptogram { get; set; }

    /// <summary>
    /// Gets or sets the ECI (Electronic Commerce Indicator) value for the transaction.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 256 characters.
    /// </remarks>
    [JsonPropertyName("eci_indicator")]
    [StringLength(256)]
    public string? EciIndicator { get; set; }

    /// <summary>
    /// Gets or sets the card details associated with the transaction.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the card used in the transaction.
    /// </remarks>
    [JsonPropertyName("card")]
    public required Models.Common.Card Card { get; set; }
}