using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;

namespace Tavstal.PayPalSDK.Models.ProductCatalog;

/// <summary>
/// Represents an element in the product list.
/// </summary>
[DataContract]
public class ProductListElement
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    [JsonPropertyName("id")]
    [StringLength(50)]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [JsonPropertyName("name")]
    [StringLength(127)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    [JsonPropertyName("description")]
    [StringLength(256)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the list of links associated with the product.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    /// <summary>
    /// Gets or sets the creation time of the product.
    /// The format must follow the ISO 8601 standard.
    /// </summary>
    [JsonPropertyName("created_time")]
    [StringLength(64)]
    [RegularExpression(@"^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string CreatedTime { get; set; }
}