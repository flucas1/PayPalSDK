using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.Billing;

/// <summary>
/// Represents the billing information for a business.
/// </summary>
[DataContract]
public class BusinessBillingInfo
{
    /// <summary>
    /// Gets or sets the business name associated with the billing information.
    /// </summary>
    /// <remarks>
    /// The business name must not exceed 300 characters.
    /// </remarks>
    [JsonPropertyName("business_name")]
    [StringLength(300)]
    public string BusinessName { get; set; }

    /// <summary>
    /// Gets or sets the name information of the business contact.
    /// </summary>
    [JsonPropertyName("name")]
    public NameInfo Name { get; set; }

    /// <summary>
    /// Gets or sets the address information for the business.
    /// </summary>
    [JsonPropertyName("address")]
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the list of phone numbers associated with the business.
    /// </summary>
    [JsonPropertyName("phones")]
    public List<Phone> Phones { get; set; }

    /// <summary>
    /// Gets or sets additional information about the business.
    /// </summary>
    /// <remarks>
    /// The additional information must not exceed 40 characters.
    /// </remarks>
    [JsonPropertyName("additional_info")]
    [StringLength(40)]
    public string AdditionalInfo { get; set; }

    /// <summary>
    /// Gets or sets the email address of the business.
    /// </summary>
    /// <remarks>
    /// The email address must not exceed 254 characters and must match the specified regular expression pattern.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("^(?!\\.)(?:[A-Za-z0-9!#$&'*\\/=?^`{|}~_%+-]|\\.(?!\\.)){1,64}(?<!\\.)@(?:[A-Za-z0-9-]|\\.(?!\\.))+\\.[a-zA-Z]{2,}$")]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the language preference of the business.
    /// </summary>
    /// <remarks>
    /// The language must not exceed 10 characters and must match the specified regular expression pattern.
    /// </remarks>
    [JsonPropertyName("language")]
    [StringLength(10)]
    [RegularExpression("^[a-z]{2}(?:-[A-Z][a-z]{3})?(?:-(?:[A-Z]{2}|[0-9]{3}))?$")]
    public string Language { get; set; }
}