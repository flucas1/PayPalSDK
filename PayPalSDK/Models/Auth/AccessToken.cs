using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Auth;

/// <summary>
/// Represents an access token used for authentication with the PayPal API.
/// </summary>
[DataContract]
public class AccessToken
{
    /// <summary>
    /// The access token string provided by the PayPal API.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? Token { get; set; }

    /// <summary>
    /// The type of the token (e.g., Bearer).
    /// </summary>
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    /// <summary>
    /// The duration in seconds until the token expires.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// The exact date and time when the token will expire.
    /// </summary>
    [JsonIgnore]
    private readonly DateTime _expireDate = DateTime.Now;

    /// <summary>
    /// Determines whether the access token has expired.
    /// </summary>
    /// <returns><c>true</c> if the token has expired; otherwise, <c>false</c>.</returns>
    public bool IsExpired() => DateTime.Now >= _expireDate;
}