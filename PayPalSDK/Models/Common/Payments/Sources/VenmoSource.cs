using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.Common;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources;

/// <summary>
/// Represents a Venmo payment source within the PayPal SDK.
/// </summary>
[DataContract]
public class VenmoSource
{
    /// <summary>
    /// Gets or sets the vault ID associated with the Venmo payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and must match the regular expression pattern: ^[0-9a-zA-Z_-]+$.
    /// </remarks>
    [JsonPropertyName("vault_id")]
    [StringLength(255)]
    [RegularExpression("^[0-9a-zA-Z_-]+$")]
    public string? VaultId { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the Venmo payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a valid email address format with a maximum length of 254 characters.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the experience context for configuring the Venmo payment experience.
    /// </summary>
    /// <remarks>
    /// This field is optional and provides additional configuration for the payment experience.
    /// </remarks>
    [JsonPropertyName("experience_context")]
    public ExperienceContext? ExperienceContext { get; set; }

    /// <summary>
    /// Gets or sets the attributes associated with the Venmo payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents additional metadata for the payment source.
    /// </remarks>
    [JsonPropertyName("attributes")]
    public SourceAttributes? Attributes { get; set; }
}