using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Billing;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents the recipient information for an invoice.
/// </summary>
[DataContract]
public class Recipient
{
    /// <summary>
    /// Gets or sets the billing information of the recipient.
    /// </summary>
    /// <remarks>
    /// This includes details such as the business name, contact information, and address.
    /// </remarks>
    [JsonPropertyName("billing_info")]
    public BusinessBillingInfo BillingInfo { get; set; }

    /// <summary>
    /// Gets or sets the shipping information of the recipient.
    /// </summary>
    /// <remarks>
    /// This includes details such as the shipping address and recipient name.
    /// </remarks>
    [JsonPropertyName("shipping_info")]
    public ShippingInfo ShippingInfo { get; set; }
}