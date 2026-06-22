using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Billing;

/// <summary>
/// Represents a pricing scheme in the PayPal SDK.
/// </summary>
[DataContract]
public class PricingScheme
{
    /// <summary>
    /// Gets or sets the pricing model type for the scheme.
    /// </summary>
    /// <remarks>
    /// The pricing model corresponds to one of the predefined models in <see cref="Tavstal.PayPalSDK.Constants.PricingModelType"/>.
    /// This field is required and has a maximum length of 24 characters.
    /// </remarks>
    [JsonPropertyName("pricing_model")]
    [StringLength(24)]
    public string? PricingModel { get; set; }

    /// <summary>
    /// Gets or sets the price associated with the pricing scheme.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of the price.
    /// </remarks>
    [JsonPropertyName("price")]
    public Money? Price { get; set; }

    /// <summary>
    /// Gets or sets the reload threshold amount for the pricing scheme.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of the reload threshold amount.
    /// </remarks>
    [JsonPropertyName("reload_threshold_amount")]
    public Money? ReloadThresholdAmount { get; set; }
}