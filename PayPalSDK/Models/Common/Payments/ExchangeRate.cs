using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the exchange rate details for a payment transaction.
/// </summary>
[DataContract]
public class ExchangeRate
{
    /// <summary>
    /// The exchange rate value as a string.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// The source currency code in ISO 4217 format (3 characters).
    /// </summary>
    [JsonPropertyName("source_currency")]
    [StringLength(3)]
    public string? SourceCurrency { get; set; }

    /// <summary>
    /// The target currency code in ISO 4217 format (3 characters).
    /// </summary>
    [JsonPropertyName("target_currency")]
    [StringLength(3)]
    public string? TargetCurrency { get; set; }
}