using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.ApplePay;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.Common;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources;

/// <summary>
/// Represents an Apple Pay payment source within the PayPal SDK.
/// </summary>
[DataContract]
public class ApplePaySource
{
    /// <summary>
    /// Gets or sets the unique identifier for the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 250 characters.
    /// </remarks>
    [JsonPropertyName("id")]
    [StringLength(250)]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the stored credentials associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents card-related stored credentials.
    /// </remarks>
    [JsonPropertyName("stored_credential")]
    public CardStoredCredentials? StoredCredential { get; set; }

    /// <summary>
    /// Gets or sets the attributes associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents additional metadata for the payment source.
    /// </remarks>
    [JsonPropertyName("attributes")]
    public SourceAttributes? Attributes { get; set; }

    /// <summary>
    /// Gets or sets the name associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(300)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a valid email address format with a maximum length of 254 characters.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("^(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the phone number associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the phone number details.
    /// </remarks>
    [JsonPropertyName("phone_number")]
    public PhoneNumber? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the decrypted token associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the decrypted token details.
    /// </remarks>
    [JsonPropertyName("decrypted_token")]
    public AppleDecryptedToken? DecryptedToken { get; set; }

    /// <summary>
    /// Gets or sets the vault ID associated with the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and must match the regular expression pattern: ^[0-9a-zA-Z_-]+$.
    /// </remarks>
    [JsonPropertyName("vault_id")]
    [StringLength(255)]
    [RegularExpression("^[0-9a-zA-Z_-]+$")]
    public string? VaultId { get; set; }

    /// <summary>
    /// Gets or sets the experience context for configuring the Apple Pay payment experience.
    /// </summary>
    /// <remarks>
    /// This field is optional and provides additional configuration for the payment experience.
    /// </remarks>
    [JsonPropertyName("experience_context")]
    public ExperienceContext? ExperienceContext { get; set; }
}