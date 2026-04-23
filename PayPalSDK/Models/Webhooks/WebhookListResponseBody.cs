using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Webhooks;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents the response body for a request to list webhooks in the PayPal SDK.
/// </summary>
[DataContract]
public class WebhookListResponseBody
{
    /// <summary>
    /// Gets or sets the list of webhooks returned in the response.
    /// </summary>
    [JsonPropertyName("webhooks")]
    public List<Webhook> Webhooks { get; set; }
}