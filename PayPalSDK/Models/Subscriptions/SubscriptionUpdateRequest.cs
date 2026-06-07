using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to update subscription details.
/// </summary>
public class SubscriptionUpdateRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionUpdateRequest"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription to be updated.</param>
    /// <param name="body">A list of update operations to apply to the subscription.</param>
    /// <remarks>
    /// This request uses the HTTP PATCH method and sets the request content using JSON serialization.
    /// Null values in the body are ignored during serialization.
    /// </remarks>
    public SubscriptionUpdateRequest(string id, List<UpdateOperation> body)
        :
        base(HttpMethod.Patch, $"/v1/billing/subscriptions/{id}")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<List<UpdateOperation>>(body, PayPalSDKSerializerContext.Default.ListUpdateOperation);
    }
}