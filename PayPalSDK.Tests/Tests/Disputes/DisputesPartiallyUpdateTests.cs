using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Disputes;

public class DisputesPartiallyUpdateTests : TestBase
{
    public DisputesPartiallyUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Disputes/PartiallyUpdate/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 204 - Partially Update Dispute by adding partner action - Success")]
    public async Task PartiallyUpdate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new DisputePartiallyUpdateRequest("PP-D-27803", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Successfully updated dispute partially update");
    }
}