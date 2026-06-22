using System.Net;
using Tavstal.PayPalSDK.Models.Invoices;
using Tavstal.PayPalSDK.Models.Invoices.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Invoices;

public class InvoiceCreateDraftTests : TestBase
{
    public InvoiceCreateDraftTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Invoices/CreateDraft/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 201 - Create Invoice with Theme")]
    public async Task InvoiceCreateDraft_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<InvoiceCreateDraftRequestBody>();
        body.Should().NotBeNull();
        
        var request = new InvoiceCreateDraftRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
    }
}