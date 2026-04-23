using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents the configuration options for an invoice, including tax calculation, tipping, partial payments, and template selection.
/// </summary>
[DataContract]
public class InvoiceConfig
{
    /// <summary>
    /// Gets or sets a value indicating whether tax is calculated after discounts are applied.
    /// </summary>
    [JsonPropertyName("tax_calculated_after_discount")]
    public bool TaxCalculatedAfterDiscount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the tax is inclusive in the invoice amounts.
    /// </summary>
    [JsonPropertyName("tax_inclusive")]
    public bool TaxInclusive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether tipping is allowed on the invoice.
    /// </summary>
    [JsonPropertyName("allow_tip")]
    public bool AllowTip { get; set; }

    /// <summary>
    /// Gets or sets the partial payment options for the invoice.
    /// </summary>
    [JsonPropertyName("partial_payment")]
    public PartialPayment PartialPayment { get; set; }

    /// <summary>
    /// Gets or sets the template ID used for the invoice.
    /// </summary>
    /// <remarks>
    /// The template ID must not exceed 30 characters.
    /// </remarks>
    [JsonPropertyName("template_id")]
    [StringLength(30)]
    public string TemplateId { get; set; }
}