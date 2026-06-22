using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Orders.Bodies;

/// <summary>
/// Represents the request body for confirming an order within the PayPal SDK.
/// </summary>
[DataContract]
public class OrderConfirmRequestBody
{
    /// <summary>
    /// Gets or sets the application context for the PayPal transaction.
    /// </summary>
    /// <remarks>
    /// This field is optional and provides additional details about the transaction, such as branding and URLs.
    /// </remarks>
    [JsonPropertyName("application_context")]
    public ApplicationContext? ApplicationContext { get; set; }

    /// <summary>
    /// Gets or sets the payment source for the order confirmation.
    /// </summary>
    /// <remarks>
    /// This field is required and specifies the payment method or source used for the transaction.
    /// </remarks>
    [JsonPropertyName("payment_source")]
    public required PaymentSource PaymentSource { get; set; }
}
