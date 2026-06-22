using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.ApplePay;

/// <summary>
/// Represents payment data for Apple Pay transactions within the PayPal SDK.
/// </summary>
[DataContract]
public class PaymentData
{
    /// <summary>
    /// Gets or sets the cryptogram associated with the Apple Pay payment data.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 2000 characters.
    /// </remarks>
    [JsonPropertyName("cryptogram")]
    [StringLength(2000)]
    public string? Cryptogram { get; set; }

    /// <summary>
    /// Gets or sets the ECI (Electronic Commerce Indicator) associated with the Apple Pay payment data.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 256 characters.
    /// </remarks>
    [JsonPropertyName("eci_indicator")]
    [StringLength(256)]
    public string? EciIndicator { get; set; }

    /// <summary>
    /// Gets or sets the EMV (Europay, Mastercard, and Visa) data associated with the Apple Pay payment data.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 2000 characters.
    /// </remarks>
    [JsonPropertyName("emv_data")]
    [StringLength(2000)]
    public string? EmvData { get; set; }

    /// <summary>
    /// Gets or sets the PIN associated with the Apple Pay payment data.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 2000 characters.
    /// </remarks>
    [JsonPropertyName("pin")]
    [StringLength(2000)]
    public string? Pin { get; set; }
}