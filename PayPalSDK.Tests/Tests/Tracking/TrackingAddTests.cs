using System.Net;
using Tavstal.PayPalSDK.Models.Tracking;
using Tavstal.PayPalSDK.Models.Tracking.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Tracking;

public class TrackingAddTests : TestBase
{
    public TrackingAddTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Tracking/Add/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 201 - Add Tracking Information")]
    public async Task TrackingAdd_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<TrackingAddRequestBody>();
        body.Should().NotBeNull();
        
        var request = new TrackingAddRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Count: " + objectResponse!.TrackerIdentifiers!.Count);
    }
}