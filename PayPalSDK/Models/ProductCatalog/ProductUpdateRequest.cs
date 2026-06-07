using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.ProductCatalog;

/// <summary>
/// Represents a request to update a specific product in the product catalog.
/// </summary>
public class ProductUpdateRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductUpdateRequest"/> class.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to update.</param>
    /// <param name="body">The list of update operations to apply to the product.</param>
    public ProductUpdateRequest(string productId, List<UpdateOperation> body)
        :
        base(HttpMethod.Patch, $"/v1/catalogs/products/{productId}")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<List<UpdateOperation>>(body, PayPalSDKSerializerContext.Default.ListUpdateOperation);
    }
}