using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Webhooks;
using Tavstal.PayPalSDK.Models.Webhooks.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Webhooks;

public class WebhooksUpdateTests : TestBase
{
    public WebhooksUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Webhooks/Update/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 200 - Update Webhook")]
    public async Task WebhooksUpdate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new WebhookUpdateRequest("0EH40505U7160970P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<WebhookBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Url: " + objectResponse.Url);
    }
}