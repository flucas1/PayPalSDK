using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.GooglePay;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources;

/// <summary>
/// Represents a Google Pay payment source within the PayPal SDK.
/// </summary>
[DataContract]
public class GooglePaySource
{
    /// <summary>
    /// Gets or sets the name associated with the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(300)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 254 characters.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the phone number associated with the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the phone number details.
    /// </remarks>
    [JsonPropertyName("phone_number")]
    public PhoneNumber? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the card details associated with the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the card used in the transaction.
    /// </remarks>
    [JsonPropertyName("card")]
    public required Models.Common.Card Card { get; set; }

    /// <summary>
    /// Gets or sets the decrypted token associated with the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the decrypted token details.
    /// </remarks>
    [JsonPropertyName("decrypted_token")]
    public GoogleDecryptedToken? DecryptedToken { get; set; }

    /// <summary>
    /// Gets or sets the assurance details associated with the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and provides additional assurance information.
    /// </remarks>
    [JsonPropertyName("assurance_details")]
    public AssuranceDetails? AssuranceDetails { get; set; }

    /// <summary>
    /// Gets or sets the experience context for configuring the Google Pay payment experience.
    /// </summary>
    /// <remarks>
    /// This field is optional and provides additional configuration for the payment experience.
    /// </remarks>
    [JsonPropertyName("experience_context")]
    public ExperienceContext? ExperienceContext { get; set; }
}