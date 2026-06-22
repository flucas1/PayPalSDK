using System.Net;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;
using Tavstal.PayPalSDK.Models.Subscriptions.Plan;
using Tavstal.PayPalSDK.Models.Subscriptions.Plan.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Subscriptions.Plan;

public class SubscriptionPlanCreateTests : TestBase
{
    public SubscriptionPlanCreateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Subscriptions/Plan/Create/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 201 - Create Flat Plan")]
    public async Task SubscriptionPlanCreate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<SubscriptionPlanCreateRequestBody>();
        body.Should().NotBeNull();
        
        var request = new SubscriptionPlanCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await response.Content.ReadJsonAsync<SubscriptionBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
    }
}