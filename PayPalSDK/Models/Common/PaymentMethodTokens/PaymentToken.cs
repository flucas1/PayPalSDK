using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.PaymentMethodTokens;

/// <summary>
/// Represents a payment token returned by the Payment Method Tokens API.
/// </summary>
[DataContract]
public class PaymentToken
{
    /// <summary>
    /// Gets or sets the unique identifier of the payment token.
    /// </summary>
    [JsonPropertyName("id")]
    [StringLength(36)]
    [RegularExpression("^[0-9a-zA-Z_-]+$")]
    public string? Id { get; set; }
    
    /// <summary>
    /// Gets or sets the payment source details associated with this token.
    /// </summary>
    [JsonPropertyName("payment_source")]
    public PaymentSource? PaymentSource { get; set; }
    
    /// <summary>
    /// Gets or sets HATEOAS links related to this payment token resource.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link>? Links { get; set; }
    
    /// <summary>
    /// Gets or sets customer information associated with this payment token.
    /// </summary>
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
}