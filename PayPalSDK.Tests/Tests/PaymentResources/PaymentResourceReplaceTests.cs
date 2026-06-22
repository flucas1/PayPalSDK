using System.Net;
using Tavstal.PayPalSDK.Models.PaymentResources;
using Tavstal.PayPalSDK.Models.PaymentResources.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.PaymentResources;

public class PaymentResourceReplaceTests : TestBase
{
    public PaymentResourceReplaceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/PaymentResources/Replace/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 204 - Update fixed price payment resource without variants")]
    public async Task PaymentResourceReplace_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentResourceReplaceRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentResourceReplaceRequest("PLB-X7MNK9P2QR8T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Payment resource replaced successfully");
    }
}