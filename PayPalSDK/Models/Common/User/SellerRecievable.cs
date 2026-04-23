using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents the seller receivable details in a PayPal transaction.
/// </summary>
[DataContract]
public class SellerRecievable
{
    /// <summary>
    /// A list of platform fees associated with the transaction.
    /// </summary>
    [JsonPropertyName("platform_fees")]
    public List<PlatformFee> PlatformFees { get; set; }

    /// <summary>
    /// The gross amount of the transaction.
    /// </summary>
    [JsonPropertyName("gross_amount")]
    public required Money GrossAmount { get; set; }

    /// <summary>
    /// The PayPal fee deducted from the transaction.
    /// </summary>
    [JsonPropertyName("paypal_fee")]
    public Money PaypalFee { get; set; }

    /// <summary>
    /// The PayPal fee in the receivable currency.
    /// </summary>
    [JsonPropertyName("paypal_fee_in_receivable_currency")]
    public Money PaypalFeeInReceivableCurrency { get; set; }

    /// <summary>
    /// The net amount after deductions.
    /// </summary>
    [JsonPropertyName("net_amount")]
    public Money NetAmount { get; set; }

    /// <summary>
    /// The amount receivable by the seller.
    /// </summary>
    [JsonPropertyName("receivable_amount")]
    public Money ReceivableAmount { get; set; }

    /// <summary>
    /// The exchange rate details for the transaction.
    /// </summary>
    [JsonPropertyName("exchange_rate")]
    public ExchangeRate ExchangeRate { get; set; }
}