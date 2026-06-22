using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Plans;

/// <summary>
/// Represents a pricing tier for a subscription plan with quantity-based pricing.
/// </summary>
[DataContract]
public class PlanPricingTier
{
    /// <summary>
    /// Gets or sets the starting quantity for this pricing tier.
    /// </summary>
    /// <remarks>
    /// This value represents the minimum quantity (inclusive) at which this tier's pricing becomes applicable.
    /// </remarks>
    [JsonPropertyName("starting_quantity")]
    public string? StartingQuantity { get; set; }
    
    /// <summary>
    /// Gets or sets the ending quantity for this pricing tier.
    /// </summary>
    /// <remarks>
    /// This value represents the maximum quantity (inclusive) for which this tier's pricing applies.
    /// </remarks>
    [JsonPropertyName("ending_quantity")]
    public string? EndingQuantity { get; set; }
    
    /// <summary>
    /// Gets or sets the price amount for this pricing tier.
    /// </summary>
    /// <remarks>
    /// This <see cref="Money"/> object contains the currency and value applicable to quantities
    /// within the starting and ending quantity range defined for this tier.
    /// </remarks>
    [JsonPropertyName("amount")]
    public Money? Amount { get; set; }
}