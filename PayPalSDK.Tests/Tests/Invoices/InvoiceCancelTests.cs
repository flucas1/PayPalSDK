using System.Net;
using Tavstal.PayPalSDK.Models.Invoices;
using Tavstal.PayPalSDK.Models.Invoices.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Invoices;

public class InvoiceCancelTests : TestBase
{
    public InvoiceCancelTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Invoices/Cancel/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 204 - Cancel Invoice")]
    public async Task InvoiceCancel_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<InvoiceCancelRequestBody>();
        body.Should().NotBeNull();
        
        var request = new InvoiceCancelRequest("INV2-Z56S-5LLA-Q52L-CPZ5", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        _testOutputHelper.WriteLine("Successfully cancelled Invoices.");
    }
}