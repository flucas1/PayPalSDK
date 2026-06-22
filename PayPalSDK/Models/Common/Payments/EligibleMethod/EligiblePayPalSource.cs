using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

/// <summary>
/// Represents a PayPal payment source with customer identification information.
/// </summary>
[DataContract]
public class EligiblePayPalSource
{
    /// <summary>
    /// Gets or sets the email address associated with the PayPal account.
    /// </summary>
    /// <remarks>
    /// Must be a valid RFC 5322 compliant email address with a maximum length of 254 characters.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("^.*(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\]).*$")]
    public string? EmailAddress { get; set; }
    
    /// <summary>
    /// Gets or sets the unique PayPal payer identifier.
    /// </summary>
    /// <remarks>
    /// A 13-character alphanumeric code that uniquely identifies a PayPal customer.
    /// Must match the pattern: exactly 13 characters from the set [2-9A-HJ-NP-Z].
    /// </remarks>
    [JsonPropertyName("payer_id")]
    [StringLength(13)]
    [RegularExpression("^[2-9A-HJ-NP-Z]{13}$")]
    public string? PayerId { get; set; }
}