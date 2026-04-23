using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Payments;

/// <summary>
/// Represents the body of a payment capture request.
/// </summary>
[DataContract]
public class PaymentCaptureRequestBody
{
    /// <summary>
    /// The invoice ID associated with the payment capture.
    /// </summary>
    [JsonPropertyName("invoice_id")]
    [StringLength(127)]
    public string InvoicdeId { get; set; }

    /// <summary>
    /// A note provided to the payer for the payment capture.
    /// </summary>
    [JsonPropertyName("note_to_payer")]
    [StringLength(255)]
    public string NoteToPayer { get; set; }

    /// <summary>
    /// Indicates whether this is the final capture of the payment.
    /// </summary>
    [JsonPropertyName("final_capture")]
    public bool FinalCapture { get; set; }

    /// <summary>
    /// Instructions for processing the payment.
    /// </summary>
    [JsonPropertyName("payment_instruction")]
    public PaymentInstruction PaymentInstruction { get; set; }

    /// <summary>
    /// A soft descriptor that appears on the payer's statement.
    /// </summary>
    [JsonPropertyName("soft_descriptor")]
    [StringLength(22)]
    public string SoftDescriptor { get; set; }

    /// <summary>
    /// The monetary amount to be captured.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }
}