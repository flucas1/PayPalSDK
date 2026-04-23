using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Payments;

/// <summary>
/// Represents the body of a payment refund request.
/// </summary>
[DataContract]
public class PaymentRefundRequestBody
{
    /// <summary>
    /// Gets or sets the custom identifier for the refund request.
    /// </summary>
    [JsonPropertyName("custom_id")]
    public string CustomId { get; set; }

    /// <summary>
    /// Gets or sets the invoice identifier associated with the refund.
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public string InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets a note to the payer regarding the refund.
    /// </summary>
    [JsonPropertyName("note_to_payer")]
    public string NoteToPayer { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount to be refunded.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }

    /// <summary>
    /// Gets or sets the payment instruction details for the refund.
    /// </summary>
    [JsonPropertyName("payment_instruction")]
    public PaymentInstruction PaymentInstruction { get; set; }
}