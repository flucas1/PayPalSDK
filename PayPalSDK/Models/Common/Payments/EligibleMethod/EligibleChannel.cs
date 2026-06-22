using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

/// <summary>
/// Represents the client/channel information used when determining eligible payment methods.
/// </summary>
[DataContract]
public class EligibleChannel
{
    /// <summary>
    /// Gets or sets the browser type reported by the client.
    /// </summary>
    [JsonPropertyName("browser_type")]
    [StringLength(30)]
    public string? BrowserType { get; set; }
    
    /// <summary>
    /// Gets or sets the client operating system reported by the client.
    /// </summary>
    [JsonPropertyName("client_os")]
    [StringLength(30)]
    public string? ClientOs { get; set; }
    
    /// <summary>
    /// Gets or sets the device type reported by the client.
    /// </summary>
    [JsonPropertyName("device_type")]
    [StringLength(30)]
    public string? DeviceType { get; set; }
}