using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Serialization;
using Tavstal.PayPalSDK.Tests.Mocks;

namespace Tavstal.PayPalSDK.Tests.Helpers;

/// <summary>
/// Factory helper for creating test-ready <see cref="PayPalHttpClient"/> instances.
/// </summary>
public static class FakeHttpHelpers
{
    /// <summary>
    /// Creates a new <see cref="FakePayPalHttpClient"/> with the specified responder function.
    /// </summary>
    /// <param name="responder">
    /// A function that takes an <see cref="HttpRequestMessage"/> and returns an <see cref="HttpResponseMessage"/>.
    /// </param>
    /// <returns>A new <see cref="FakePayPalHttpClient"/> instance.</returns>
    public static FakePayPalHttpClient CreateClient(Func<HttpRequestMessage, HttpResponseMessage> responder) =>
        new FakePayPalHttpClient(responder);
    
    /// <summary>
    /// Reads and deserializes the HTTP content using the SDK's source-generated JSON context.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response body into.</typeparam>
    /// <param name="content">The HTTP content containing JSON payload data.</param>
    /// <returns>A task that produces the deserialized instance of <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <typeparamref name="T"/> is not registered in <see cref="PayPalSDKJsonContext"/>.
    /// </exception>
    public static Task<T?> ReadJsonAsync<T>(this HttpContent content)
    {
        var typeInfo = (JsonTypeInfo<T>?)PayPalSDKJsonContext.Default.GetTypeInfo(typeof(T));
        if (typeInfo == null)
            throw new InvalidOperationException($"Type {typeof(T).Name} is not registered in the provided JsonSerializerContext.");
        return content.ReadFromJsonAsync(typeInfo);
    }
    
    /// <summary>
    /// Deserializes a JSON string using the SDK's source-generated JSON context.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON string into.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>The deserialized instance of <typeparamref name="T"/>, or <c>null</c> if deserialization fails.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <typeparamref name="T"/> is not registered in <see cref="PayPalSDKJsonContext"/>.
    /// </exception>
    public static T? DeserializeJson<T>(this string json)
    {
        var typeInfo = (JsonTypeInfo<T>?)PayPalSDKJsonContext.Default.GetTypeInfo(typeof(T));
        if (typeInfo == null)
            throw new InvalidOperationException($"Type {typeof(T).Name} is not registered in the provided JsonSerializerContext.");
        return JsonSerializer.Deserialize(json, typeInfo);
    }
}