using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents the processor response details for a payment transaction.
/// </summary>
[DataContract]
public class ProcessorResponse
{
    /// <summary>
    /// The Address Verification System (AVS) code returned by the processor.
    /// </summary>
    [JsonPropertyName("avs_code")]
    public string AvsCode { get; set; }

    /// <summary>
    /// The Card Verification Value (CVV) code returned by the processor.
    /// </summary>
    [JsonPropertyName("cvv_code")]
    public string CvvCode { get; set; }

    /// <summary>
    /// The response code returned by the processor.
    /// </summary>
    [JsonPropertyName("response_code")]
    public string ResponseCode { get; set; }

    /// <summary>
    /// The payment advice code returned by the processor.
    /// </summary>
    [JsonPropertyName("payment_advice_code")]
    public string PaymentAdviceCode { get; set; }
}