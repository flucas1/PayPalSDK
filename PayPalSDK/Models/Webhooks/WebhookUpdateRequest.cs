using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Webhooks;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents an HTTP request for updating a specific webhook in the PayPal SDK.
/// </summary>
public class WebhookUpdateRequest : HttpRequestBase<Webhook>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WebhookUpdateRequest"/> class.
    /// </summary>
    /// <param name="webhookId">The unique identifier of the webhook to update.</param>
    /// <param name="body">The list of update operations to apply to the webhook.</param>
    public WebhookUpdateRequest(string webhookId, List<UpdateOperation> body)
        :
        base(HttpMethod.Patch, $"/v1/notifications/webhooks/{webhookId}")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<List<UpdateOperation>>(body, PayPalSDKSerializerContext.Default.ListUpdateOperation);
    }
}