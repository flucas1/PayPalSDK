using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to update a specific subscription plan.
/// </summary>
public class PlanUpdateRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanUpdateRequest"/> class.
    /// </summary>
    /// <param name="planId">The unique identifier of the subscription plan to update.</param>
    /// <param name="body">A list of update operations to apply to the subscription plan.</param>
    public PlanUpdateRequest(string planId, List<UpdateOperation> body)
        : base(HttpMethod.Patch, $"/v1/billing/plans/{planId}")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<List<UpdateOperation>>(body, PayPalSDKSerializerContext.Default.ListUpdateOperation);
    }
}