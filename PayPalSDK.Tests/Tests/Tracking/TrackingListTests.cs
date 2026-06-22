using System.Net;
using Tavstal.PayPalSDK.Models.Tracking;
using Tavstal.PayPalSDK.Models.Tracking.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Tracking;

public class TrackingListTests : TestBase
{
    public TrackingListTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Tracking/List/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Show Tracking Information")]
    public async Task TrackingList_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<TrackingAddRequestBody>();
        body.Should().NotBeNull();
        
        var request = new TrackingListRequest("8MC585209K746392H", accountId: "TELFDNSFY96RY");

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.TransactionId);
    }
}