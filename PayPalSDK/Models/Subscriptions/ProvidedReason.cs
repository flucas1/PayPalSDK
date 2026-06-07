using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions
{
    [DataContract]
    public class ProvidedReason
    {
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
