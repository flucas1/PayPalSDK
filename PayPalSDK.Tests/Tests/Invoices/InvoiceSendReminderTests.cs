using System.Net;
using Tavstal.PayPalSDK.Models.Invoices;
using Tavstal.PayPalSDK.Models.Invoices.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Invoices;

public class InvoiceSendReminderTests : TestBase
{
    public InvoiceSendReminderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Invoices/SendReminder/sample1.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 204 - Remind Payer to Pay Invoice")]
    public async Task InvoiceSendReminder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<InvoiceSendReminderRequestBody>();
        body.Should().NotBeNull();
        
        var request = new InvoiceSendReminderRequest("INV2-Z56S-5LLA-Q52L-CPZ5", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Invoice reminder sent successfully.");
    }
}