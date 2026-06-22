using System.Net;
using Tavstal.PayPalSDK.Models.Common.Plans;
using Tavstal.PayPalSDK.Models.Subscriptions.Plan;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Subscriptions.Plan;

public class SubscriptionPlanPricingTests : TestBase
{
    public SubscriptionPlanPricingTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Subscriptions/Plan/Pricing/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 204 - Add multiple tiered pricing schemes")]
    public async Task SubscriptionPlanPricing_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<PlanPricingScheme>>();
        body.Should().NotBeNull();
        
        var request = new SubscriptionPlanPricingUpdateRequest("P-7GL4271244454362WXNWU5NQ", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Pricing schemes updated successfully.");
    }
}