using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Webhooks;

/// <summary>
/// Represents a webhook event in the PayPal SDK.
/// </summary>
[DataContract]
public class WebhookEvent
{
    /// <summary>
    /// Gets or sets the version of the event.
    /// </summary>
    /// <remarks>
    /// The event version indicates the version of the webhook event payload.
    /// </remarks>
    [JsonPropertyName("event_version")]
    public string EventVersion { get; set; }

    /// <summary>
    /// Gets or sets the version of the resource associated with the event.
    /// </summary>
    /// <remarks>
    /// The resource version indicates the version of the resource that triggered the webhook event.
    /// </remarks>
    [JsonPropertyName("resource_version")]
    public string ResourceVersion { get; set; }
}