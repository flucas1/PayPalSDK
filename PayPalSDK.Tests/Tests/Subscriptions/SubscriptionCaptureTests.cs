using System.Net;
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Subscriptions;

public class SubscriptionCaptureTests : TestBase
{
    public SubscriptionCaptureTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Subscriptions/Capture/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 202 - Capture Payment for Subscription")]
    public async Task SubscriptionCapture_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<SubscriptionCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new SubscriptionCaptureRequest("I-BW452GLLEP1G", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        
        _testOutputHelper.WriteLine("Subscription capture request sent successfully.");
    }
}