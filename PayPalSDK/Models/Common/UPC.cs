using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a Universal Product Code (UPC) with a type and code.
/// </summary>
[DataContract]
public class UPC
{
    /// <summary>
    /// Gets or sets the type of the UPC.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 5 characters.
    /// The value must match the regular expression: ^[0-9A-Z_-]+$.
    /// </remarks>
    [JsonPropertyName("type")]
    [StringLength(5)]
    [RegularExpression("^[0-9A-Z_-]+$")]
    public required string Type { get; set; }
    
    /// <summary>
    /// Gets or sets the code of the UPC.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 17 characters.
    /// </remarks>
    [JsonPropertyName("code")]
    [StringLength(17)]
    public required string Code { get; set; }
}