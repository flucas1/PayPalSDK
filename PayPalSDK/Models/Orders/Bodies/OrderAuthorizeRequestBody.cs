using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Orders.Bodies;

/// <summary>
/// Represents the request body for authorizing an order within the PayPal SDK.
/// </summary>
[DataContract]
public class OrderAuthorizeRequestBody
{
    /// <summary>
    /// Gets or sets the payment source for the order authorization.
    /// </summary>
    /// <remarks>
    /// This field is optional and specifies the payment method or source used for the transaction.
    /// </remarks>
    [JsonPropertyName("payment_source")]
    public PaymentSource? PaymentSource { get; set; }
}
