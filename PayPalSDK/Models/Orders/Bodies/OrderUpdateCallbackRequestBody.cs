using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Orders;

namespace Tavstal.PayPalSDK.Models.Orders.Bodies;

/// <summary>
/// Represents the payload used to send order update callback information to the PayPal API.
/// </summary>
[DataContract]
public class OrderUpdateCallbackRequestBody
{
    /// <summary>
    /// Gets or sets the shipping address associated with the order update callback.
    /// </summary>
    /// <remarks>
    /// This field is optional and contains the updated shipping address information for the order.
    /// </remarks>
    [JsonPropertyName("shipping_address")]
    public Shipping? ShippingAddress { get; set; }
    
    /// <summary>
    /// Gets or sets the selected shipping option for the order update callback.
    /// </summary>
    /// <remarks>
    /// This field is optional and identifies the shipping option chosen for the order.
    /// </remarks>
    [JsonPropertyName("shipping_option")]
    public ShippingOption? ShippingOption { get; set; }
    
    /// <summary>
    /// Gets or sets the purchase units included in the order update callback.
    /// </summary>
    /// <remarks>
    /// This field is required and contains the list of purchase units affected by the callback.
    /// Although the list reference itself is nullable, it is marked as required to indicate that the property
    /// should be provided when constructing the payload.
    /// </remarks>
    [JsonPropertyName("purchase_units")]
    public required List<PurchaseUnit>? PurchaseUnits { get; set; }
}