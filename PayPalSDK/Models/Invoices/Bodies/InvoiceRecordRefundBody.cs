using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices.Bodies;

/// <summary>
/// Represents the request body used to record a refund against an invoice by refund ID.
/// </summary>
[DataContract]
public class InvoiceRecordRefundBody
{
    /// <summary>
    /// Gets or sets the refund identifier.
    /// </summary>
    [JsonPropertyName("refund_id")]
    [StringLength(22)]
    public string? RefundId { get; set; }
}