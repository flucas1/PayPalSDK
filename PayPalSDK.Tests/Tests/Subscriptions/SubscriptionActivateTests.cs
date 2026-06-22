using System.Net;
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Subscriptions;

public class SubscriptionActivateTests : TestBase
{
    public SubscriptionActivateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Subscriptions/Activate/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 204 - Activate subscription")]
    public async Task SubscriptionActivate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<SubscriptionCreateRequestBody>();
        body.Should().NotBeNull();
        
        var request = new SubscriptionActivateRequest("I-BW452GLLEP1G", "Test");

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Subscription activated successfully");
    }
}