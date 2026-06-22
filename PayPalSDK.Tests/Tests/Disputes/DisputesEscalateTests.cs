using System.Net;
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Disputes;

public class DisputesEscalateTests : TestBase
{
    public DisputesEscalateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Disputes/Escalate/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Escalate Dispute to Claim")]
    public async Task Escalate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<DisputeEscalateRequestBody>();
        body.Should().NotBeNull();
        
        var request = new DisputeEscalateRequest("PP-000-000-651-454", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Links: " + objectResponse!.Links!.Count);
    }
}