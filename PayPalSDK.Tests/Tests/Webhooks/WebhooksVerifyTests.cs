using System.Net;
using Tavstal.PayPalSDK.Models.Webhooks;
using Tavstal.PayPalSDK.Models.Webhooks.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Webhooks;

public class WebhooksVerifyTests : TestBase
{
    public WebhooksVerifyTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Webhooks/Verify/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Verify Webhook Signature")]
    public async Task WebhooksVerify_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<WebhookVerifyRequestBody>();
        body.Should().NotBeNull();
        
        var request = new WebhookVerifyRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<WebhookVerifyResponseBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Status: " + objectResponse!.VerificationStatus);
    }
}