using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;

namespace Tavstal.PayPalSDK.Models.ProductCatalog;

/// <summary>
/// Represents the body of a product list response.
/// </summary>
[DataContract]
public class ProductListBody
{
    /// <summary>
    /// Gets or sets the list of products in the response.
    /// </summary>
    [JsonPropertyName("products")]
    public List<ProductListElement> Products { get; set; }

    /// <summary>
    /// Gets or sets the total number of items in the product list.
    /// </summary>
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages in the product list.
    /// </summary>
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the list of links associated with the product list.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }
}