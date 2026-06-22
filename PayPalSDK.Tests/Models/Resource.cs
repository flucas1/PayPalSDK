using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Tests.Models;

[DataContract]
public class Resource
{
    [JsonPropertyName("endpoint")]
    public required string Endpoint { get; set; }
    
    [JsonPropertyName("statusCode")]
    public required int StatusCode { get; set; }
    
    [JsonIgnore]
    public string? JsonRequest { get; set; }
    
    [JsonIgnore]
    public required string JsonResponse { get; set; }
    
    public HttpResponseMessage Responder(HttpRequestMessage request)
    {
        var path = request.RequestUri?.OriginalString.TrimStart('/') ?? string.Empty;
        
        if (path.Contains(AuthResource.Endpoint))
        {
            return new HttpResponseMessage((HttpStatusCode)AuthResource.StatusCode)
            {
                Content = new StringContent(AuthResource.JsonResponse, Encoding.UTF8, "application/json")
            };
        }
        
        if (path.Contains(Endpoint))
        {
            return new HttpResponseMessage((HttpStatusCode)StatusCode)
            {
                Content = new StringContent(JsonResponse, Encoding.UTF8, "application/json")
            };
        }
        return new HttpResponseMessage(HttpStatusCode.NotFound);
    }
    
    public static Resource FromFile(string path)
    {
        string json = File.ReadAllText(path);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        return new Resource
        {
            Endpoint = root.GetProperty("endpoint").GetString() ?? throw new InvalidOperationException("Resource JSON must contain an 'endpoint' property"),
            StatusCode = root.GetProperty("statusCode").GetInt32(),
            JsonRequest = root.TryGetProperty("request", out var req) ? req.GetRawText() : null,
            JsonResponse = root.TryGetProperty("response", out var res) ? res.GetRawText() : throw new InvalidOperationException("Resource JSON must contain a 'response' property")
        };
    }
    
    private static Resource? _authResource;
    public static Resource AuthResource => _authResource ??= FromFile("Resources/authResponse.json");
}