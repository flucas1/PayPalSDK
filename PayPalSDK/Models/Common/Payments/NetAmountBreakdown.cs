using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the breakdown of the net amount in a payment transaction.
/// </summary>
[DataContract]
public class NetAmountBreakdown
{
    /// <summary>
    /// The amount payable in the transaction.
    /// </summary>
    [JsonPropertyName("payable_amount")]
    public Money PayableAmount { get; set; }

    /// <summary>
    /// The converted amount in the transaction's currency.
    /// </summary>
    [JsonPropertyName("converted_amount")]
    public Money ConvertedAmount { get; set; }

    /// <summary>
    /// The exchange rate details used for the conversion.
    /// </summary>
    [JsonPropertyName("exchange_rate")]
    public ExchangeRate ExchangeRate { get; set; }
}