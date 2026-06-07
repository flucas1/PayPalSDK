using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents an HTTP request to send a PayPal invoice using the specified invoice ID and request body.
/// </summary>
public class InvoiceSendRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceSendRequest"/> class.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice to be sent.</param>
    /// <param name="body">The request body containing additional send options or information.</param>
    public InvoiceSendRequest(string invoiceId, InvoiceSendRequestBody body)
        : base(HttpMethod.Post, $"/v2/invoicing/invoices/{invoiceId}/send")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<InvoiceSendRequestBody>(body, PayPalSDKSerializerContext.Default.InvoiceSendRequestBody);
    }
}