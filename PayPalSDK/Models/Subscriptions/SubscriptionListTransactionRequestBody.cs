using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the request body for listing subscription transactions.
/// </summary>
[DataContract]
public class SubscriptionListTransactionRequestBody
{
    /// <summary>
    /// Gets or sets the list of transactions associated with the subscription.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<Transaction> Transactions { get; set; }

    /// <summary>
    /// Gets or sets the total number of items in the transaction list.
    /// </summary>
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages in the transaction list.
    /// </summary>
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the list of links related to the subscription transactions.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }
}