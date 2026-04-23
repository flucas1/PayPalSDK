using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents information about a user's name.
/// </summary>
[DataContract]
public class NameInfo
{
    /// <summary>
    /// Gets or sets the prefix of the user's name (e.g., "Mr.", "Dr.").
    /// </summary>
    [JsonPropertyName("prefix")]
    [StringLength(140)]
    public string Prefix { get; set; }

    /// <summary>
    /// Gets or sets the user's given name (first name).
    /// </summary>
    [JsonPropertyName("given_name")]
    [StringLength(140)]
    public string GivenName { get; set; }

    /// <summary>
    /// Gets or sets the user's surname (last name).
    /// </summary>
    [JsonPropertyName("surname")]
    [StringLength(140)]
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the user's middle name.
    /// </summary>
    [JsonPropertyName("middle_name")]
    [StringLength(140)]
    public string MiddleName { get; set; }

    /// <summary>
    /// Gets or sets the suffix of the user's name (e.g., "Jr.", "III").
    /// </summary>
    [JsonPropertyName("suffix")]
    [StringLength(140)]
    public string Suffix { get; set; }

    /// <summary>
    /// Gets or sets an alternate full name for the user.
    /// </summary>
    [JsonPropertyName("alternate_full_name")]
    [StringLength(300)]
    public string AlternateFullName { get; set; }

    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    [JsonPropertyName("full_name")]
    [StringLength(300)]
    public string FullName { get; set; }
}