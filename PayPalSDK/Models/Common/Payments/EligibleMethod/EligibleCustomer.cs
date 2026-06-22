using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;

namespace Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

/// <summary>
/// Represents a customer who may be eligible for a payment method.
/// </summary>
[DataContract]
public class EligibleCustomer
{
    /// <summary>
    /// Gets or sets the ISO 3166-1 alpha-2 country code for the customer.
    /// </summary>
    [JsonPropertyName("country_code")]
    [StringLength(2)]
    public string? CountryCode { get; set; }
    
    /// <summary>
    /// Gets or sets the client channel information associated with the customer.
    /// </summary>
    [JsonPropertyName("channel")]
    public EligibleChannel? Channel { get; set; }
    
    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    [JsonPropertyName("id")]
    [StringLength(36)]
    public string? Id { get; set; }
    
    /// <summary>
    /// Gets or sets the customer's phone number.
    /// </summary>
    public PhoneNumber? Phone { get; set; }
}