using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a detailed error entry within an error response from the PayPal API.
/// </summary>
[DataContract]
public class ErrorDetail
{
    /// <summary>
    /// Gets or sets the name of the field that caused the error.
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; set; }
    
    /// <summary>
    /// Gets or sets the error issue code or identifier for this specific error.
    /// </summary>
    [JsonPropertyName("issue")]
    public string? Issue { get; set; }
    
    /// <summary>
    /// Gets or sets a human-readable description of the error detail.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    /// <summary>
    /// Returns a formatted string representation of the error detail.
    /// </summary>
    /// <returns>
    /// A string containing the field, issue code, and description in the format:
    /// "Field: {field}, Issue: {issue}, Description: {description}".
    /// </returns>
    public override string ToString()
    {
        return $"Field: {Field}, Issue: {Issue}, Description: {Description}";
    }
}