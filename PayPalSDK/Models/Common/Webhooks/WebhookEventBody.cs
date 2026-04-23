using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Webhooks;

/// <summary>
/// Represents the body of a webhook event in the PayPal SDK.
/// </summary>
[DataContract]
public class WebhookEventBody
{
    /// <summary>
    /// Gets or sets the unique identifier of the webhook event.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the creation time of the webhook event.
    /// </summary>
    /// <remarks>
    /// The creation time is in ISO 8601 format.
    /// </remarks>
    [JsonPropertyName("create_time")]
    public string CreateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the webhook event.
    /// </summary>
    /// <remarks>
    /// The event type indicates the nature of the event, such as payment or refund.
    /// </remarks>
    [JsonPropertyName("event_type")]
    public string EventType { get; set; }

    /// <summary>
    /// Gets or sets the version of the webhook event.
    /// </summary>
    [JsonPropertyName("event_version")]
    public string EventVersion { get; set; }

    /// <summary>
    /// Gets or sets a summary of the webhook event.
    /// </summary>
    /// <remarks>
    /// The summary provides a brief description of the event.
    /// </remarks>
    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    /// <summary>
    /// Gets or sets the version of the resource associated with the webhook event.
    /// </summary>
    [JsonPropertyName("resource_version")]
    public string ResourceVersion { get; set; }

    /// <summary>
    /// Gets or sets the resource associated with the webhook event.
    /// </summary>
    /// <remarks>
    /// The resource contains the payload of the event.
    /// </remarks>
    [JsonPropertyName("resource")]
    public object Resource { get; set; }

    /// <summary>
    /// Gets or sets the list of links related to the webhook event.
    /// </summary>
    /// <remarks>
    /// The links provide additional information or actions related to the event.
    /// </remarks>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }
}