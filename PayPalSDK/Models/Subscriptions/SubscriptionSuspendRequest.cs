using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to suspend a subscription.
/// </summary>
public class SubscriptionSuspendRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionSuspendRequest"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the subscription to be suspended.</param>
    /// <param name="reason">The reason for suspending the subscription. Must be provided and cannot exceed 128 characters.</param>
    /// <remarks>
    /// This request uses the HTTP POST method and sets the request content using JSON serialization.
    /// Null values in the body are ignored during serialization.
    /// </remarks>
    public SubscriptionSuspendRequest(string id, [Required, StringLength(128)] string reason)
        :
        base(HttpMethod.Post, $"/v1/billing/subscriptions/{id}/suspend")
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