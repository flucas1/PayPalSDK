using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the partial payment options for an invoice, including whether partial payments are allowed and the minimum amount due.
/// </summary>
[DataContract]
public class PartialPayment
{
    /// <summary>
    /// Gets or sets a value indicating whether partial payments are allowed for the invoice.
    /// </summary>
    [JsonPropertyName("allow_partial_payment")]
    public bool AllowPartialPayment { get; set; }

    /// <summary>
    /// Gets or sets the minimum amount due for a partial payment.
    /// </summary>
    [JsonPropertyName("minimum_amount_due")]
    public Money MinimalAmountDue { get; set; }
}