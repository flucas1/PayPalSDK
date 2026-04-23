using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents an item in an invoice.
/// </summary>
[DataContract]
public class InvoiceItem
{
    /// <summary>
    /// Gets or sets the name of the invoice item.
    /// </summary>
    /// <remarks>
    /// The name must not exceed 200 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the invoice item.
    /// </summary>
    /// <remarks>
    /// The description must not exceed 1000 characters.
    /// </remarks>
    [JsonPropertyName("description")]
    [StringLength(1000)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the invoice item.
    /// </summary>
    /// <remarks>
    /// The quantity must not exceed 14 characters.
    /// </remarks>
    [JsonPropertyName("quantity")]
    [StringLength(14)]
    public required string Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit amount of the invoice item.
    /// </summary>
    [JsonPropertyName("unit_amount")]
    public required Money UnitAmount { get; set; }

    /// <summary>
    /// Gets or sets the tax information for the invoice item.
    /// </summary>
    [JsonPropertyName("tax")]
    public Tax Tax { get; set; }

    /// <summary>
    /// Gets or sets the date of the invoice item.
    /// </summary>
    /// <remarks>
    /// The date must be in the format YYYY-MM-DD.
    /// </remarks>
    [JsonPropertyName("item_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string ItemDate { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the invoice item.
    /// </summary>
    [JsonPropertyName("discount")]
    public Discount Discount { get; set; }

    /// <summary>
    /// Gets or sets the unit of measure for the invoice item.
    /// </summary>
    [JsonPropertyName("unit_of_measure")]
    public string UnitOfMeasure { get; set; }
}