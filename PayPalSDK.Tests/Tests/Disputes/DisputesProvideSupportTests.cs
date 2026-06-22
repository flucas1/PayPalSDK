using System.Net;
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Disputes;

public class DisputesProvideSupportTests : TestBase
{
    public DisputesProvideSupportTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Disputes/ProvideSupport/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Provide Supporting Information for Dispute")]
    public async Task ProvideSupport_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<DisputeProvideSupportRequestBody>();
        body.Should().NotBeNull();
        
        var request = new DisputeProvideSupportRequest("PP-R-TWP-23605903", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Links: " + objectResponse!.Links!.Count);
    }
}