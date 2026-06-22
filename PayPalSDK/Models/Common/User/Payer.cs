using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.PayPal;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents a payer within the PayPal SDK.
/// </summary>
[DataContract]
public class Payer
{
    /// <summary>
    /// Gets or sets the email address of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 254 characters.
    /// The email address must match the specified regular expression pattern.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 13 characters.
    /// The payer ID must match the specified regular expression pattern.
    /// </remarks>
    [JsonPropertyName("payer_id")]
    [StringLength(13)]
    [RegularExpression("^[2-9A-HJ-NP-Z]{13}$")]
    public string? PayerId { get; set; }

    /// <summary>
    /// Gets or sets the name of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the payer's name details.
    /// </remarks>
    [JsonPropertyName("name")]
    public Name? Name { get; set; }

    /// <summary>
    /// Gets or sets the phone details of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the payer's phone information.
    /// </remarks>
    [JsonPropertyName("phone")]
    public Phone? Phone { get; set; }

    /// <summary>
    /// Gets or sets the birthdate of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 10 characters.
    /// The birthdate must match the specified regular expression pattern (YYYY-MM-DD).
    /// </remarks>
    [JsonPropertyName("birth_date")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the tax information of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the payer's tax details.
    /// </remarks>
    [JsonPropertyName("tax_info")]
    public TaxInfo? TaxInfo { get; set; }

    /// <summary>
    /// Gets or sets the address of the payer.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the payer's address details.
    /// </remarks>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }
}