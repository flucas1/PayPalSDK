using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents a discount applied to an invoice.
/// </summary>
[DataContract]
public class Discount
{
    /// <summary>
    /// Gets or sets the percentage value of the discount.
    /// </summary>
    /// <remarks>
    /// The percentage must match the specified regular expression pattern for numeric values.
    /// </remarks>
    [JsonPropertyName("percent")]
    [RegularExpression("^((-?[0-9]+)|(-?([0-9]+)?[.][0-9]+))$")]
    public string Percent { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount of the discount.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }
}