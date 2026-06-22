using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Orders;

/// <summary>
/// Represents supplementary data in the PayPal SDK.
/// </summary>
[DataContract]
public class SupplementaryData
{
    /// <summary>
    /// Gets or sets the card information associated with the supplementary data.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents details about the card used in the transaction.
    /// </remarks>
    [JsonPropertyName("card")]
    public SupplementaryCard? SupplementaryCard { get; set; }

    /// <summary>
    /// Gets or sets the risk information associated with the supplementary data.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents risk assessment details for the transaction.
    /// </remarks>
    [JsonPropertyName("risk")]
    public Risk? Risk { get; set; }
}