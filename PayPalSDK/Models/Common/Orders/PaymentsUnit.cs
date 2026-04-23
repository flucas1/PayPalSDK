using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Orders;

/// <summary>
/// Represents the payments information for a purchase unit, including authorizations, captures, and refunds.
/// </summary>
[DataContract]
public class PaymentsUnit
{
    /// <summary>
    /// Gets or sets the list of payment authorizations associated with the purchase unit.
    /// </summary>
    /// <remarks>
    /// This property contains details of all payment authorizations.
    /// </remarks>
    [JsonPropertyName("authorizations")]
    public List<PaymentAuthorization> Authorizations { get; set; }

    /// <summary>
    /// Gets or sets the list of payment captures associated with the purchase unit.
    /// </summary>
    /// <remarks>
    /// This property contains details of all payment captures.
    /// </remarks>
    [JsonPropertyName("captures")]
    public List<PaymentCapture> Captures { get; set; }

    /// <summary>
    /// Gets or sets the list of payment refunds associated with the purchase unit.
    /// </summary>
    /// <remarks>
    /// This property contains details of all payment refunds.
    /// </remarks>
    [JsonPropertyName("refunds")]
    public List<RefundPaymentBody> Refunds { get; set; }
}