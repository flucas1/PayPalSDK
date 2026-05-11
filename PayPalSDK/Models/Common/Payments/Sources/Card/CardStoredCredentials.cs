using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;

/// <summary>
/// Represents stored credentials used in card payments within the PayPal SDK.
/// </summary>
[DataContract]
public class CardStoredCredentials
{
    /// <summary>
    /// Gets or sets the payment initiator.
    /// <br/>Possible values are defined in <see cref="Tavstal.PayPalSDK.Constants.PaymentInitators"/>.
    /// </summary>
    [JsonPropertyName("payment_initiator")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public required string PaymentInitiator { get; set; }

    /// <summary>
    /// Gets or sets the type of payment.
    /// <br/>Possible values are defined in <see cref="Tavstal.PayPalSDK.Constants.PaymentType"/>.
    /// </summary>
    [JsonPropertyName("payment_type")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public required string PaymentType { get; set; }

    /// <summary>
    /// Gets or sets the usage of the credential.
    /// <br/>Possible values are defined in <see cref="Tavstal.PayPalSDK.Constants.CredentialUsage"/>.
    /// </summary>
    [JsonPropertyName("usage")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? Usage { get; set; }

    /// <summary>
    /// Gets or sets the reference to the previous network transaction.
    /// </summary>
    [JsonPropertyName("previous_network_transaction_reference")]
    public NetworkTransactionReference? PrevNetworkTransactionReference { get; set; }
}