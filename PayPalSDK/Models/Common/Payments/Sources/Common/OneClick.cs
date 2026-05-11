using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.Common;

/// <summary>
/// Represents a OneClick payment source within the PayPal SDK.
/// </summary>
[DataContract]
public class OneClick
{
    /// <summary>
    /// Gets or sets the authorization code for the payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 6 characters.
    /// </remarks>
    [JsonPropertyName("auth_code")]
    [StringLength(6)]
    public string? AuthCode { get; set; }

    /// <summary>
    /// Gets or sets the consumer reference associated with the payment source.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 64 characters.
    /// </remarks>
    [JsonPropertyName("consumer_reference")]
    [StringLength(64)]
    public required string ConsumerReference { get; set; }

    /// <summary>
    /// Gets or sets the alias label for the payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 35 characters.
    /// </remarks>
    [JsonPropertyName("alias_label")]
    [StringLength(35)]
    public string? AliasLabel { get; set; }

    /// <summary>
    /// Gets or sets the alias key for the payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 19 characters.
    /// </remarks>
    [JsonPropertyName("alias_key")]
    [StringLength(19)]
    public string? AliasKey { get; set; }
}