using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Disputes.Bodies;

/// <summary>
/// Represents the request body for providing support in a PayPal dispute.
/// </summary>
[DataContract]
public class DisputeProvideSupportRequestBody
{
    /// <summary>
    /// Gets or sets the note content to be provided as support in the dispute.
    /// This property is required and has a maximum length of 2000 characters.
    /// </summary>
    [JsonPropertyName("notes")]
    [StringLength(2000)]
    public required string Notes { get; set; }
}