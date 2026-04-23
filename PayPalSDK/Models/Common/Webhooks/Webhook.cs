using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Webhooks;

/// <summary>
/// Represents a webhook event in the PayPal SDK.
/// </summary>
[DataContract]
public class Webhook
{
    /// <summary>
    /// Gets or sets the name of the webhook event.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the webhook event.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    /// <summary>
    /// Gets or sets the status of the webhook event.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the list of resource versions associated with the webhook event.
    /// </summary>
    [JsonPropertyName("resource_versions")]
    public List<string> ResourceVersions { get; set; }
}