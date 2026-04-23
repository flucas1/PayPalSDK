using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Invoices;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents the full details of a PayPal invoice, including recipients, items, status, configuration, payments, and refunds.
/// </summary>
[DataContract]
public class InvoiceBody
{
    /// <summary>
    /// Gets or sets the unique identifier of the invoice.
    /// </summary>
    [JsonPropertyName("id")]
    [StringLength(30)]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the parent invoice ID, if this invoice is related to another invoice.
    /// </summary>
    [JsonPropertyName("parent_id")]
    [StringLength(30)]
    public string ParentId { get; set; }

    /// <summary>
    /// Gets or sets the list of primary recipients for the invoice.
    /// </summary>
    [JsonPropertyName("primary_recipients")]
    public List<Recipient> PrimaryRecipients { get; set; }

    /// <summary>
    /// Gets or sets the list of additional recipient email addresses.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public List<string> AdditionalRecipients { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the invoice.
    /// </summary>
    [JsonPropertyName("items")]
    public List<InvoiceItem> Items { get; set; }

    /// <summary>
    /// Gets or sets the list of related links for the invoice.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    /// <summary>
    /// Gets or sets the current status of the invoice.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the detailed information for the invoice.
    /// </summary>
    [JsonPropertyName("detail")]
    public required Detail Detail { get; set; }

    /// <summary>
    /// Gets or sets the invoicer information for the invoice.
    /// </summary>
    [JsonPropertyName("invoicer")]
    public Invoicer Invoicer { get; set; }

    /// <summary>
    /// Gets or sets the configuration options for the invoice.
    /// </summary>
    [JsonPropertyName("configuration")]
    public InvoiceConfig Configuration { get; set; }

    /// <summary>
    /// Gets or sets the total amount breakdown for the invoice.
    /// </summary>
    [JsonPropertyName("amount")]
    public MoneyBreakdown Amount { get; set; }

    /// <summary>
    /// Gets or sets the amount due for the invoice.
    /// </summary>
    [JsonPropertyName("due_amount")]
    public Money DueAmount { get; set; }

    /// <summary>
    /// Gets or sets the gratuity (tip) amount for the invoice.
    /// </summary>
    [JsonPropertyName("gratuity")]
    public Money Gratuity { get; set; }

    /// <summary>
    /// Gets or sets the list of payments made towards the invoice.
    /// </summary>
    [JsonPropertyName("payments")]
    public List<InvoicePayment> Payments { get; set; }

    /// <summary>
    /// Gets or sets the list of refunds issued for the invoice.
    /// </summary>
    [JsonPropertyName("refunds")]
    public List<InvoiceRefund> Refunds { get; set; }
}