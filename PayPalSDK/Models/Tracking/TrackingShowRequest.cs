using System.ComponentModel.DataAnnotations;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Tracking.Bodies;

namespace Tavstal.PayPalSDK.Models.Tracking;

/// <summary>
/// Represents a request to show the details of a specific PayPal tracking entry.
/// </summary>
public class TrackingShowRequest : HttpRequestBase<Tracker>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrackingShowRequest"/> class.
    /// </summary>
    /// <param name="id">The unique tracking identifier. Must be 100 characters or fewer.</param>
    /// <param name="accountId">The optional PayPal account ID associated with the tracker. Must be 13 characters if provided.</param>
    public TrackingShowRequest([StringLength(100)] string id, [StringLength(13)] string? accountId = null) 
        : base(HttpMethod.Get, $"/v1/shipping/trackers/{id}")
    {
        if (accountId != null)
            RequestUri = new Uri(RequestUri + $"?account_id={accountId}", UriKind.Relative);
    }
}