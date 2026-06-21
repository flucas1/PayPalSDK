using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Addressing;

/// <summary>
/// Represents return shipping information associated with a transaction, including whether to save the address to the buyer's profile and the return address details.
/// </summary>
[DataContract]
public class ReturnShippingInfo
{
    /// <summary>
    /// Gets or sets a value indicating whether the return address should be saved to the buyer's profile.
    /// </summary>
    [JsonPropertyName("save_to_profile")]
    public bool SaveToProfile { get; set; }
    
    /// <summary>
    /// Gets or sets the return shipping address.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }
}