using System.Net;
using Tavstal.PayPalSDK.Models.Webhooks;
using Tavstal.PayPalSDK.Models.Webhooks.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Webhooks;

public class WebhooksCreateTests : TestBase
{
    public WebhooksCreateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Webhooks/Create/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 201 - Create Webhook")]
    public async Task WebhooksCreate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<WebhookCreateRequestBody>();
        body.Should().NotBeNull();
        
        var request = new WebhookCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await response.Content.ReadJsonAsync<WebhookBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Url: " + objectResponse.Url);
    }
}