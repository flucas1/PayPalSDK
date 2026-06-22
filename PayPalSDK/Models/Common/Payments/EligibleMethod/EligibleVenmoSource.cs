using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

/// <summary>
/// Represents a Venmo payment source with user identification information.
/// </summary>
[DataContract]
public class EligibleVenmoSource
{
    /// <summary>
    /// Gets or sets the Venmo username associated with the payment source.
    /// </summary>
    /// <remarks>
    /// The username must not exceed 50 characters in length.
    /// </remarks>
    [JsonPropertyName("user_name")]
    [StringLength(50)]
    public string? UserName { get; set; }
}