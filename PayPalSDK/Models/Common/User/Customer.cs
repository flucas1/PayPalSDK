using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents a customer object in the PayPal SDK.
/// </summary>
[DataContract]
public class Customer
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 22 characters, and must match the regular expression ^[0-9a-zA-Z_-]+$.
    /// </remarks>
    [JsonPropertyName("id")]
    [StringLength(22)]
    [RegularExpression("^[0-9a-zA-Z_-]+$")]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the email address of the customer.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 254 characters, and must match a valid email address format.
    /// </remarks>
    [JsonPropertyName("email_address")]
    [StringLength(254)]
    [RegularExpression("(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the phone details of the customer.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the customer's phone information.
    /// </remarks>
    [JsonPropertyName("phone")]
    public Phone? Phone { get; set; }

    /// <summary>
    /// Gets or sets the name details of the customer.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the customer's name information.
    /// </remarks>
    [JsonPropertyName("name")]
    public Name? Name { get; set; }

    /// <summary>
    /// Gets or sets the merchant-specific customer identifier.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 64 characters.
    /// </remarks>
    [JsonPropertyName("merchant_customer_id")]
    [StringLength(64)]
    public string? MerchantCustomerId { get; set; }
}