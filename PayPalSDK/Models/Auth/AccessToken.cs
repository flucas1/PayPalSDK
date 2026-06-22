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
    public required string Token { get; init; }

    /// <summary>
    /// The type of the token (e.g., Bearer).
    /// </summary>
    [JsonPropertyName("token_type")]
    public required string TokenType { get; init; }

    /// <summary>
    /// The duration in seconds until the token expires.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }

    /// <summary>
    /// Gets the date and time when the access token was created.
    /// </summary>
    [JsonIgnore] 
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    /// <summary>
    /// Determines whether the access token has expired.
    /// </summary>
    /// <returns><c>true</c> if the token has expired; otherwise, <c>false</c>.</returns>
    public bool IsExpired() => DateTime.UtcNow >= CreatedAt.AddSeconds(ExpiresIn);
}