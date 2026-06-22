using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents a name object in the PayPal SDK.
/// </summary>
[DataContract]
public class Name
{
    /// <summary>
    /// Gets or sets the given name.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 140 characters.
    /// </remarks>
    [JsonPropertyName("given_name")]
    [StringLength(140)]
    public string? GivenName { get; set; }

    /// <summary>
    /// Gets or sets the surname.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 140 characters.
    /// </remarks>
    [JsonPropertyName("surname")]
    [StringLength(140)]
    public string? Surname { get; set; }
}