using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents a refund associated with a PayPal invoice, including transactions and the total refund amount.
/// </summary>
[DataContract]
public class InvoiceRefund
{
    /// <summary>
    /// Gets or sets the list of transactions related to the invoice refund.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<InvoiceRefundTransaction> Transactions { get; set; }

    /// <summary>
    /// Gets or sets the total amount refunded for the invoice.
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public Money RefundAmount { get; set; }
}