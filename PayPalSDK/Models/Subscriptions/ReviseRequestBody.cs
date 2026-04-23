using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.Plans;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the body of a request to revise a subscription.
/// </summary>
[DataContract]
public class ReviseRequestBody
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
    /// The quantity must not exceed 36 characters.
    /// </remarks>
    [JsonPropertyName("quantity")]
    [StringLength(36)]
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
    /// Gets or sets the application context for the subscription.
    /// </summary>
    /// <remarks>
    /// The application context provides additional configuration for the subscription.
    /// </remarks>
    [JsonPropertyName("application_context")]
    public ApplicationContext ApplicationContext { get; set; }

    /// <summary>
    /// Gets or sets the details of the subscription plan.
    /// </summary>
    /// <remarks>
    /// The plan is represented as a <see cref="SubscriberPlan"/> object.
    /// </remarks>
    [JsonPropertyName("plan")]
    public SubscriberPlan Plan { get; set; }
}