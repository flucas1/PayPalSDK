using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Transactions;

namespace Tavstal.PayPalSDK.Models.TransactionSearch.Bodies;

/// <summary>
/// Represents the response body for a transaction list balance query from the PayPal Transaction Search API.
/// </summary>
[DataContract]
public class TransactionListBalanceResponseBody
{
    /// <summary>
    /// Gets or sets the list of balance records returned in the response.
    /// </summary>
    [JsonPropertyName("balances")]
    public List<Balance>? Balances { get; set; }
    
    /// <summary>
    /// Gets or sets the PayPal account ID associated with the balance query.
    /// </summary>
    [JsonPropertyName("account_id")]
    [StringLength(13)]
    [RegularExpression("^[2-9A-HJ-NP-Z]{13}$")]
    public string? AccountId { get; set; }
    
    /// <summary>
    /// Gets or sets the timestamp for which the balance data is current, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("as_of_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? AsOfTime { get; set; }
    
    /// <summary>
    /// Gets or sets the timestamp indicating when the balance data was last refreshed, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("last_refresh_time")]
    [StringLength(64, MinimumLength = 20)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])[T,t]([0-1][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)([.][0-9]+)?([Zz]|[+-][0-9]{2}:[0-9]{2})$")]
    public string? LastRefreshTime { get; set; }
}