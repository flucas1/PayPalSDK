using System.ComponentModel.DataAnnotations;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common.PaymentMethodTokens;

namespace Tavstal.PayPalSDK.Models.PaymentMethodTokens;

/// <summary>
/// Represents an HTTP request to retrieve a specific setup token
/// from the PayPal Vault API by its identifier.
/// </summary>
public class PaymentTokenSetupRetrieveRequest : HttpRequestBase<PaymentTokenSetup>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentTokenSetupRetrieveRequest"/> class.
    /// </summary>
    /// <param name="id">
    /// The unique setup token identifier to retrieve.
    /// Must not exceed 36 characters.
    /// </param>
    public PaymentTokenSetupRetrieveRequest([StringLength(36)] string id) 
        : base(HttpMethod.Get, $"/v3/vault/setup-tokens/{id}") { }

    /// <summary>
    /// Adds the PayPal Partner Attribution ID header to the request.
    /// </summary>
    /// <param name="paypalPartnerAttributionId">The PayPal Partner Attribution ID to be added.</param>
    /// <returns>The current instance of <see cref="PaymentTokenSetupRetrieveRequest"/> for method chaining.</returns>
    public PaymentTokenSetupRetrieveRequest PaypalPartnerAttributionId(string paypalPartnerAttributionId)
    {
        Headers.Add("PayPal-Partner-Attribution-Id", paypalPartnerAttributionId);
        return this;
    }
    
}