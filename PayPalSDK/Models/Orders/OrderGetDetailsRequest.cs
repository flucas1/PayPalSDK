using Tavstal.PayPalSDK.Http;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents a request to retrieve the details of an order within the PayPal SDK.
/// </summary>
public class OrderGetDetailsRequest : HttpRequestBase<OrderBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderGetDetailsRequest"/> class.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order whose details are to be retrieved.</param>
    public OrderGetDetailsRequest(string orderId)
        : base(HttpMethod.Get, $"/v2/checkout/orders/{orderId}")
    {
        // No body for GET request
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="OrderGetDetailsRequest"/> for method chaining.</returns>
    public OrderGetDetailsRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
}
