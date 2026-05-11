using System.ComponentModel.DataAnnotations;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the exchange rate details for a payment transaction.
/// </summary>
public class ExchangeRate
{
    /// <summary>
    /// The exchange rate value as a string.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// The source currency code in ISO 4217 format (3 characters).
    /// </summary>
    [StringLength(3)]
    public string? SourceCurrency { get; set; }

    /// <summary>
    /// The target currency code in ISO 4217 format (3 characters).
    /// </summary>
    [StringLength(3)]
    public string? TargetCurrency { get; set; }
}