using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Invoices;
using Tavstal.PayPalSDK.Models.Invoices.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Invoices;

public class InvoiceSendTests : TestBase
{
    public InvoiceSendTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Invoices/Send/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 202 - Schedules the invoice when the issue date is in future.")]
    public async Task InvoiceSend_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<InvoiceSendRequestBody>();
        body.Should().NotBeNull();
        
        var request = new InvoiceSendRequest("INV2-EHNV-LJ5S-A7DZ-V6NJ", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        var objectResponse = await response.Content.ReadJsonAsync<Link>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Url: " + objectResponse!.Href);
    }
}