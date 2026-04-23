using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents tax information for a payment.
/// </summary>
[DataContract]
public class Tax
{
    /// <summary>
    /// Gets or sets the name of the tax.
    /// </summary>
    /// <remarks>
    /// The name must not exceed 100 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(100)]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets additional notes about the tax.
    /// </summary>
    /// <remarks>
    /// The tax note must not exceed 40 characters.
    /// </remarks>
    [JsonPropertyName("tax_note")]
    [StringLength(40)]
    public string TaxNote { get; set; }

    /// <summary>
    /// Gets or sets the percentage value of the tax.
    /// </summary>
    /// <remarks>
    /// The percentage must match the specified regular expression pattern for numeric values.
    /// </remarks>
    [JsonPropertyName("percent")]
    [RegularExpression("^((-?[0-9]+)|(-?([0-9]+)?[.][0-9]+))$")]
    public required string Percent { get; set; }
}