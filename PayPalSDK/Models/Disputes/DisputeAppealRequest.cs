using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Disputes;

/// <summary>
/// Represents a request to appeal the resolution of an existing customer dispute.
/// </summary>
public class DisputeAppealRequest : HttpRequestBase<LinksResponseBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DisputeAppealRequest"/> class.
    /// </summary>
    /// <param name="id">
    /// The unique dispute identifier used to build the request route.
    /// Maximum length is 255 characters.
    /// </param>
    /// <param name="body">
    /// The request payload containing the details and rationale for the appeal.
    /// </param>
    public DisputeAppealRequest([StringLength(255)] string id, DisputeAppealRequestBody? body = null)
        : base(HttpMethod.Post,  $"/v1/customer/disputes/{id}/appeal")
    {
        // Sets the content of the HTTP request to the serialized JSON representation of the order creation details.
        if (body != null)
            Content = JsonContent.Create(body, PayPalSDKJsonContext.Default.DisputeAppealRequestBody);
    }
}