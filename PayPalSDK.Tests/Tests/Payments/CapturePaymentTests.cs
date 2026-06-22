using System.Net;
using Tavstal.PayPalSDK.Models.Payments;
using Tavstal.PayPalSDK.Models.Payments.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Payments;

public class CapturePaymentTests : TestBase
{
    public CapturePaymentTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Payments/Capture/sample1.json", "Resources/Payments/Capture/sample2.json", 
        "Resources/Payments/Capture/sample3.json", "Resources/Payments/Capture/sample4.json", "Resources/Payments/Capture/sample5.json", "Resources/Payments/Capture/sample6.json", 
        "Resources/Payments/Capture/sample7.json", "Resources/Payments/Capture/sample8.json", "Resources/Payments/Capture/sample9.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Captures an authorized payment, by ID.")]
    public async Task CapturePayment_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 2 - 201 - Captures an authorized payment, by ID.")]
    public async Task CapturePayment_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 3 - 400 - This code sample attempts to capture an authorized payment but the request fails because a validation error occurred.")]
    public async Task CapturePayment_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 4 - 401 - Example for unauthorized request.")]
    public async Task CapturePayment_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 5 - 403 - Example for a forbidden request.")]
    public async Task CapturePayment_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 6 - 404 - Example for a request to a resource that does not exist.")]
    public async Task CapturePayment_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 7 - 409 - This code sample attempts to capture an authorized payment but the request fails because a previous call for the given resource is in progress.\n")]
    public async Task CapturePayment_Sample7()
    {
        var resource = _resources[6];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 8 - 422 - This code sample attempts to capture an authorized payment but the request fails because the requested amount exceeds the allowable limit.")]
    public async Task CapturePayment_Sample81()
    {
        var resource = _resources[7];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
    
    [Fact(DisplayName = "Sample 9 - 500 - Example for a request that fails for reasons internal to the server.")]
    public async Task CapturePayment_Sample9()
    {
        var resource = _resources[8];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentCaptureRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentCaptureRequest("2GG279541U471931P", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Invoice ID: " + objectResponse.InvoiceId);
    }
}