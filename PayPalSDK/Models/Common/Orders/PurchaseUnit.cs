using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments;

namespace Tavstal.PayPalSDK.Models.Common.Orders;

/// <summary>
/// Represents a purchase unit in the PayPal SDK.
/// </summary>
[DataContract]
public class PurchaseUnit
{
    /// <summary>
    /// Gets or sets the reference ID for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 256 characters.
    /// </remarks>
    [JsonPropertyName("reference_id")]
    [StringLength(256)]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Gets or sets the description of the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("description")]
    [StringLength(127)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the custom ID for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 255 characters.
    /// </remarks>
    [JsonPropertyName("custom_id")]
    [StringLength(255)]
    public string? CustomId { get; set; }

    /// <summary>
    /// Gets or sets the invoice ID for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 127 characters.
    /// </remarks>
    [JsonPropertyName("invoice_id")]
    [StringLength(127)]
    public string? InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the soft descriptor for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 22 characters.
    /// </remarks>
    [JsonPropertyName("soft_descriptor")]
    [StringLength(22)]
    public string? SoftDescriptor { get; set; }

    /// <summary>
    /// Gets or sets the list of items in the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the items included in the purchase unit.
    /// </remarks>
    [JsonPropertyName("items")]
    public List<Item>? Items { get; set; }

    /// <summary>
    /// Gets or sets the monetary breakdown of the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the amount details for the purchase unit.
    /// </remarks>
    [JsonPropertyName("amount")]
    public required MoneyBreakdown Amount { get; set; }

    /// <summary>
    /// Gets or sets the payee information for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the recipient of the payment.
    /// </remarks>
    [JsonPropertyName("payee")]
    public Payee? Payee { get; set; }

    /// <summary>
    /// Gets or sets the payment instructions for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents specific payment instructions.
    /// </remarks>
    [JsonPropertyName("payment_instruction")]
    public PaymentInstruction? PaymentInstruction { get; set; }

    /// <summary>
    /// Gets or sets the shipping information for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the shipping details for the purchase unit.
    /// </remarks>
    [JsonPropertyName("shipping")]
    public Shipping? Shipping { get; set; }

    /// <summary>
    /// Gets or sets the supplementary data for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents additional data related to the purchase unit.
    /// </remarks>
    [JsonPropertyName("supplementary_data")]
    public SupplementaryData? SupplementaryData { get; set; }
    
    /// <summary>
    /// Gets or sets the payments information for the purchase unit.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the details of payments associated with the purchase unit.
    /// </remarks>
    [JsonPropertyName("payments")]
    public PaymentsUnit? Payments { get; set; }
}