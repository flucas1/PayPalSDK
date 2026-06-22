using System.Net;
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Subscriptions;

public class SubscriptionReviseTests : TestBase
{
    public SubscriptionReviseTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Subscriptions/Revise/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Upgrade/downgrade subscription - Change Plan")]
    public async Task SubscriptionRevise_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<SubscriptionReviseRequestBody>();
        body.Should().NotBeNull();
        
        var request = new SubscriptionReviseRequest("I-BW452GLLEP1G", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<SubscriptionRevisedBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.PlanId);
    }
}