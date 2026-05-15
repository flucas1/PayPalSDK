using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents a request to confirm an order's payment source within the PayPal SDK.
/// </summary>
public class OrderConfirmRequest : HttpRequestBase<OrderBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderConfirmRequest"/> class.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to be confirmed.</param>
    /// <param name="body">The request body containing application context and payment source details.</param>
    public OrderConfirmRequest(string orderId, OrderConfirmRequestBody body)
        : base(HttpMethod.Post, $"/v2/checkout/orders/{orderId}/confirm-payment-source")
    {
        Content = JsonContent.Create(body, options: new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="OrderConfirmRequest"/> for method chaining.</returns>
    public OrderConfirmRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
}