using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Billing;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.Plans;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the request body for creating a subscription plan in the PayPal SDK.
/// </summary>
[DataContract]
public class PlanCreateRequestBody
{
    /// <summary>
    /// Gets or sets the product ID associated with the plan.
    /// </summary>
    /// <remarks>
    /// This field is required and must be a string with a maximum length of 22 characters.
    /// </remarks>
    [JsonPropertyName("product_id")]
    [StringLength(22)]
    public required string ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the plan.
    /// </summary>
    /// <remarks>
    /// This field is required and must be a string with a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(127)]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the status of the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string with a maximum length of 24 characters.
    /// </remarks>
    [JsonPropertyName("status")]
    [StringLength(24)]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the description of the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string with a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("description")]
    [StringLength(127)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the billing cycles associated with the plan.
    /// </summary>
    /// <remarks>
    /// This field is required and represents a list of billing cycle objects.
    /// </remarks>
    [JsonPropertyName("billing_cycles")]
    public required List<BillingCycle> BillingCycles { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether quantity is supported for the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and specifies if the plan supports quantity-based subscriptions.
    /// </remarks>
    [JsonPropertyName("quantity_supported")]
    public bool QuantitySupported { get; set; }

    /// <summary>
    /// Gets or sets the payment preferences for the plan.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the payment preferences object.
    /// </remarks>
    [JsonPropertyName("payment_preferences")]
    public required PlanPaymentPreference PaymentPreference { get; set; }

    /// <summary>
    /// Gets or sets the tax information for the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the tax details for the plan.
    /// </remarks>
    [JsonPropertyName("taxes")]
    public Taxes Taxes { get; set; }
}