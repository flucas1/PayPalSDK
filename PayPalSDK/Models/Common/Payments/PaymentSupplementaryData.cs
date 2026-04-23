using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents supplementary data for a PayPal payment transaction.
/// </summary>
[DataContract]
public class PaymentSupplementaryData
{
    /// <summary>
    /// Related identifiers for the payment transaction, such as order ID, authorization ID, and capture ID.
    /// </summary>
    [JsonPropertyName("related_ids")]
    public RelatedIds RelatedIds { get; set; }
}