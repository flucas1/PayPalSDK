using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Invoices.Bodies;

/// <summary>
/// Represents the request body used to record a refund against an invoice.
/// </summary>
[DataContract]
public class InvoiceRecordRefundRequestBody
{
    /// <summary>
    /// Gets or sets the refund date in <c>yyyy-MM-dd</c> format.
    /// </summary>
    [JsonPropertyName("refund_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? RefundDate { get; set; }
    
    /// <summary>
    /// Gets or sets the refund amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money? Amount { get; set; }
    
    /// <summary>
    /// Gets or sets the payment method used for the refund.
    /// </summary>
    [JsonPropertyName("method")]
    [StringLength(255)]
    [RegularExpression("^[\\S\\s]*$")]
    public required string Method { get; set; }
}