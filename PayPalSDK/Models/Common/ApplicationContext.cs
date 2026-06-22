using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents the application context for a PayPal transaction.
/// </summary>
[DataContract]
public class ApplicationContext
{
    /// <summary>
    /// Gets or sets the brand name to be displayed in the PayPal checkout experience.
    /// </summary>
    /// <remarks>
    /// Maximum length: 127 characters.
    /// </remarks>
    [JsonPropertyName("brand_name")]
    [StringLength(127)]
    public string? BrandName { get; set; }

    /// <summary>
    /// Gets or sets the URL to which the customer is redirected after approving the payment.
    /// </summary>
    /// <remarks>
    /// Maximum length: 4000 characters.
    /// </remarks>
    [JsonPropertyName("return_url")]
    [StringLength(4000)]
    public string? ReturnUrl { get; set; }

    /// <summary>
    /// Gets or sets the URL to which the customer is redirected if they cancel the payment.
    /// </summary>
    /// <remarks>
    /// Maximum length: 4000 characters.
    /// </remarks>
    [JsonPropertyName("cancel_url")]
    [StringLength(4000)]
    public string? CancelUrl { get; set; }

    /// <summary>
    /// Gets or sets the locale for the PayPal checkout experience.
    /// </summary>
    /// <remarks>
    /// The locale must follow the format: `^[a-z]{2}(?:-[A-Z][a-z]{3})?(?:-(?:[A-Z]{2}|[0-9]{3}))?$`.
    /// Maximum length: 10 characters.
    /// </remarks>
    [JsonPropertyName("locale")]
    [StringLength(10)]
    [RegularExpression("^[a-z]{2}(?:-[A-Z][a-z]{3})?(?:-(?:[A-Z]{2}|[0-9]{3}))?$")]
    public string? Locale { get; set; }

    /// <summary>
    /// Gets or sets the stored payment source for the transaction.
    /// </summary>
    [JsonPropertyName("stored_payment_source")]
    public PaymentSource? StoredPaymentSource { get; set; }
}