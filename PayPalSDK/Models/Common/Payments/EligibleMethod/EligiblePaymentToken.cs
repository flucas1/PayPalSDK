using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

/// <summary>
/// Represents a payment token that identifies and contains details about a stored or eligible payment method.
/// </summary>
[DataContract]
public class EligiblePaymentToken
{
    /// <summary>
    /// Gets or sets the unique identifier for this payment token.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    /// <summary>
    /// Gets or sets the payment source details associated with this token.
    /// </summary>
    [JsonPropertyName("payment_source")]
    public EligiblePaymentSource? PaymentSource { get; set; }
    
    /// <summary>
    /// Gets or sets a collection of HATEOAS links related to this payment token.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link>? Links { get; set; }
}