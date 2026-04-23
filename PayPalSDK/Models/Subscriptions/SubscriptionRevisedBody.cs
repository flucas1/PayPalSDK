using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.Plans;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the revised body of a subscription request.
/// </summary>
[DataContract]
public class SubscriptionRevisedBody
{
    /// <summary>
    /// Gets or sets the unique identifier of the subscription plan.
    /// </summary>
    /// <remarks>
    /// The plan ID must not exceed 26 characters.
    /// </remarks>
    [JsonPropertyName("plan_id")]
    [StringLength(26)]
    public string PlanId { get; set; }

    /// <summary>
    /// Gets or sets the quantity associated with the subscription.
    /// </summary>
    /// <remarks>
    /// The quantity must not exceed 32 characters.
    /// </remarks>
    [JsonPropertyName("quantity")]
    [StringLength(32)]
    public string Quantity { get; set; }

    /// <summary>
    /// Gets or sets the shipping amount for the subscription.
    /// </summary>
    /// <remarks>
    /// The shipping amount is represented as a <see cref="Money"/> object.
    /// </remarks>
    [JsonPropertyName("shipping_amount")]
    public Money ShippingAmount { get; set; }

    /// <summary>
    /// Gets or sets the shipping address for the subscription.
    /// </summary>
    /// <remarks>
    /// The shipping address is represented as a <see cref="Shipping"/> object.
    /// </remarks>
    [JsonPropertyName("shipping_address")]
    public Shipping ShippingAddress { get; set; }

    /// <summary>
    /// Gets or sets the details of the subscription plan.
    /// </summary>
    /// <remarks>
    /// The plan is represented as a <see cref="SubscriberPlan"/> object.
    /// </remarks>
    [JsonPropertyName("plan")]
    public SubscriberPlan Plan { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the plan has been overridden.
    /// </summary>
    [JsonPropertyName("plan_overriden")]
    public bool PlanOverriden { get; set; }

    /// <summary>
    /// Gets or sets the list of links associated with the subscription.
    /// </summary>
    /// <remarks>
    /// Each link is represented as a <see cref="Link"/> object.
    /// </remarks>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }
}