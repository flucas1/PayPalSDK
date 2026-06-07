using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents an HTTP request for creating a webhook in the PayPal SDK.
/// </summary>
public class WebhookCreateRequest : HttpRequestBase<WebhookBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WebhookCreateRequest"/> class.
    /// </summary>
    /// <param name="body">The request body containing the webhook details.</param>
    public WebhookCreateRequest(WebhookCreateRequestBody body)
        :
        base(HttpMethod.Post, $"/v1/notifications/webhooks")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<WebhookCreateRequestBody>(body, PayPalSDKSerializerContext.Default.WebhookCreateRequestBody);
    }
}