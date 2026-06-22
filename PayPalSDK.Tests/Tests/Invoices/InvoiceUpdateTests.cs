using System.Net;
using Tavstal.PayPalSDK.Models.Invoices;
using Tavstal.PayPalSDK.Models.Invoices.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Invoices;

public class InvoiceUpdateTests : TestBase
{
    public InvoiceUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Invoices/Update/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Update Invoice with Theme")]
    public async Task InvoiceUpdate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<InvoiceUpdateRequestBody>();
        body.Should().NotBeNull();
        
        var request = new InvoiceUpdateRequest("INV2-Z56S-5LLA-Q52L-CPZ5", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<InvoiceBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
    }
}