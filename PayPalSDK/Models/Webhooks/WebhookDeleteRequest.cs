using Tavstal.PayPalSDK.Http;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents an HTTP request for deleting a specific webhook in the PayPal SDK.
/// </summary>
public class WebhookDeleteRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WebhookDeleteRequest"/> class.
    /// </summary>
    /// <param name="webhookId">The unique identifier of the webhook to delete.</param>
    public WebhookDeleteRequest(string webhookId)
        :
        base(HttpMethod.Delete, $"/v1/notifications/webhooks/{webhookId}")
    {
        // No body is needed for deletion request.
    }
}