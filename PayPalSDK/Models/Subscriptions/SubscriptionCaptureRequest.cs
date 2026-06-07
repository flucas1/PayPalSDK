using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to capture a subscription payment.
/// </summary>
public class SubscriptionCaptureRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionCaptureRequest"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription for which the payment is being captured.</param>
    /// <param name="body">The body of the request containing the details of the payment capture.</param>
    /// <remarks>
    /// This request uses the HTTP POST method and sets the request content using JSON serialization.
    /// Null values in the body are ignored during serialization.
    /// </remarks>
    public SubscriptionCaptureRequest(string id, SubscriptionCaptureRequestBody body)
        :
        base(HttpMethod.Post, $"/v1/billing/subscriptions/{id}/capture")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<SubscriptionCaptureRequestBody>(body, PayPalSDKSerializerContext.Default.SubscriptionCaptureRequestBody);
    }
}