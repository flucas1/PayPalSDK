using Tavstal.PayPalSDK.Http;

namespace Tavstal.PayPalSDK.Models.Subscriptions;

/// <summary>
/// Represents a request to retrieve a list of subscription plans.
/// </summary>
public class PlanListRequest : HttpRequestBase<PlanListBody>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanListRequest"/> class.
    /// </summary>
    /// <param name="productId">The optional product ID to filter the subscription plans.</param>
    /// <param name="pageSize">The number of items per page in the response. Default is 10.</param>
    /// <param name="page">The page number to retrieve. Default is 1.</param>
    /// <param name="totalRequired">Indicates whether the total count of items is required in the response. Default is <c>false</c>.</param>
    public PlanListRequest(string? productId = null, int pageSize = 10, int page = 1, bool totalRequired = false)
        : base(
            HttpMethod.Get,
            $"/v1/billing/plans?page_size={pageSize}&page={page}&total_required={totalRequired}{(productId != null ? $"&product_id={productId}" : "")}"
        )
    {
    }
}