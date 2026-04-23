using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents the body of a request for sending a reminder for a PayPal invoice.
/// </summary>
[DataContract]
public class InvoiceSendReminderRequestBody
{
    /// <summary>
    /// Gets or sets the subject of the reminder email.
    /// </summary>
    [JsonPropertyName("subject")]
    [StringLength(4000)]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the note to be included in the reminder email.
    /// </summary>
    [JsonPropertyName("note")]
    [StringLength(4000)]
    public string Note { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the reminder should be sent to the invoicer.
    /// </summary>
    [JsonPropertyName("send_to_invoicer")]
    public bool SendToInvoicer { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the reminder should be sent to the recipient.
    /// </summary>
    [JsonPropertyName("send_to_recipient")]
    public bool SendToRecipient { get; set; }
    
    /// <summary>
    /// Gets or sets a list of additional recipients to receive the reminder.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public List<string> AdditionalRecipients { get; set; }
}