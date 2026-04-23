using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents the invoicer details for an invoice, including business information, contact details, and additional notes.
/// </summary>
[DataContract]
public class Invoicer
{
    /// <summary>
    /// Gets or sets the business name of the invoicer.
    /// </summary>
    /// <remarks>
    /// The business name must not exceed 300 characters.
    /// </remarks>
    [JsonPropertyName("business_name")]
    [StringLength(300)]
    public string BusinessName { get; set; }

    /// <summary>
    /// Gets or sets the name information of the invoicer.
    /// </summary>
    [JsonPropertyName("name")]
    public NameInfo Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the invoicer.
    /// </summary>
    [JsonPropertyName("address")]
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the list of phone numbers associated with the invoicer.
    /// </summary>
    [JsonPropertyName("phones")]
    public List<Phone> Phones { get; set; }

    /// <summary>
    /// Gets or sets the website URL of the invoicer.
    /// </summary>
    /// <remarks>
    /// The website URL must not exceed 2048 characters.
    /// </remarks>
    [JsonPropertyName("website")]
    [StringLength(2048)]
    public string Website { get; set; }

    /// <summary>
    /// Gets or sets the tax identification number of the invoicer.
    /// </summary>
    /// <remarks>
    /// The tax ID must not exceed 100 characters.
    /// </remarks>
    [JsonPropertyName("tax_id")]
    [StringLength(100)]
    public string TaxId { get; set; }

    /// <summary>
    /// Gets or sets additional notes for the invoicer.
    /// </summary>
    /// <remarks>
    /// The additional notes must not exceed 400 characters.
    /// </remarks>
    [JsonPropertyName("addition_notes")]
    [StringLength(400)]
    public string AdditionNotes { get; set; }

    /// <summary>
    /// Gets or sets the logo URL of the invoicer.
    /// </summary>
    /// <remarks>
    /// The logo URL must not exceed 2000 characters.
    /// </remarks>
    [JsonPropertyName("logo_url")]
    [StringLength(2000)]
    public string LogoUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the email address of the invoicer.
    /// </summary>
    /// <remarks>
    /// The email address must not exceed 254 characters and must match the specified regular expression pattern.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("^(?!\\.)(?:[A-Za-z0-9!#$&'*\\/=?^`{|}~_%+-]|\\.(?!\\.)){1,64}(?<!\\.)@(?:[A-Za-z0-9-]|\\.(?!\\.))+\\.[a-zA-Z]{2,}$")]
    public string EmailAddress { get; set; }
}