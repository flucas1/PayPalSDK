using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to revise a subscription.
/// </summary>
public class ReviseRequest : HttpRequestBase<SubscriptionRevisedBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReviseRequest"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription to be revised.</param>
    /// <param name="body">The body of the request containing the revised subscription details.</param>
    /// <remarks>
    /// This request uses the HTTP POST method and sets the request content using JSON serialization.
    /// Null values in the body are ignored during serialization.
    /// </remarks>
    public ReviseRequest(string id, ReviseRequestBody body)
        :
        base(HttpMethod.Post, $"/v1/billing/subscriptions/{id}/revise")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<ReviseRequestBody>(body, PayPalSDKSerializerContext.Default.ReviseRequestBody);
    }
}