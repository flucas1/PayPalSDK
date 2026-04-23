using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents a transaction associated with a PayPal invoice, including payment details, type, method, and shipping information.
/// </summary>
[DataContract]
public class InvoiceTransaction
{
    /// <summary>
    /// Gets or sets the unique identifier for the payment associated with the transaction.
    /// </summary>
    /// <remarks>
    /// The payment ID must not exceed 22 characters.
    /// </remarks>
    [JsonPropertyName("payment_id")]
    [StringLength(22)]
    public string PaymentId { get; set; }

    /// <summary>
    /// Gets or sets the note associated with the transaction.
    /// </summary>
    /// <remarks>
    /// The note must not exceed 2000 characters.
    /// </remarks>
    [JsonPropertyName("note")]
    [StringLength(2000)]
    public string Note { get; set; }

    /// <summary>
    /// Gets or sets the type of the transaction.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the payment date for the transaction.
    /// </summary>
    /// <remarks>
    /// The date must follow the format YYYY-MM-DD.
    /// </remarks>
    [JsonPropertyName("payment_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string PaymentDate { get; set; }

    /// <summary>
    /// Gets or sets the transaction method used for the payment.
    /// </summary>
    /// <remarks>
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.TransactionMethod"/> for valid values.
    /// </remarks>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// Gets or sets the amount associated with the transaction.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }

    /// <summary>
    /// Gets or sets the shipping information associated with the transaction.
    /// </summary>
    [JsonPropertyName("shipping_info")]
    public ShippingInfo ShippingInfo { get; set; }
}