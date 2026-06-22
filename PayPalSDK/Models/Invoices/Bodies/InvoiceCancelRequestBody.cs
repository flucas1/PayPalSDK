using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices.Bodies;

/// <summary>
/// Represents the request body used to cancel an invoice in the PayPal Invoicing API.
/// </summary>
[DataContract]
public class InvoiceCancelRequestBody
{
    /// <summary>
    /// Gets or sets a value indicating whether a notification should be sent to the invoicer.
    /// </summary>
    [JsonPropertyName("send_to_invoicer")]
    public bool SendToInvoicer { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether a notification should be sent to the recipient.
    /// </summary>
    [JsonPropertyName("send_to_recipient")]
    public bool SendToRecipient { get; set; }
    
    /// <summary>
    /// Gets or sets the list of additional recipient email addresses.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public List<string>? AdditionalRecipients { get; set; }
}