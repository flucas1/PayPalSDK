using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Webhooks;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents the body of a request to create a webhook in the PayPal SDK.
/// </summary>
public class WebhookCreateRequestBody
{
    /// <summary>
    /// Gets or sets the URL associated with the webhook.
    /// </summary>
    [JsonPropertyName("url")]
    [StringLength(2048)]
    public required string Url { get; set; }

    /// <summary>
    /// Gets or sets the list of event types associated with the webhook.
    /// </summary>
    [JsonPropertyName("event_types")]
    public required List<Webhook> EventTypes { get; set; }
}