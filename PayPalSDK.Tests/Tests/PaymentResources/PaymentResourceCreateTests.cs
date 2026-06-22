using System.Net;
using Tavstal.PayPalSDK.Models.PaymentResources;
using Tavstal.PayPalSDK.Models.PaymentResources.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.PaymentResources;

public class PaymentResourceCreateTests : TestBase
{
    public PaymentResourceCreateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/PaymentResources/Create/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 201 - Create fixed price payment resource with return url")]
    public async Task PaymentResourceCreate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentResourceCreateRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentResourceCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
    }
}