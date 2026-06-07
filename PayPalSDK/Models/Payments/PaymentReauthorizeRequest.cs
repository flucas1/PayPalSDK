using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Payments;

/// <summary>
/// Represents a request to reauthorize a payment authorization.
/// </summary>
public class PaymentReauthorizeRequest : HttpRequestBase<CapturedPaymentBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentReauthorizeRequest"/> class.
    /// </summary>
    /// <param name="authorizationId">The unique identifier of the payment authorization to be reauthorized.</param>
    /// <param name="body">The body of the payment reauthorization request containing reauthorization details. Optional.</param>
    public PaymentReauthorizeRequest(string authorizationId, PaymentReauthorizeRequestBody? body = null)
        :
        base(HttpMethod.Post, $"/v2/payments/authorizations/{authorizationId}/reauthorize")
    {
        if (body == null)
            return;

        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<PaymentReauthorizeRequestBody>(body, PayPalSDKSerializerContext.Default.PaymentReauthorizeRequestBody);
    }
}