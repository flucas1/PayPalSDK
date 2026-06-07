using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents a request to create an order within the PayPal SDK.
/// </summary>
public class OrderCreateRequest : HttpRequestBase<OrderBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderCreateRequest"/> class.
    /// </summary>
    /// <param name="body">The request body containing the order creation details.</param>
    public OrderCreateRequest(OrderCreateRequestBody body)
        : base(HttpMethod.Post, "/v2/checkout/orders")
    {
        // Sets the content of the HTTP request to the serialized JSON representation of the order creation details.
        Content = JsonContent.Create<OrderCreateRequestBody>(body, PayPalSDKSerializerContext.Default.OrderCreateRequestBody);
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="OrderCreateRequest"/> for method chaining.</returns>
    public OrderCreateRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
}