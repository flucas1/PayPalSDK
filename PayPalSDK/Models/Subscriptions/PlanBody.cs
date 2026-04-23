using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Billing;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.Plans;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the body of a subscription plan in the PayPal SDK.
/// </summary>
[DataContract]
public class PlanBody
{
    /// <summary>
    /// Gets or sets the unique identifier of the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string with a maximum length of 26 characters.
    /// </remarks>
    [JsonPropertyName("id")]
    [StringLength(26)]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the product ID associated with the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string with a maximum length of 22 characters.
    /// </remarks>
    [JsonPropertyName("product_id")]
    [StringLength(22)]
    public string ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string with a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(127)]
    public string Name { get; set; }

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
    /// This field is optional and represents a list of billing cycle objects.
    /// </remarks>
    [JsonPropertyName("billing_cycles")]
    public List<BillingCycle>? BillingCycles { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether quantity is supported for the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and specifies if the plan supports quantity-based subscriptions.
    /// </remarks>
    [JsonPropertyName("quantity_supported")]
    public bool QuantitySupported { get; set; }

    /// <summary>
    /// Gets or sets the links associated with the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents a list of link objects.
    /// </remarks>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    /// <summary>
    /// Gets or sets the payment preferences for the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the payment preferences object.
    /// </remarks>
    [JsonPropertyName("payment_preferences")]
    public PlanPaymentPreference PaymentPreferences { get; set; }

    /// <summary>
    /// Gets or sets the tax information for the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the tax details for the plan.
    /// </remarks>
    [JsonPropertyName("taxes")]
    public Taxes Taxes { get; set; }

    /// <summary>
    /// Gets or sets the creation time of the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string formatted as an ISO 8601 timestamp.
    /// </remarks>
    [JsonPropertyName("create_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string CreateTime { get; set; }

    /// <summary>
    /// Gets or sets the last update time of the plan.
    /// </summary>
    /// <remarks>
    /// This field is optional and must be a string formatted as an ISO 8601 timestamp.
    /// </remarks>
    [JsonPropertyName("update_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string UpdateTime { get; set; }
}