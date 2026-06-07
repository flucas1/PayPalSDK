using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Webhooks;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents the request body for verifying a webhook signature in the PayPal SDK.
/// </summary>
public class WebhokVerifyRequestBody
{
    /// <summary>
    /// Gets or sets the algorithm used for authentication.
    /// </summary>
    /// <remarks>
    /// The authentication algorithm specifies the method used to sign the webhook transmission.
    /// </remarks>
    [JsonPropertyName("auth_algo")]
    [StringLength(100)]
    public required string AuthAlgo { get; set; }

    /// <summary>
    /// Gets or sets the URL of the certificate used for verification.
    /// </summary>
    /// <remarks>
    /// The certificate URL points to the public key used to verify the webhook signature.
    /// </remarks>
    [JsonPropertyName("cert_url")]
    [StringLength(500)]
    public required string CertUrl { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the transmission.
    /// </summary>
    /// <remarks>
    /// The transmission ID is a unique identifier for the webhook event transmission.
    /// </remarks>
    [JsonPropertyName("transmission_id")]
    [StringLength(50)]
    public required string TransmissionId { get; set; }

    /// <summary>
    /// Gets or sets the signature of the transmission.
    /// </summary>
    /// <remarks>
    /// The transmission signature is used to verify the authenticity of the webhook event.
    /// </remarks>
    [JsonPropertyName("transmission_sig")]
    [StringLength(500)]
    public required string TransmissionSig { get; set; }

    /// <summary>
    /// Gets or sets the time of the transmission.
    /// </summary>
    /// <remarks>
    /// The transmission time indicates when the webhook event was sent.
    /// </remarks>
    [JsonPropertyName("transmission_time")]
    [StringLength(100)]
    public required string TransmissionTime { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the webhook.
    /// </summary>
    /// <remarks>
    /// The webhook ID identifies the webhook associated with the event.
    /// </remarks>
    [JsonPropertyName("webhook_id")]
    [StringLength(50)]
    public required string WebhookId { get; set; }

    /// <summary>
    /// Gets or sets the webhook event data.
    /// </summary>
    /// <remarks>
    /// The webhook event contains the payload of the event triggered by the webhook.
    /// </remarks>
    [JsonPropertyName("webhook_event")]
    public required WebhookEvent WebhookEvent { get; set; }
}