using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;


/// <summary>
/// Represents a verification object in the PayPal SDK.
/// </summary>
[DataContract]
public class Verification
{
    /// <summary>
    /// Gets or sets the card verification method.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 255 characters, and should correspond to one of the constants defined in <see cref="Tavstal.PayPalSDK.Constants.CardVerificationMethods"/>.
    /// </remarks>
    [JsonPropertyName("amount")]
    [StringLength(255)]
    public string? Method { get; set; }
}