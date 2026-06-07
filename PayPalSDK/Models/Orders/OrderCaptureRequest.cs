using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents a request to capture an order within the PayPal SDK.
/// </summary>
public class OrderCaptureRequest : HttpRequestBase<OrderBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderCaptureRequest"/> class.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to be captured.</param>
    /// <param name="body">The request body containing payment source details for the capture.</param>
    public OrderCaptureRequest(string orderId, OrderCaptureRequestBody body)
        : base(HttpMethod.Post, $"/v2/checkout/orders/{orderId}/capture")
    {
        Content = JsonContent.Create<OrderCaptureRequestBody>(body, PayPalSDKSerializerContext.Default.OrderCaptureRequestBody);
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="OrderCaptureRequest"/> for method chaining.</returns>
    public OrderCaptureRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
}

