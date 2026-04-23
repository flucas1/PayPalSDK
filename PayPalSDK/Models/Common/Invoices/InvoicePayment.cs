using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents the payment details for a PayPal invoice, including transactions and the total paid amount.
/// </summary>
[DataContract]
public class InvoicePayment
{
    /// <summary>
    /// Gets or sets the list of transactions associated with the invoice payment.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<InvoiceTransaction> Transactions { get; set; }

    /// <summary>
    /// Gets or sets the total amount paid for the invoice.
    /// </summary>
    [JsonPropertyName("paid_amount")]
    public Money PaidAmount { get; set; }
}