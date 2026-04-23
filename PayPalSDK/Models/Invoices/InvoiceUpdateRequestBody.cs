using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Invoices;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Invoices;

/// <summary>
/// Represents the request body for updating a PayPal invoice, including recipients, items, details, and configuration.
/// </summary>
[DataContract]
public class InvoiceUpdateRequestBody
{
    /// <summary>
    /// Gets or sets the list of primary recipients for the invoice.
    /// </summary>
    [JsonPropertyName("primary_recipients")]
    public List<Recipient> PrimaryRecipients { get; set; }

    /// <summary>
    /// Gets or sets the list of additional recipients for the invoice.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public List<string> AdditionalRecipients { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the invoice.
    /// </summary>
    [JsonPropertyName("items")]
    public List<InvoiceItem> Items { get; set; }
    
    /// <summary>
    /// Gets or sets the detailed information about the invoice.
    /// </summary>
    [JsonPropertyName("detail")]
    public required Detail Detail { get; set; }

    /// <summary>
    /// Gets or sets the invoicer information for the invoice.
    /// </summary>
    [JsonPropertyName("invoicer")]
    public Invoicer Invoicer { get; set; }

    /// <summary>
    /// Gets or sets the configuration settings for the invoice.
    /// </summary>
    [JsonPropertyName("configuration")]
    public InvoiceConfig Configuration { get; set; }

    /// <summary>
    /// Gets or sets the breakdown of the total amount for the invoice.
    /// </summary>
    [JsonPropertyName("amount")]
    public MoneyBreakdown Amount { get; set; }
}