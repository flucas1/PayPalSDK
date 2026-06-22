using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Addressing;

/// <summary>
/// Represents a phone number with a country code and national number.
/// </summary>
[DataContract]
public class PhoneNumber
{
    /// <summary>
    /// Gets or sets the country code of the phone number in ISO 3166-1 alpha-2 format.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 3 characters.
    /// </remarks>
    [JsonPropertyName("country_code")]
    [StringLength(3)]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the national number of the phone number.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 14 characters.
    /// </remarks>
    [JsonPropertyName("national_number")]
    [StringLength(14)]
    public required string NationalNumber { get; set; }
    
    /// <summary>
    /// Gets or sets the extension number of the phone number.
    /// </summary>
    [JsonPropertyName("extension_number")]
    [StringLength(15)]
    public string? ExtensionNumber { get; set; }
}