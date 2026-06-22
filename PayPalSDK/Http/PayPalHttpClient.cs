using System.Net.Http.Headers;
using Tavstal.PayPalSDK.Config;
using Tavstal.PayPalSDK.Models.Auth;
using Tavstal.PayPalSDK.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tavstal.PayPalSDK.Http;

/// <summary>
/// Represents a PayPal HTTP client for sending requests to the PayPal API.
/// </summary>
public class PayPalHttpClient : IDisposable
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
    /// <param name="applicationName">An optional application name to include in the User-Agent header.</param>
    public PayPalHttpClient(EnvironmentBase environment, string? refreshToken = null, string? applicationName = null)
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
        var agent = applicationName != null ? UserAgent.GetUserAgentHeader(applicationName) : UserAgent.GetUserAgentHeader();
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(agent);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PayPalHttpClient"/> using a provided <see cref="HttpClient"/>.
    /// This constructor is useful for tests where a custom HttpMessageHandler is required.
    /// </summary>
    /// <param name="environment">The environment configuration.</param>
    /// <param name="httpClient">The pre-configured HttpClient to use.</param>
    /// <param name="refreshToken">Optional refresh token.</param>
    /// <param name="applicationName">An optional application name to include in the User-Agent header.</param>
    public PayPalHttpClient(EnvironmentBase environment, HttpClient httpClient, string? refreshToken = null, string? applicationName = null)
    {
        _environment = environment;
        _refreshToken = refreshToken;
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        // Ensure BaseAddress and some default headers exist when not already set on the supplied HttpClient.
        if (_httpClient.BaseAddress == null)
            _httpClient.BaseAddress = new Uri(_environment.BaseUrl);

        if (!_httpClient.DefaultRequestHeaders.Contains("Accept"))
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
        {
            var agent = applicationName != null ? UserAgent.GetUserAgentHeader(applicationName) : UserAgent.GetUserAgentHeader();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(agent);
        }
    }
    
    /// <summary>
    /// Disposes the underlying HttpClient instance.
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }

    /// <summary>
    /// Sends an asynchronous HTTP request to the PayPal API.
    /// Automatically adds an Authorization header if not already present.
    /// </summary>
    /// <param name="request">The HTTP request to send.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing the HTTP response.</returns>
    public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestBase request, CancellationToken cancellationToken = default)
    {
        // Adds the Authorization header if missing, fetching a new access token if necessary.
        if (!request.Headers.Contains("Authorization"))
        {
            if (_accessToken == null || _accessToken.IsExpired())
            {
                _accessToken = await FetchAccessTokenAsync(cancellationToken);
            }
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.Token);
        }

        return await _httpClient.SendAsync(request, cancellationToken);
    }

    /// <summary>
    /// Fetches a new access token from the PayPal API.
    /// Handles both access token and refresh token responses.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing the fetched access token.</returns>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <exception cref="InvalidOperationException">Thrown if the access token retrieval fails.</exception>
    private async Task<AccessToken> FetchAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            // Creates a request to obtain an access token.
            var tokenRequest = new AccessTokenRequest(_environment, _refreshToken);
            using var response = await _httpClient.SendAsync(tokenRequest, cancellationToken);
            response.EnsureSuccessStatusCode();

            // Deserializes the response into an access token or refresh token.
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var accessToken = JsonSerializer.Deserialize(json, PayPalSDKJsonContext.Default.AccessToken);
            if (accessToken == null)
            {
                var refreshToken =
                    JsonSerializer.Deserialize(json, PayPalSDKJsonContext.Default.RefreshToken);
                if (refreshToken != null)
                    return refreshToken.ToAccessToken();

                throw new InvalidOperationException("Failed to deserialize access token response.");
            }

            return accessToken;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to retrieve access token", ex);
        }
    }

    
}