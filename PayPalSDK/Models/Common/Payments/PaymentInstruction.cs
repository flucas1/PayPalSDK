using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents payment instructions in the PayPal SDK.
/// </summary>
[DataContract]
public class PaymentInstruction
{
    /// <summary>
    /// Gets or sets the list of platform fees associated with the payment instruction.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the fees charged by the platform.
    /// </remarks>
    [JsonPropertyName("platform_fees")]
    public List<PlatformFee>? PlatformFees { get; set; }

    /// <summary>
    /// Gets or sets the payee pricing tier ID.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 20 characters.
    /// </remarks>
    [JsonPropertyName("payee_pricing_tier_id")]
    [StringLength(20)]
    public string? PayeePricingTierId { get; set; }

    /// <summary>
    /// Gets or sets the payee receivable foreign exchange rate ID.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 4000 characters.
    /// </remarks>
    [JsonPropertyName("payee_receivable_fx_rate_id")]
    [StringLength(4000)]
    public string? PayeeReceivableFxRateId { get; set; }

    /// <summary>
    /// Gets or sets the disbursement mode.
    /// </summary>
    /// <remarks>
    /// This field is optional and must match the regular expression ^[A-Z_]+$.
    /// Refer to <see cref="Tavstal.PayPalSDK.Constants.DisbursementMode"/> for valid values.
    /// </remarks>
    [JsonPropertyName("disbursement_mode")]
    [StringLength(16)]
    [RegularExpression("^[A-Z_]+$")]
    public string? DisbursementMode { get; set; }
}