using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.Addressing;

/// <summary>
/// Represents shipping details including type, name, email address, phone number, address, and shipping options.
/// </summary>
[DataContract]
public class Shipping
{
    /// <summary>
    /// Gets or sets the type of shipping.
    /// </summary>
    /// <remarks>
    /// This property corresponds to one of the predefined shipping types in <see cref="Tavstal.PayPalSDK.Constants.ShippingType"/>.
    /// It is optional and will not be emitted if its value is null or default.
    /// </remarks>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the name of the person associated with the shipping.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the recipient's name.
    /// </remarks>
    [JsonPropertyName("name")]
    public Person? Name { get; set; }

    /// <summary>
    /// Gets or sets the email address of the person associated with the shipping.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 254 characters.
    /// The email address must match the specified regular expression format.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254, ErrorMessage = "Email address cannot exceed 254 characters.")]
    [RegularExpression("^(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])$", ErrorMessage = "Invalid email address format.")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the person associated with the shipping.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the recipient's phone number.
    /// </remarks>
    [JsonPropertyName("phone_number")]
    public PhoneNumber? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the address associated with the shipping.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the shipping address.
    /// </remarks>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// Gets or sets the list of shipping options available.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the available shipping options.
    /// </remarks>
    [JsonPropertyName("options")]
    public List<ShippingOption>? Options { get; set; }
}