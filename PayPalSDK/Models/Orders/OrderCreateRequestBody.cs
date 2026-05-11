using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Orders;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents the request body for creating an order within the PayPal SDK.
/// </summary>
[DataContract]
public class OrderCreateRequestBody
{
    /// <summary>
    /// Gets or sets the list of purchase units for the order.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the details of the items or services being purchased.
    /// </remarks>
    [JsonPropertyName("purchase_units")]
    public required List<PurchaseUnit> PurchaseUnits { get; set; }

    /// <summary>
    /// Gets or sets the intent of the order.
    /// </summary>
    /// <remarks>
    /// This field is required and specifies the purpose of the order, such as "CAPTURE" or "AUTHORIZE".
    /// </remarks>
    [JsonPropertyName("intent")]
    public required string Intent { get; set; }

    /// <summary>
    /// Gets or sets the payment source for the order.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the payment method or source used for the transaction.
    /// </remarks>
    [JsonPropertyName("payment_source")]
    public PaymentSource? PaymentSource { get; set; }
}