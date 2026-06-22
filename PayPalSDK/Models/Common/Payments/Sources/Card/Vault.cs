using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;

/// <summary>
/// Represents a vault configuration in the PayPal SDK.
/// </summary>
[DataContract]
public class Vault
{
    /// <summary>
    /// Gets or sets the value indicating whether to store the payment source in the vault.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 255 characters, and must match the regular expression ^[0-9A-Z_]+$.
    /// </remarks>
    [JsonPropertyName("store_in_vault")]
    [StringLength(255)]
    [RegularExpression("^[0-9A-Z_]+$")]
    public string? StoreInVault { get; set; }
}