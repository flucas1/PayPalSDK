using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Billing;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.Plans;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the body of a subscription request or response.
/// </summary>
[DataContract]
public class SubscriptionBody
{
    /// <summary>
    /// Gets or sets the status of the subscription.
    /// </summary>
    /// <remarks>
    /// The status can have a maximum length of 24 characters.
    /// </remarks>
    [JsonPropertyName("status")]
    [StringLength(24)]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the note associated with a status change.
    /// </summary>
    /// <remarks>
    /// The note can have a maximum length of 128 characters.
    /// </remarks>
    [JsonPropertyName("status_change_note")]
    [StringLength(128)]
    public string StatusChangeNote { get; set; }

    /// <summary>
    /// Gets or sets the time when the status was last updated.
    /// </summary>
    /// <remarks>
    /// The time must follow the format "YYYY-MM-DDTHH:mm:ss.sssZ" or include a timezone offset.
    /// </remarks>
    [JsonPropertyName("status_update_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string StatusUpdateTime { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the subscription.
    /// </summary>
    /// <remarks>
    /// The ID can have a maximum length of 50 characters.
    /// </remarks>
    [JsonPropertyName("id")]
    [StringLength(50)]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the subscription plan.
    /// </summary>
    /// <remarks>
    /// The plan ID can have a maximum length of 50 characters.
    /// </remarks>
    [JsonPropertyName("plan_id")]
    [StringLength(50)]
    public string PlanId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the subscription plan.
    /// </summary>
    /// <remarks>
    /// The quantity can have a maximum length of 32 characters.
    /// </remarks>
    [JsonPropertyName("quantity")]
    [StringLength(32)]
    public string Quantity { get; set; }

    /// <summary>
    /// Gets or sets a custom identifier for the subscription.
    /// </summary>
    /// <remarks>
    /// The custom ID can have a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("custom_id")]
    [StringLength(127)]
    public string CustomId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the plan has been overridden.
    /// </summary>
    [JsonPropertyName("plan_overridden")]
    public bool PlanOverridden { get; set; }

    /// <summary>
    /// Gets or sets the list of links associated with the subscription.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    /// <summary>
    /// Gets or sets the start time of the subscription.
    /// </summary>
    /// <remarks>
    /// The start time must follow the format "YYYY-MM-DDTHH:mm:ss.sssZ" or include a timezone offset.
    /// </remarks>
    [JsonPropertyName("start_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string StartTime { get; set; }

    /// <summary>
    /// Gets or sets the shipping amount for the subscription.
    /// </summary>
    [JsonPropertyName("shipping_amount")]
    public Money ShippingAmount { get; set; }

    /// <summary>
    /// Gets or sets the subscriber's information.
    /// </summary>
    [JsonPropertyName("subscriber")]
    public Subscriber Subscriber { get; set; }

    /// <summary>
    /// Gets or sets the billing information for the subscription.
    /// </summary>
    [JsonPropertyName("billing_info")]
    public BillingInfo BillingInfo { get; set; }

    /// <summary>
    /// Gets or sets the creation time of the subscription.
    /// </summary>
    /// <remarks>
    /// The creation time must follow the format "YYYY-MM-DDTHH:mm:ss.sssZ" or include a timezone offset.
    /// </remarks>
    [JsonPropertyName("create_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string CreateTime { get; set; }

    /// <summary>
    /// Gets or sets the last update time of the subscription.
    /// </summary>
    /// <remarks>
    /// The update time must follow the format "YYYY-MM-DDTHH:mm:ss.sssZ" or include a timezone offset.
    /// </remarks>
    [JsonPropertyName("update_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string UpdateTime { get; set; }

    /// <summary>
    /// Gets or sets the details of the subscription plan.
    /// </summary>
    [JsonPropertyName("plan")]
    public PlanBody Plan { get; set; }
}