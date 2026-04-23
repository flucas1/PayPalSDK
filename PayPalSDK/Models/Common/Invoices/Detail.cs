using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents the detailed information of an invoice, including references, notes, terms, and attachments.
/// </summary>
[DataContract]
public class Detail
{
    /// <summary>
    /// Gets or sets the reference information for the invoice.
    /// </summary>
    /// <remarks>
    /// The reference must not exceed 120 characters.
    /// </remarks>
    [JsonPropertyName("reference")]
    [StringLength(120)]
    public string Reference { get; set; }

    /// <summary>
    /// Gets or sets the note associated with the invoice.
    /// </summary>
    /// <remarks>
    /// The note must not exceed 4000 characters.
    /// </remarks>
    [JsonPropertyName("note")]
    [StringLength(4000)]
    public string Note { get; set; }

    /// <summary>
    /// Gets or sets the terms and conditions for the invoice.
    /// </summary>
    [JsonPropertyName("terms_and_conditions")]
    public string TermsAndConditions { get; set; }
    
    /// <summary>
    /// Gets or sets the memo for the invoice.
    /// </summary>
    /// <remarks>
    /// The memo must not exceed 500 characters.
    /// </remarks>
    [JsonPropertyName("memo")]
    [StringLength(500)]
    public string Memo { get; set; }

    /// <summary>
    /// Gets or sets the list of attachments associated with the invoice.
    /// </summary>
    [JsonPropertyName("attachments")]
    public List<DetailAttachment> Attachments { get; set; }

    /// <summary>
    /// Gets or sets the currency code for the invoice.
    /// </summary>
    /// <remarks>
    /// The currency code must be a 3-character ISO 4217 code.
    /// </remarks>
    [JsonPropertyName("currency_code")]
    [StringLength(3)]
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the invoice number.
    /// </summary>
    /// <remarks>
    /// The invoice number must not exceed 25 characters.
    /// </remarks>
    [JsonPropertyName("invoice_number")]
    [StringLength(25)]
    public string InvoiceNumber { get; set; }

    /// <summary>
    /// Gets or sets the invoice date.
    /// </summary>
    /// <remarks>
    /// The date must be in the format YYYY-MM-DD.
    /// </remarks>
    [JsonPropertyName("invoice_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string InvoiceDate { get; set; }

    /// <summary>
    /// Gets or sets the payment term for the invoice.
    /// </summary>
    [JsonPropertyName("payment_term")]
    public PaymentTerm PaymentTerm { get; set; }
}