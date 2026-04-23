using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.User;

/// <summary>
/// Represents the seller protection details in PayPal transactions.
/// </summary>
[DataContract]
public class SellerProtection
{
    /// <summary>
    /// The status of seller protection.
    /// Possible values are defined in <see cref="Tavstal.PayPalSDK.Constants.SellerProtectionStatus"/>.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// A list of dispute categories associated with the seller protection.
    /// </summary>
    [JsonPropertyName("dispute_categories")]
    public List<string> DisputeCategories { get; set; }
}