using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Webhooks;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents the body of a webhook in the PayPal SDK.
/// </summary>
[DataContract]
public class WebhookBody
{
    /// <summary>
    /// Gets or sets the unique identifier of the webhook.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

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

    /// <summary>
    /// Gets or sets the list of links related to the webhook.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }
}