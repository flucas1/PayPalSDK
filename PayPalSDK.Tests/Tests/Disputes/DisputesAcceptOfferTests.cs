using System.Net;
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Disputes;

public class DisputesAcceptOfferTests : TestBase
{
    public DisputesAcceptOfferTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Disputes/AcceptOffer/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 202 - Accept Offer to Resolve Dispute - Accepted (202)")]
    public async Task DisputeAcceptOffer_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<DisputeAcceptOfferRequestBody>();
        body.Should().NotBeNull();
        
        var request = new DisputeAcceptOfferRequest("PP-000-000-651-454", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Links: " + objectResponse!.Links!.Count);
    }
}