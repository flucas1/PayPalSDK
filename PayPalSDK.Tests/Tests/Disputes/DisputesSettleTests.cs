using System.Net;
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Disputes;

public class DisputesSettleTests : TestBase
{
    public DisputesSettleTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Disputes/Settle/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Settle Dispute")]
    public async Task Settle_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<DisputeSettleRequestBody>();
        body.Should().NotBeNull();
        
#pragma warning disable CS0618 // Type or member is obsolete
        var request = new DisputeSettleRequest("PP-D-27803", body!);
#pragma warning restore CS0618 // Type or member is obsolete

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Links: " + objectResponse!.Links!.Count);
    }
}