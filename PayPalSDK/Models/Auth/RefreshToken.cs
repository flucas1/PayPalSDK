using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Auth;

/// <summary>
/// Represents a refresh token response from the PayPal authentication API.
/// </summary>
[DataContract]
public class RefreshToken
{
    /// <summary>
    /// The refresh token string.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public required string Token { get; init; }

    /// <summary>
    /// The type of the token.
    /// </summary>
    [JsonPropertyName("token_type")]
    public required string TokenType { get; init; }

    /// <summary>
    /// The expiration time of the token in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required string ExpiresIn { get; init; }

    /// <summary>
    /// The ID token.
    /// </summary>
    [JsonPropertyName("id_token")]
    public string? IdToken { get; init; }
    
    /// <summary>
    /// Converts the current <see cref="RefreshToken"/> instance to an <see cref="AccessToken"/> instance.
    /// </summary>
    /// <returns>
    /// An <see cref="AccessToken"/> object containing the token, token type, and expiration time.
    /// If the expiration time is not a valid integer, it defaults to 0.
    /// </returns>
    public AccessToken ToAccessToken()
    {
        return new AccessToken
        {
            Token = Token,
            TokenType = TokenType,
            ExpiresIn = int.TryParse(ExpiresIn, out var expiresIn) ? expiresIn : 0
        };
    }
}