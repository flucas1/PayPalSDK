using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents a request to authorize an order within the PayPal SDK.
/// </summary>
public class OrderAuthorizeRequest : HttpRequestBase<OrderBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderAuthorizeRequest"/> class.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to be authorized.</param>
    /// <param name="body">The request body containing payment source details for the authorization.</param>
    public OrderAuthorizeRequest(string orderId, OrderAuthorizeRequestBody body)
        : base(HttpMethod.Post, $"/v2/checkout/orders/{orderId}/authorize")
    {
        Content = JsonContent.Create<OrderAuthorizeRequestBody>(body, PayPalSDKSerializerContext.Default.OrderAuthorizeRequestBody);
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="OrderAuthorizeRequest"/> for method chaining.</returns>
    public OrderAuthorizeRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
}

