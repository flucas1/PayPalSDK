using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents tax information for payments in the PayPal SDK.
/// </summary>
[DataContract]
public class Taxes
{
    /// <summary>
    /// Gets or sets a value indicating whether the tax is inclusive.
    /// </summary>
    /// <remarks>
    /// This field specifies if the tax is included in the total amount.
    /// </remarks>
    [JsonPropertyName("inclusive")]
    public bool Inclusive { get; set; }

    /// <summary>
    /// Gets or sets the percentage of the tax.
    /// </summary>
    /// <remarks>
    /// This field must be a valid numeric value, including integers or decimals.
    /// </remarks>
    [JsonPropertyName("percentage")]
    [RegularExpression("^((-?[0-9]+)|(-?([0-9]+)?[.][0-9]+))$")]
    public required string Percentage { get; set; }
}