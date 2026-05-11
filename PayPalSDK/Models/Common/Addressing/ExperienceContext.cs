using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Addressing;

/// <summary>
/// Represents the context for configuring the PayPal payment experience.
/// </summary>
[DataContract]
public class ExperienceContext
{
    /// <summary>
    /// The label that overrides the business name in the PayPal account on the PayPal site.
    /// </summary>
    [JsonPropertyName("brand_name")]
    [StringLength(127)]
    public string? BrandName { get; set; }

    /// <summary>
    /// The type of landing page to show on the PayPal site for customer checkout.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.Experience.LandingPages"/>.
    /// </summary>
    [JsonPropertyName("landing_page")]
    [StringLength(13)]
    public string? LandingPage { get; set; }

    /// <summary>
    /// The shipping preference for the PayPal payment experience.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.Experience.ShippingPreference"/>.
    /// </summary>
    [JsonPropertyName("shipping_preference")]
    [StringLength(24)]
    public string? ShippingPreference { get; set; }

    /// <summary>
    /// Configures the user action for the checkout flow.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.Experience.UserAction"/>.
    /// </summary>
    [JsonPropertyName("user_action")]
    [StringLength(8)]
    public string? UserAction { get; set; }

    /// <summary>
    /// The URL where the customer is redirected after approving the payment.
    /// </summary>
    [JsonPropertyName("return_url")]
    public string? ReturnUrl { get; set; }

    /// <summary>
    /// The URL where the customer is redirected after canceling the payment.
    /// </summary>
    [JsonPropertyName("cancel_url")]
    public string? CancelUrl { get; set; }

    /// <summary>
    /// The BCP 47-formatted locale of pages displayed during the PayPal payment experience.
    /// </summary>
    [JsonPropertyName("locale")]
    [StringLength(10)]
    [RegularExpression("^[a-z]{2}(?:-[A-Z][a-z]{3})?(?:-(?:[A-Z]{2}|[0-9]{3}))?$")]
    public string? Locale { get; set; }

    /// <summary>
    /// The merchant-preferred payment methods.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.Experience.PaymentPreference"/>.
    /// </summary>
    [JsonPropertyName("payment_method_preference")]
    [StringLength(255)]
    public string? PaymentMethodPreference { get; set; }

    /// <summary>
    /// The contact preference for the merchant.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.Experience.ContactPreference"/>.
    /// </summary>
    [JsonPropertyName("contact_preference")]
    [StringLength(24)]
    public string? ContactPreference { get; set; }
}