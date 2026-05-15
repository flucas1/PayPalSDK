using Tavstal.PayPalSDK.Http;

namespace Tavstal.PayPalSDK.Models.Payments;

/// <summary>
/// Represents a request to retrieve the details of a captured payment.
/// </summary>
public class PaymentGetCapturedDetailsRequest : HttpRequestBase<CapturedPaymentBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentGetCapturedDetailsRequest"/> class.
    /// </summary>
    /// <param name="captureId">The unique identifier of the captured payment.</param>
    public PaymentGetCapturedDetailsRequest(string captureId)
        :
        base(HttpMethod.Get, $"/v2/payments/captures/{captureId}")
    {
        // No additional content is needed for a GET request
    }
}