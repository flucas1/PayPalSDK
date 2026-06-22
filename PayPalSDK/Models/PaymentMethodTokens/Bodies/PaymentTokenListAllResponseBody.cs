using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.PaymentMethodTokens;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.PaymentMethodTokens.Bodies;

/// <summary>
/// Represents the response body returned when listing payment tokens for a customer.
/// </summary>
[DataContract]
public class PaymentTokenListAllResponseBody
{
    /// <summary>
    /// Gets or sets the total number of payment token items available for the query.
    /// </summary>
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of pages available for the current query.
    /// </summary>
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    /// <summary>
    /// Gets or sets the collection of payment tokens returned for the current page.
    /// </summary>
    [JsonPropertyName("payment_tokens")]
    public List<PaymentToken>? PaymentTokens { get; set; }
    
    /// <summary>
    /// Gets or sets HATEOAS links associated with the paginated response.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link>? Links { get; set; }
    
    /// <summary>
    /// Gets or sets customer information related to the returned payment tokens.
    /// </summary>
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
}