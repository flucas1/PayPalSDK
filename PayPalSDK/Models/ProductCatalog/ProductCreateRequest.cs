using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.ProductCatalog;

/// <summary>
/// Represents a request to create a new product in the product catalog.
/// </summary>
public class ProductCreateRequest : HttpRequestBase<ProductBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductCreateRequest"/> class.
    /// </summary>
    /// <param name="body">The body of the product to be created, containing product details.</param>
    public ProductCreateRequest(ProductBody body)
        :
        base(HttpMethod.Post, "/v1/catalogs/products")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<ProductBody>(body, PayPalSDKSerializerContext.Default.ProductBody);
    }
}