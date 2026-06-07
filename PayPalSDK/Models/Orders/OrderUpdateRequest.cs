using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Orders;

/// <summary>
/// Represents a request to update an order within the PayPal SDK.
/// </summary>
public class OrderUpdateRequest : HttpRequestBase<OrderBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderUpdateRequest"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the order to be updated.</param>
    /// <param name="operations">An array of update operations to be applied to the order.</param>
    public OrderUpdateRequest(string id, UpdateOperation[] operations)
        : base(HttpMethod.Patch, $"/v2/checkout/orders/{id}")
    {
        Content = JsonContent.Create<UpdateOperation[]>(operations, PayPalSDKSerializerContext.Default.UpdateOperationArray);
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="OrderUpdateRequest"/> for method chaining.</returns>
    public OrderUpdateRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
}
