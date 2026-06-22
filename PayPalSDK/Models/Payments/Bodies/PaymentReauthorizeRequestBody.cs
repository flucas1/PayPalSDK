using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Payments.Bodies;

/// <summary>
/// Represents the body of a payment reauthorization request.
/// </summary>
[DataContract]
public class PaymentReauthorizeRequestBody
{
    /// <summary>
    /// The monetary amount to be reauthorized.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money? Amount { get; set; }
}