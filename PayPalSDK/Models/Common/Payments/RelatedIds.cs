using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents related identifiers for a PayPal payment transaction.
/// </summary>
[DataContract]
public class RelatedIds
{
    /// <summary>
    /// The unique identifier for the PayPal order.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string OrderId { get; set; }

    /// <summary>
    /// The unique identifier for the authorization associated with the payment.
    /// </summary>
    [JsonPropertyName("authorization_id")]
    public string AuthorizationId { get; set; }

    /// <summary>
    /// The unique identifier for the capture associated with the payment.
    /// </summary>
    [JsonPropertyName("capture_id")]
    public string CaptureId { get; set; }
}