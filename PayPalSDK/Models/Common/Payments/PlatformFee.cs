using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents a platform fee in the PayPal SDK.
/// </summary>
[DataContract]
public class PlatformFee
{
    /// <summary>
    /// Gets or sets the payee associated with the platform fee.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the recipient of the platform fee.
    /// </remarks>
    [JsonPropertyName("payee")]
    public Payee? Payee { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount of the platform fee.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the amount to be charged as a platform fee.
    /// </remarks>
    [JsonPropertyName("amount")]
    public required Money Amount { get; set; }
}