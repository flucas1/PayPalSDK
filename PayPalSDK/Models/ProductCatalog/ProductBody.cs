using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.ProductCatalog;

/// <summary>
/// Represents the body of a product in the PayPal SDK.
/// </summary>
[DataContract]
public class ProductBody
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
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    [JsonPropertyName("description")]
    [StringLength(256)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the type of the product.
    /// <see cref="Tavstal.PayPalSDK.Constants.ProductType"/>
    /// </summary>
    [JsonPropertyName("type")]
    [StringLength(24)]
    public required string Type { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// <see cref="Tavstal.PayPalSDK.Constants.ProductCategories"/>
    /// </summary>
    [JsonPropertyName("category")]
    [StringLength(256)]
    [RegularExpression("^[A-Z_]+$")]
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the URL of the product image.
    /// </summary>
    [JsonPropertyName("image_url")]
    [StringLength(2000)]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the URL of the product's homepage.
    /// </summary>
    [JsonPropertyName("home_url")]
    [StringLength(2000)]
    public string HomeUrl { get; set; }
}