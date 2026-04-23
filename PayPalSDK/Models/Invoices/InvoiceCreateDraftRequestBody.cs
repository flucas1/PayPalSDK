using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Invoices;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Payments;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents the request body for creating a draft invoice, including recipients, items, details, configuration, and payment information.
/// </summary>
[DataContract]
public class InvoiceCreateDraftRequestBody
{
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
    /// Gets or sets the list of authorized payments associated with the invoice.
    /// </summary>
    [JsonPropertyName("payments")]
    public List<AuthorizedPaymentBody> Payments { get; set; }

    /// <summary>
    /// Gets or sets the list of refund payments associated with the invoice.
    /// </summary>
    [JsonPropertyName("refunds")]
    public List<RefundPaymentBody> Refunds { get; set; }
}