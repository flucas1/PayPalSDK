using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents the body of a request to capture a subscription payment.
/// </summary>
[DataContract]
public class SubscriptionCaptureRequestBody
{
    /// <summary>
    /// Gets or sets the note associated with the capture request.
    /// </summary>
    /// <remarks>
    /// The note must not exceed 128 characters.
    /// </remarks>
    [JsonPropertyName("note")]
    [StringLength(128)]
    public required string Note { get; set; }

    /// <summary>
    /// Gets or sets the type of capture for the subscription payment.
    /// </summary>
    /// <remarks>
    /// The capture type must not exceed 24 characters.
    /// </remarks>
    [JsonPropertyName("capture_type")]
    [StringLength(24)]
    public required string CaptureType { get; set; }

    /// <summary>
    /// Gets or sets the amount to be captured for the subscription payment.
    /// </summary>
    /// <remarks>
    /// The amount is represented as a <see cref="Money"/> object.
    /// </remarks>
    [JsonPropertyName("amount")]
    public required Money Amount { get; set; }
}