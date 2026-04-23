using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the breakdown of an amount in a transaction.
/// </summary>
[DataContract]
public class AmountBreakdown
{
    /// <summary>
    /// Gets or sets the gross amount of the transaction.
    /// </summary>
    [JsonPropertyName("gross_amount")]
    public required Money GrossAmount { get; set; }

    /// <summary>
    /// Gets or sets the total item amount in the transaction.
    /// </summary>
    [JsonPropertyName("total_item_amount")]
    public Money TotalItemAmount { get; set; }

    /// <summary>
    /// Gets or sets the fee amount associated with the transaction.
    /// </summary>
    [JsonPropertyName("fee_amount")]
    public Money FeeAmount { get; set; }

    /// <summary>
    /// Gets or sets the shipping amount for the transaction.
    /// </summary>
    [JsonPropertyName("shipping_amount")]
    public Money ShippingAmount { get; set; }

    /// <summary>
    /// Gets or sets the tax amount for the transaction.
    /// </summary>
    [JsonPropertyName("tax_amount")]
    public Money TaxAmount { get; set; }

    /// <summary>
    /// Gets or sets the net amount of the transaction after deductions.
    /// </summary>
    [JsonPropertyName("net_amount")]
    public Money NetAmount { get; set; }
}