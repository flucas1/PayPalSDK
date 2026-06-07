using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents an HTTP request for updating a PayPal invoice.
/// </summary>
public class InvoiceUpdateRequest : HttpRequestBase<InvoiceBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceUpdateRequest"/> class.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice to be updated.</param>
    /// <param name="body">The request body containing the updated invoice details.</param>
    /// <param name="sendToRecipient">Indicates whether the updated invoice should be sent to the recipient. Defaults to true.</param>
    /// <param name="sendToInvoicer">Indicates whether the updated invoice should be sent to the invoicer. Defaults to true.</param>
    public InvoiceUpdateRequest(string invoiceId, InvoiceUpdateRequestBody body, bool sendToRecipient = true, bool sendToInvoicer = true)
        :
        base(HttpMethod.Put, $"/v2/invoicing/invoices/{invoiceId}")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<InvoiceUpdateRequestBody>(body, PayPalSDKSerializerContext.Default.InvoiceUpdateRequestBody);
    }
}