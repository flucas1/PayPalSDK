using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Orders.Supplementary;

namespace Tavstal.PayPalSDK.Models.Common.Orders;

/// <summary>
/// Represents supplementary card information for a PayPal order.
/// </summary>
[DataContract]
public class SupplementaryCard
{
    /// <summary>
    /// Gets or sets Level 2 data associated with the card.
    /// </summary>
    /// <remarks>
    /// Level 2 data typically includes additional transaction details
    /// required for enhanced payment processing.
    /// </remarks>
    [JsonPropertyName("level_2")]
    public LevelTwo LevelTwo { get; set; }

    /// <summary>
    /// Gets or sets Level 3 data associated with the card.
    /// </summary>
    /// <remarks>
    /// Level 3 data provides detailed line-item information for transactions,
    /// often used for business-to-business payments.
    /// </remarks>
    [JsonPropertyName("level_3")]
    public LevelThree LevelThree { get; set; }
}