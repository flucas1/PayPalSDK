using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.PayPal;

/// <summary>
/// Represents stored credentials used in card payments within the PayPal SDK.
/// </summary>
[DataContract]
public class PayPalStoredCredentials
{
    /// <summary>
    /// Gets or sets the payment initiator.
    /// Possible values are defined in <see cref="Tavstal.PayPalSDK.Constants.PaymentInitators"/>.
    /// </summary>
    [JsonPropertyName("payment_initiator")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public required string PaymentInitiator { get; set; }

    /// <summary>
    /// Gets or sets the charge pattern for the stored credentials.
    /// </summary>
    [JsonPropertyName("charge_pattern")]
    [StringLength(30)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public required string ChargePattern { get; set; }

    /// <summary>
    /// Gets or sets the usage pattern for the stored credentials.
    /// </summary>
    [StringLength(30)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? UsagePattern { get; set; }

    /// <summary>
    /// Gets or sets the usage of the credential.
    /// Possible values are defined in <see cref="Tavstal.PayPalSDK.Constants.CredentialUsage"/>.
    /// </summary>
    [JsonPropertyName("usage")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Usage { get; set; }
}