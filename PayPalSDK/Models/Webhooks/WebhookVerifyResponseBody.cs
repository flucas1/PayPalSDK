using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Webhooks;

/// <summary>
/// Represents the response body for verifying a webhook in the PayPal SDK.
/// </summary>
public class WebhookVerifyResponseBody
{
    /// <summary>
    /// Gets or sets the verification status of the webhook.
    /// </summary>
    /// <remarks>
    /// The verification status indicates whether the webhook is successfully verified.
    /// </remarks>
    [JsonPropertyName("verification_status")]
    public required string VerificationStatus { get; set; }
}