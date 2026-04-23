using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Invoices;

/// <summary>
/// Represents an attachment with details for an invoice, such as a file or reference URL.
/// </summary>
[DataContract]
public class DetailAttachment
{
    /// <summary>
    /// Gets or sets the unique identifier of the attachment.
    /// </summary>
    /// <remarks>
    /// The ID must not exceed 255 characters.
    /// </remarks>
    [JsonPropertyName("id")]
    [StringLength(255)]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the reference URL for the attachment.
    /// </summary>
    /// <remarks>
    /// The URL must not exceed 2500 characters.
    /// </remarks>
    [JsonPropertyName("reference_url")]
    [StringLength(2500)]
    public string ReferenceUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the content type of the attachment (e.g., MIME type).
    /// </summary>
    [JsonPropertyName("content_type")]
    public string ContentType { get; set; }

    /// <summary>
    /// Gets or sets the size of the attachment.
    /// </summary>
    [JsonPropertyName("size")]
    public string Size { get; set; }

    /// <summary>
    /// Gets or sets the creation time of the attachment.
    /// </summary>
    /// <remarks>
    /// The creation time must be in ISO 8601 format (YYYY-MM-DDTHH:MM:SSZ).
    /// </remarks>
    [JsonPropertyName("create_time")]
    [StringLength(64)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string CreateTime { get; set; }
}