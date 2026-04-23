using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents a subscriber's information for a subscription plan.
/// </summary>
[DataContract]
public class Subscriber
{
    /// <summary>
    /// Gets or sets the email address of the subscriber.
    /// </summary>
    /// <remarks>
    /// The email address must be a valid email format and can have a maximum length of 254 characters.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the PayPal-assigned ID for the payer.
    /// </summary>
    /// <remarks>
    /// The payer ID must be exactly 13 characters long and match the regular expression pattern: ^[2-9A-HJ-NP-Z]{13}$.
    /// </remarks>
    [JsonPropertyName("payer_id")]
    [StringLength(13)]
    [RegularExpression("^[2-9A-HJ-NP-Z]{13}$")]
    public string PayerId { get; set; }
    
    /// <summary>
    /// Gets or sets the name of the subscriber.
    /// </summary>
    [JsonPropertyName("name")]
    public Name Name { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subscriber.
    /// </summary>
    [JsonPropertyName("phone")]
    public Phone Phone { get; set; }

    /// <summary>
    /// Gets or sets the shipping address of the subscriber.
    /// </summary>
    [JsonPropertyName("shipping_address")]
    public Shipping ShippingAddress { get; set; }

    /// <summary>
    /// Gets or sets the payment source information for the subscriber.
    /// </summary>
    [JsonPropertyName("payment_source")]
    public SubscriberPaymentSource PaymentSource { get; set; }
}