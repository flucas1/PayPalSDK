using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents the request body for capturing an order within the PayPal SDK.
/// </summary>
[DataContract]
public class OrderCaptureRequestBody
{
    /// <summary>
    /// Gets or sets the payment source for the order capture.
    /// </summary>
    /// <remarks>
    /// This field is optional and specifies the payment method or source used for the transaction.
    /// </remarks>
    [JsonPropertyName("payment_source")]
    public PaymentSource? PaymentSource { get; set; }
}

