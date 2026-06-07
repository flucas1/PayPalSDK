using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents a request to create a draft invoice.
/// </summary>
public class InvoiceCreateDraftRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceCreateDraftRequest"/> class.
    /// </summary>
    /// <param name="body">The body of the request containing the details of the draft invoice.</param>
    /// <remarks>
    /// This request uses the HTTP POST method and sets the request content using JSON serialization.
    /// Null values in the body are ignored during serialization.
    /// </remarks>
    public InvoiceCreateDraftRequest(InvoiceCreateDraftRequestBody body)
        : base(HttpMethod.Post, "/v2/invoicing/invoices")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<InvoiceCreateDraftRequestBody>(body, PayPalSDKSerializerContext.Default.InvoiceCreateDraftRequestBody);
    }
}