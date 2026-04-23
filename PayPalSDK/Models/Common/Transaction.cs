using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a transaction in the PayPal SDK.
/// </summary>
[DataContract]
public class Transaction
{
    /// <summary>
    /// Gets or sets the status of the transaction.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the transaction.
    /// </summary>
    [JsonPropertyName("id")]
    [StringLength(50)]
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the amount breakdown for the transaction.
    /// </summary>
    [JsonPropertyName("amount_with_breakdown")]
    public required AmountBreakdown AmountWithBreakdown { get; set; }

    /// <summary>
    /// Gets or sets the name information of the payer.
    /// </summary>
    [JsonPropertyName("payer_name")]
    public NameInfo PayerName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the payer.
    /// </summary>
    [JsonPropertyName("payer_email")]
    [StringLength(254)]
    [RegularExpression("^.+@[^\"\\-].+$")]
    public string PayerEmail { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the transaction in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public required string Time { get; set; }
}