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
    /// This field has a maximum length of 24 characters.
    /// </remarks>
    [JsonPropertyName("pricing_model")]
    [StringLength(24)]
    public string PricingModel { get; set; }

    /// <summary>
    /// An array of pricing tiers which are used for billing volume/tiered plans.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [JsonPropertyName("tiers")]
    public List<Tier> Tiers { get; set; }

    /// <summary>
    /// The fixed amount to charge for the subscription.
    /// </summary>
    /// <remarks>
    /// The changes to fixed amount are applicable to both existing and future subscriptions. For existing subscriptions, payments within 10 days of price change are not affected.
    /// </remarks>
    [JsonPropertyName("fixed_price")]
    public Money FixedPrice { get; set; }
}