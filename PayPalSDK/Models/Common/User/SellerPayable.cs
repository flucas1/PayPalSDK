using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents the details of the seller's payable amounts in a transaction.
/// </summary>
[DataContract]
public class SellerPayable
{
    /// <summary>
    /// A list of platform fees associated with the transaction.
    /// </summary>
    [JsonPropertyName("platform_fees")]
    public List<PlatformFee> PlatformFees { get; set; }

    /// <summary>
    /// A breakdown of the net amount in the transaction.
    /// </summary>
    [JsonPropertyName("net_amount_breakdown")]
    public List<NetAmountBreakdown> NetAmountBreakdown { get; set; }

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
    /// The net amount in the receivable currency after deductions.
    /// </summary>
    [JsonPropertyName("net_amount_in_receivable_currency")]
    public Money NetAmountInReceivableCurrency { get; set; }

    /// <summary>
    /// The total refunded amount in the transaction.
    /// </summary>
    [JsonPropertyName("total_refunded_amount")]
    public Money TotalRefundedAmount { get; set; }
}