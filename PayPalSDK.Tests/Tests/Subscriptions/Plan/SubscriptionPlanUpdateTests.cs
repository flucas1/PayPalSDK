using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Subscriptions.Plan;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Subscriptions.Plan;

public class SubscriptionPlanUpdateTests : TestBase
{
    public SubscriptionPlanUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Subscriptions/Plan/Update/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 204 - Patch a plan")]
    public async Task SubscriptionPlanUpdate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new SubscriptionPlanUpdateRequest("P-7GL4271244454362WXNWU5NQ", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Plan updated successfully.");
    }
}