using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the body of a response containing a list of subscription plans.
/// </summary>
[DataContract]
public class PlanListBody
{
    /// <summary>
    /// Gets or sets the list of subscription plans.
    /// </summary>
    [JsonPropertyName("plans")]
    public List<PlanBody> Plans { get; set; }

    /// <summary>
    /// Gets or sets the total number of items in the response.
    /// </summary>
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages in the response.
    /// </summary>
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the list of links associated with the response.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }
}