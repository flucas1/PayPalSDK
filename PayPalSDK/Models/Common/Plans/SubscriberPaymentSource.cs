using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents the payment source information for a subscriber.
/// </summary>
[DataContract]
public class SubscriberPaymentSource
{
    /// <summary>
    /// Gets or sets the subscriber's card information used for payment.
    /// </summary>
    [JsonPropertyName("card")]
    public SubscriberCard Card { get; set; }
}