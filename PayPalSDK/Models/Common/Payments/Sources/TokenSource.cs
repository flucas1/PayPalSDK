using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources;

/// <summary>
/// Represents a token-based payment source in the PayPal SDK.
/// </summary>
[DataContract]
public class TokenSource
{
    /// <summary>
    /// Gets or sets the unique identifier for the token source.
    /// </summary>
    [JsonPropertyName("id")]
    [StringLength(255)]
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the token source.
    /// </summary>
    [JsonPropertyName("type")]
    [StringLength(255)]
    public required string Type { get; set; }
}