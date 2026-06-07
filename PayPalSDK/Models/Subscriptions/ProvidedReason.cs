using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions
{

    public class ProvidedReason
    {
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
