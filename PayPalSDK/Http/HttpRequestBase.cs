using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Http;

/// <summary>
/// Represents the base class for HTTP requests in the PayPal SDK.
/// </summary>
public abstract class HttpRequestBase : HttpRequestMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpRequestBase"/> class.
    /// </summary>
    /// <param name="method">The HTTP method to be used for the request (e.g., GET, POST).</param>
    /// <param name="url">The URL to which the request will be sent.</param>
    protected HttpRequestBase(HttpMethod method, string url)
    {
        this.Method = method;
        this.RequestUri = new Uri(url, UriKind.Relative);
    }
}

/// <summary>
/// Represents a generic base class for HTTP requests in the PayPal SDK.
/// </summary>
/// <typeparam name="T">The type of the expected response.</typeparam>
public abstract class HttpRequestBase<T> : HttpRequestBase where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpRequestBase{T}"/> class.
    /// </summary>
    /// <param name="method">The HTTP method to be used for the request (e.g., GET, POST).</param>
    /// <param name="url">The URL to which the request will be sent.</param>
    protected HttpRequestBase(HttpMethod method, string url)
        : base(method, url)
    {
    }

    /// <summary>
    /// Asynchronously retrieves and deserializes the response body into the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> if the response body is not empty; otherwise, <c>null</c>.
    /// </returns>
    public async Task<T?> GetResponseBodyAsync(HttpResponseMessage response)
    {
        var rawResponse = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(rawResponse))
            return null;

        JsonTypeInfo? rawTypeInfo = PayPalSDKSerializerContext.Default.GetTypeInfo(typeof(T));
        JsonTypeInfo<T>? typeInfo = rawTypeInfo as JsonTypeInfo<T>;
        if (typeInfo != null)
        {
            return JsonSerializer.Deserialize<T>(rawResponse, typeInfo);
        }
        else
        {
            throw new InvalidOperationException($"No JsonTypeInfo found for type {typeof(T).FullName}. Ensure that the type is included in the PayPalSDKSerializerContext.");
        }
    }
}