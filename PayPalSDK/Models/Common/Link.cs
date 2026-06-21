using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common;

/// <summary>
/// Represents a hyperlink object used within the PayPal SDK.
/// </summary>
[DataContract]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class Link
{
    /// <summary>
    /// Gets or sets the URL of the link.
    /// </summary>
    /// <remarks>
    /// This field is required and specifies the target URL of the link.
    /// </remarks>
    [JsonPropertyName("href")]
    public required string Href { get; set; }

    /// <summary>
    /// Gets or sets the relationship of the link to the resource.
    /// </summary>
    /// <remarks>
    /// This field is required and describes the type of relationship the link has with the resource.
    /// </remarks>
    [JsonPropertyName("rel")]
    public required string Rel { get; set; }

    /// <summary>
    /// Gets or sets the HTTP method to be used with the link.
    /// </summary>
    /// <remarks>
    /// This field is optional and specifies the HTTP method (e.g., GET, POST) for the link.
    /// </remarks>
    [JsonPropertyName("method")]
    public string? Method { get; set; }
    
    /// <summary>
    /// Returns a string representation of the <see cref="Link"/> instance.
    /// </summary>
    public override string ToString()
    {
        return $"Link: [Href: {Href}, Rel: {Rel}, Method: {Method}]";
    }
}