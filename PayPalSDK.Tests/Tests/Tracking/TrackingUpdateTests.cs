using System.Net;
using Tavstal.PayPalSDK.Models.Tracking;
using Tavstal.PayPalSDK.Models.Tracking.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Tracking;

public class TrackingUpdateTests : TestBase
{
    public TrackingUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Tracking/Update/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 204 - Cancel Tracking Information")]
    public async Task TrackingUpdate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<Tracker>();
        body.Should().NotBeNull();
        
        var request = new TrackingUpdateRequest("8MC585209K746392H-443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
       
        _testOutputHelper.WriteLine("Successfully updated the tracking show.");
    }
}