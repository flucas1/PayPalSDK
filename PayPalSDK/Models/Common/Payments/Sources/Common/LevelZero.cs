using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.Common;

/// <summary>
/// Represents a Level Zero payment source within the PayPal SDK.
/// </summary>
[DataContract]
public class LevelZero
{
    /// <summary>
    /// Gets or sets the authorization code for the payment source.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 6 characters.
    /// </remarks>
    [JsonPropertyName("auth_code")]
    [StringLength(6)]
    public required string AuthCode { get; set; }
}