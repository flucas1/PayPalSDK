using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

/// <summary>
/// Represents the payment sources available to a customer, including PayPal and Venmo.
/// </summary>
[DataContract]
public class EligiblePaymentSource
{
    /// <summary>
    /// Gets or sets the PayPal payment source eligibility information.
    /// </summary>
    [JsonPropertyName("paypal")]
    public EligiblePayPalSource? PayPal { get; set; }
    
    /// <summary>
    /// Gets or sets the Venmo payment source eligibility information.
    /// </summary>
    [JsonPropertyName("venmo")]
    public EligibleVenmoSource? Venmo { get; set; }
}