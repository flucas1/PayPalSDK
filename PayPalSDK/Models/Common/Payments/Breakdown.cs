using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the breakdown of monetary amounts in the PayPal SDK.
/// </summary>
[DataContract]
public class Breakdown
{
    /// <summary>
    /// Gets or sets the total amount for items.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of the items.
    /// </remarks>
    [JsonPropertyName("item_total")]
    public required Money ItemTotal { get; set; }

    /// <summary>
    /// Gets or sets the shipping amount.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of shipping.
    /// </remarks>
    [JsonPropertyName("shipping")]
    public Money? Shipping { get; set; }

    /// <summary>
    /// Gets or sets the handling amount.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of handling.
    /// </remarks>
    [JsonPropertyName("handling")]
    public Money? Handling { get; set; }

    /// <summary>
    /// Gets or sets the total tax amount.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of taxes.
    /// </remarks>
    [JsonPropertyName("tax_total")]
    public Money? TaxTotal { get; set; }

    /// <summary>
    /// Gets or sets the insurance amount.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of insurance.
    /// </remarks>
    [JsonPropertyName("insurance")]
    public Money? Insurance { get; set; }

    /// <summary>
    /// Gets or sets the shipping discount amount.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of shipping discounts.
    /// </remarks>
    [JsonPropertyName("shipping_discount")]
    public Money? ShippingDiscount { get; set; }

    /// <summary>
    /// Gets or sets the discount amount.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the monetary value of discounts.
    /// </remarks>
    [JsonPropertyName("discount")]
    public Money? Discount { get; set; }
}