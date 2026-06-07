using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to create a subscription.
/// </summary>
public class SubscriptionCreateRequest : HttpRequestBase<SubscriptionBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionCreateRequest"/> class.
    /// </summary>
    /// <param name="body">The request body containing subscription creation details.</param>
    public SubscriptionCreateRequest(SubscriptionCreateRequestBody body)
        : base(HttpMethod.Post, $"/v1/billing/subscriptions")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<SubscriptionCreateRequestBody>(body, PayPalSDKSerializerContext.Default.SubscriptionCreateRequestBody);
    }
}