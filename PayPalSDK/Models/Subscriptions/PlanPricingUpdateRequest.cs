using System.Net.Http.Json;
using Tavstal.PayPalSDK.Http;
using Tavstal.PayPalSDK.Models.Common.Plans;
using Tavstal.PayPalSDK.Serialization;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to update the pricing schemes of a specific subscription plan.
/// </summary>
public class PlanPricingUpdateRequest : HttpRequestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanPricingUpdateRequest"/> class.
    /// </summary>
    /// <param name="planId">The unique identifier of the subscription plan to update pricing schemes for.</param>
    /// <param name="body">A list of pricing schemes to apply to the subscription plan.</param>
    public PlanPricingUpdateRequest(string planId, List<PlanPricingScheme> body)
        : base(HttpMethod.Post, $"/v1/billing/plans/{planId}/update-pricing-schemes")
    {
        // Sets the content of the HTTP request using the provided body and JSON serialization options.
        Content = JsonContent.Create<List<PlanPricingScheme>>(body, PayPalSDKSerializerContext.Default.ListPlanPricingScheme);
    }
}