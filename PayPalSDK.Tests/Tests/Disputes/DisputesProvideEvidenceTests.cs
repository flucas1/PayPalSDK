using System.Net;
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Disputes;

public class DisputesProvideEvidenceTests : TestBase
{
    public DisputesProvideEvidenceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Disputes/ProvideEvidence/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Provide Evidence for Dispute")]
    public async Task ProvideEvidence_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<DisputeProvideEvidenceRequestBody>();
        body.Should().NotBeNull();
        
        var request = new DisputeProvideEvidenceRequest("PP-D-27803", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Links: " + objectResponse!.Links!.Count);
    }
}