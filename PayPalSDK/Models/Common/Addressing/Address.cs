using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Addressing;

/// <summary>
/// Represents an address model used in the PayPal SDK.
/// </summary>
[DataContract]
public class Address
{
    /// <summary>
    /// Gets or sets the first line of the address.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("address_line_1")]
    [StringLength(300)]
    public string? AddressLineOne { get; set; }

    /// <summary>
    /// Gets or sets the second line of the address.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("address_line_2")]
    [StringLength(300)]
    public string? AddressLineTwo { get; set; }

    /// <summary>
    /// Gets or sets the administrative area (e.g., state or province).
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("admin_area_1")]
    [StringLength(300)]
    public string? AdminAreaOne { get; set; }

    /// <summary>
    /// Gets or sets the locality or city.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 120 characters.
    /// </remarks>
    [JsonPropertyName("admin_area_2")]
    [StringLength(120)]
    public string? AdminAreaTwo { get; set; }

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 60 characters.
    /// </remarks>
    [JsonPropertyName("postal_code")]
    [StringLength(60)]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the country code in ISO 3166-1 alpha-2 format.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 2 characters.
    /// </remarks>
    [JsonPropertyName("country_code")]
    [StringLength(2)]
    public required string CountryCode { get; set; }
}