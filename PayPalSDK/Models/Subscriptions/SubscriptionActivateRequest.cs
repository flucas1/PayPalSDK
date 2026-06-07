using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to activate a subscription.
/// </summary>
public class SubscriptionActivateRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionActivateRequest"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription to be activated.</param>
    /// <param name="reason">The reason for activating the subscription. Must not exceed 128 characters.</param>
    /// <remarks>
    /// This request uses the HTTP POST method and sets the request content using JSON serialization.
    /// Null values in the body are ignored during serialization.
    /// </remarks>
    public SubscriptionActivateRequest(string id, [StringLength(128)] string reason)
        :
        base(HttpMethod.Post, $"/v1/billing/subscriptions/{id}/activate")
    {
        // Sets the content of the HTTP request using the provided reason and JSON serialization options.
        Content = JsonContent.Create<ProvidedReason>(new ProvidedReason()
            {
                Reason = reason
            },
            PayPalSDKSerializerContext.Default.ProvidedReason
        );
    }
}
