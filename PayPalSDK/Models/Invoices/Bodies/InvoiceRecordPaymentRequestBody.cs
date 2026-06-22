using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Utils;

namespace Tavstal.PayPalSDK.Models.Invoices.Bodies;

/// <summary>
/// Represents the request body used to record a payment against an invoice.
/// </summary>
[DataContract]
public class InvoiceRecordPaymentRequestBody
{
    /// <summary>
    /// Gets or sets the payment identifier.
    /// </summary>
    [JsonPropertyName("payment_id")]
    [StringLength(22)]
    public string? PaymentId { get; set; }
    
    /// <summary>
    /// Gets or sets an optional note associated with the payment.
    /// </summary>
    [JsonPropertyName("note")]
    [StringLength(2000)]
    public string? Note { get; set; }
    
    /// <summary>
    /// Gets or sets the payment date in <c>yyyy-MM-dd</c> format.
    /// </summary>
    [JsonPropertyName("payment_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? PaymentDate { get; set; }
    
    /// <summary>
    /// Gets or sets the payment date and time.
    /// </summary>
    [JsonPropertyName("payment_date_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? PaymentDateTime { get; set; }
    
    /// <summary>
    /// Gets or sets the payment method.
    /// </summary>
    [JsonPropertyName("method")]
    [StringLength(255)]
    [RegularExpression("^[\\S\\s]*$")]
    public required string Method { get; set; }
    
    /// <summary>
    /// Gets or sets the payment amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money? Amount { get; set; }
    
    /// <summary>
    /// Gets or sets shipping information related to the payment.
    /// </summary>
    [JsonPropertyName("shipping_info")]
    public ShippingInfo? ShippingInfo { get; set; }
    
    /// <summary>
    /// Gets the payment date and time as a nullable DateTime object.
    /// </summary>
    public DateTime? PaymentDateAsDateTime => DateTimeHelper.FromISO8601(PaymentDateTime);
    
    /// <summary>
    /// Gets the payment date as a nullable DateTime object.
    /// </summary>
    public DateTime? PaymentDateAsDate => DateTimeHelper.FromISO8601(PaymentDate);
}