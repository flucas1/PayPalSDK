using System.Net.Http.Headers;
using Tavstal.PayPalSDK.Config;
using Tavstal.PayPalSDK.Models.Auth;
using Tavstal.PayPalSDK.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tavstal.PayPalSDK.Http;

/// <summary>
/// Represents a PayPal HTTP client for sending requests to the PayPal API.
/// </summary>
public class PayPalHttpClient
{
    private readonly HttpClient _httpClient;
    private AccessToken? _accessToken;
    private readonly string? _refreshToken;
    private readonly EnvironmentBase _environment;

    /// <summary>
    /// Initializes a new instance of the <see cref="PayPalHttpClient"/> class.
    /// </summary>
    /// <param name="environment">The PayPal environment configuration containing base URL and authorization details.</param>
    /// <param name="refreshToken">An optional refresh token for obtaining access tokens.</param>
    public PayPalHttpClient(EnvironmentBase environment, string? refreshToken = null)
    {
        _environment = environment;
        _refreshToken = refreshToken;

        // Configures the HTTP client with automatic decompression and default headers.
        _httpClient = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
        });

        _httpClient.BaseAddress = new Uri(_environment.BaseUrl);
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent.GetUserAgentHeader());
    }

    /// <summary>
    /// Sends an asynchronous HTTP request to the PayPal API.
    /// Automatically adds an Authorization header if not already present.
    /// </summary>
    /// <param name="request">The HTTP request to send.</param>
    /// <returns>A task representing the asynchronous operation, containing the HTTP response.</returns>
    public async Task<HttpResponseMessage> SendAsync(HttpRequestBase request)
    {
        // Adds the Authorization header if missing, fetching a new access token if necessary.
        if (!request.Headers.Contains("Authorization"))
        {
            if (_accessToken == null || _accessToken.IsExpired())
            {
                _accessToken = await FetchAccessTokenAsync();
            }
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.Token);
        }

        return await _httpClient.SendAsync(request);
    }

    /// <summary>
    /// Fetches a new access token from the PayPal API.
    /// Handles both access token and refresh token responses.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing the fetched access token.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the access token retrieval fails.</exception>
    private async Task<AccessToken> FetchAccessTokenAsync()
    {
        try
        {
            // Creates a request to obtain an access token.
            var tokenRequest = new AccessTokenRequest(_environment, _refreshToken);
            using var response = await _httpClient.SendAsync(tokenRequest);
            response.EnsureSuccessStatusCode();

            // Deserializes the response into an access token or refresh token.
            var json = await response.Content.ReadAsStringAsync();
            var accessToken = JsonSerializer.Deserialize<AccessToken>(json, PayPalSDKSerializerContext.Default.AccessToken);
            if (accessToken == null)
            {
                var refreshToken = JsonSerializer.Deserialize<RefreshToken>(json, PayPalSDKSerializerContext.Default.RefreshToken);
                if (refreshToken != null)
                    return refreshToken.ToAccessToken();

                throw new InvalidOperationException("Failed to deserialize access token response.");
            }
            return accessToken;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to retrieve access token", ex);
        }
    }
}