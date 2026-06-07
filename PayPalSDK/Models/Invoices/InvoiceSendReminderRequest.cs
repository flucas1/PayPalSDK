using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents an HTTP request for sending a reminder for a PayPal invoice.
/// </summary>
public class InvoiceSendReminderRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceSendReminderRequest"/> class.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice for which the reminder is being sent.</param>
    /// <param name="body">The request body containing the reminder details.</param>
    public InvoiceSendReminderRequest(string invoiceId, InvoiceSendReminderRequestBody body)
        :
        base(HttpMethod.Post, $"/v2/invoicing/invoices/{invoiceId}/remind")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<InvoiceSendReminderRequestBody>(body, PayPalSDKSerializerContext.Default.InvoiceSendReminderRequestBody);
    }
}