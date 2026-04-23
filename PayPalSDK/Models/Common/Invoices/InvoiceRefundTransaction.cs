using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents a transaction associated with a refund for a PayPal invoice, including refund details, type, date, amount, and method.
/// </summary>
[DataContract]
public class InvoiceRefundTransaction
{
    /// <summary>
    /// Gets or sets the unique identifier for the refund transaction.
    /// </summary>
    /// <remarks>
    /// The refund ID must not exceed 22 characters.
    /// </remarks>
    [JsonPropertyName("refund_id")]
    [StringLength(22)]
    public string RefundId { get; set; }

    /// <summary>
    /// Gets or sets the type of the refund transaction.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the date of the refund transaction.
    /// </summary>
    /// <remarks>
    /// The date must follow the format YYYY-MM-DD.
    /// </remarks>
    [JsonPropertyName("refund_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string RefundDate { get; set; }

    /// <summary>
    /// Gets or sets the amount refunded in the transaction.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }

    /// <summary>
    /// Gets or sets the method used for the refund transaction.
    /// </summary>
    /// <remarks>
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.TransactionMethod"/> for valid values.
    /// </remarks>
    [JsonPropertyName("method")]
    public required string Method { get; set; }
}