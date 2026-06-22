using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.ApplePay;

/// <summary>
/// Represents a decrypted token used in Apple Pay transactions within the PayPal SDK.
/// </summary>
[DataContract]
public class AppleDecryptedToken
{
    /// <summary>
    /// Gets or sets the device manufacturer ID associated with the decrypted token.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 2000 characters.
    /// </remarks>
    [JsonPropertyName("device_manufacturer_id")]
    [StringLength(2000)]
    public string? DeviceManufacturerId { get; set; }

    /// <summary>
    /// Gets or sets the type of payment data associated with the decrypted token.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 16 characters.
    /// </remarks>
    [JsonPropertyName("payment_data_type")]
    [StringLength(16)]
    public string? PaymentDataType { get; set; }

    /// <summary>
    /// Gets or sets the transaction amount associated with the decrypted token.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of the transaction.
    /// </remarks>
    [JsonPropertyName("transaction_amount")]
    public Money? TransactionAmount { get; set; }

    /// <summary>
    /// Gets or sets the tokenized card associated with the decrypted token.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the card details used in the transaction.
    /// </remarks>
    [JsonPropertyName("tokenized_card")]
    public required TokenizedCard TokenizedCard { get; set; }

    /// <summary>
    /// Gets or sets the payment data associated with the decrypted token.
    /// </summary>
    /// <remarks>
    /// This field is optional and contains additional payment-related information.
    /// </remarks>
    [JsonPropertyName("payment_data")]
    public PaymentData? PaymentData { get; set; }
}