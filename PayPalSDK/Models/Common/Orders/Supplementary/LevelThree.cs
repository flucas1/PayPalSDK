using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Orders.Supplementary;

/// <summary>
/// Represents Level 3 data for a PayPal order.
/// </summary>
[DataContract]
public class LevelThree
{
    /// <summary>
    /// Gets or sets the postal code from which the shipment originates.
    /// </summary>
    /// <remarks>
    /// The postal code is limited to 60 characters.
    /// </remarks>
    [JsonPropertyName("ship_from_postal_code")]
    [StringLength(60)]
    public string ShipFromPostalCode { get; set; }

    /// <summary>
    /// Gets or sets the list of line items included in the transaction.
    /// </summary>
    /// <remarks>
    /// Each line item represents detailed information about a product or service in the transaction.
    /// </remarks>
    [JsonPropertyName("line_items")]
    public List<LineItem> LineItems { get; set; }

    /// <summary>
    /// Gets or sets the shipping amount for the transaction.
    /// </summary>
    /// <remarks>
    /// This property represents the monetary value of the shipping cost.
    /// </remarks>
    [JsonPropertyName("shipping_amount")]
    public Money ShippingAmount { get; set; }

    /// <summary>
    /// Gets or sets the duty amount for the transaction.
    /// </summary>
    /// <remarks>
    /// This property represents the monetary value of any duties applied to the transaction.
    /// </remarks>
    [JsonPropertyName("duty_amount")]
    public Money DutyAmount { get; set; }

    /// <summary>
    /// Gets or sets the discount amount for the transaction.
    /// </summary>
    /// <remarks>
    /// This property represents the monetary value of any discounts applied to the transaction.
    /// </remarks>
    [JsonPropertyName("discount_amount")]
    public Money DiscountAmount { get; set; }

    /// <summary>
    /// Gets or sets the shipping address for the transaction.
    /// </summary>
    /// <remarks>
    /// This property contains detailed information about the destination address for the shipment.
    /// </remarks>
    [JsonPropertyName("shipping_address")]
    public Address ShippingAddress { get; set; }
}