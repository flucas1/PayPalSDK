using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Payments;

/// <summary>
/// Represents the body of a refunded payment transaction.
/// </summary>
[DataContract]
public class RefundPaymentBody
{
    /// <summary>
    /// The status of the payment transaction.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Details about the payment status, including the reason for the status.
    /// </summary>
    [JsonPropertyName("status_details")]
    public StatusDetails StatusDetails { get; set; }

    /// <summary>
    /// The unique identifier for the payment transaction.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The invoice ID associated with the payment transaction.
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public string InvoiceId { get; set; }

    /// <summary>
    /// A custom ID provided by the merchant for the payment transaction.
    /// Maximum length is 255 characters.
    /// </summary>
    [JsonPropertyName("custom_id")]
    [StringLength(255)]
    public string CustomId { get; set; }

    /// <summary>
    /// The acquirer reference number for the payment transaction.
    /// Maximum length is 36 characters.
    /// </summary>
    [JsonPropertyName("acquirer_reference_number")]
    [StringLength(36)]
    public string AcquirerReferenceNumber { get; set; }

    /// <summary>
    /// A note provided to the payer for the payment transaction.
    /// </summary>
    [JsonPropertyName("note_to_payer")]
    public string NoteToPayer { get; set; }

    /// <summary>
    /// Breakdown of the seller's payable amounts in the transaction.
    /// </summary>
    [JsonPropertyName("seller_payable_breakdown")]
    public SellerPayable SellerPayableBreakdown { get; set; }

    /// <summary>
    /// A list of links related to the payment transaction.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    /// <summary>
    /// The monetary amount of the payment transaction.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }

    /// <summary>
    /// Information about the payer in the payment transaction.
    /// </summary>
    [JsonPropertyName("payer")]
    public Payee Payer { get; set; }

    /// <summary>
    /// The creation time of the payment transaction in ISO 8601 format.
    /// Must match the specified regular expression.
    /// </summary>
    [JsonPropertyName("create_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string CreateTime { get; set; }

    /// <summary>
    /// The last update time of the payment transaction in ISO 8601 format.
    /// Must match the specified regular expression.
    /// </summary>
    [JsonPropertyName("update_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string UpdateTime { get; set; }
}