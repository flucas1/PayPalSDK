using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common.PaymentMethodTokens;
using Tavstal.PayPalSDK.Models.PaymentMethodTokens.Bodies;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.PaymentMethodTokens;

/// <summary>
/// Represents an HTTP request to create a setup token in the PayPal Vault API.
/// </summary>
public class PaymentTokenSetupCreateRequest : HttpRequestBase<PaymentTokenSetup>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentTokenSetupCreateRequest"/> class
    /// with the payload required to create a setup token.
    /// </summary>
    /// <param name="body">The request body containing payment source and optional customer information.</param>
    public PaymentTokenSetupCreateRequest(PaymentTokenCreateRequestBody body) 
        : base(HttpMethod.Post, $"/v3/vault/setup-tokens")
    {
        Content = JsonContent.Create(body, PayPalSDKJsonContext.Default.PaymentTokenCreateRequestBody);
    }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="PaymentTokenSetupCreateRequest"/> for method chaining.</returns>
    public PaymentTokenSetupCreateRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
    
}