using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents the request body for sending a PayPal invoice, including subject, note, recipient options, and additional recipients.
/// </summary>
[DataContract]
public class InvoiceSendRequestBody
{
    /// <summary>
    /// Gets or sets the subject line of the email sent to recipients.
    /// </summary>
    /// <remarks>
    /// The subject must not exceed 4000 characters.
    /// </remarks>
    [JsonPropertyName("subject")]
    [StringLength(4000)]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the note to include in the email sent to recipients.
    /// </summary>
    /// <remarks>
    /// The note must not exceed 4000 characters.
    /// </remarks>
    [JsonPropertyName("note")]
    [StringLength(4000)]
    public string Note { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to send the invoice to the invoicer.
    /// </summary>
    [JsonPropertyName("send_to_invoicer")]
    public bool SendToInvoicer { get; set; } 

    /// <summary>
    /// Gets or sets a value indicating whether to send the invoice to the recipient.
    /// </summary>
    [JsonPropertyName("send_to_recipient")]
    public bool SendToRecipient { get; set; }

    /// <summary>
    /// Gets or sets the list of additional recipient email addresses.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public List<string> AdditionalRecipients { get; set; }
}