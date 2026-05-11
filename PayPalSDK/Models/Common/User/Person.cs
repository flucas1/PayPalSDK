using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents a person with a full name.
/// </summary>
[DataContract]
public class Person
{
    /// <summary>
    /// Gets or sets the full name of the person.
    /// </summary>
    /// <remarks>
    /// This field is optional and will not be emitted if its value is null or default.
    /// </remarks>
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }
}