using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Payments;
using Tavstal.PayPalSDK.Models.Payments.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Payments;

public class ReauthorizePaymentTests : TestBase
{
    public ReauthorizePaymentTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Payments/Reauthorize/sample1.json", "Resources/Payments/Reauthorize/sample2.json", 
        "Resources/Payments/Reauthorize/sample3.json", "Resources/Payments/Reauthorize/sample4.json", "Resources/Payments/Reauthorize/sample5.json", "Resources/Payments/Reauthorize/sample6.json", 
        "Resources/Payments/Reauthorize/sample7.json", "Resources/Payments/Reauthorize/sample8.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Reauthorizes an authorized payment, by ID. ")]
    public async Task ReauthorizePayment_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
        objectResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in objectResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 2 - 201 - Reauthorizes an authorized payment, by ID. ")]
    public async Task ReauthorizePayment_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await response.Content.ReadJsonAsync<CapturedPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
        objectResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in objectResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 3 - 400 - This code sample attempts to reauthorize an authorized payment but the request fails due to a validation error.")]
    public async Task ReauthorizePayment_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 401 - Example for unauthorized request.\n")]
    public async Task ReauthorizePayment_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 403 - Example for a forbidden request.")]
    public async Task ReauthorizePayment_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 404 - Example for a request to a resource that does not exist.")]
    public async Task ReauthorizePayment_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 7 - 422 - This code sample attempts to reauthorize an authorized payment but the request fails because reauthorization currency does not matches with the original authorization currency.")]
    public async Task ReauthorizePayment_Sample7()
    {
        var resource = _resources[6];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 8 - 500 - Example for a request that fails for reasons internal to the server.")]
    public async Task ReauthorizePayment_Sample8()
    {
        var resource = _resources[7];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentReauthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentReauthorizeRequest("8AA831015G517922L", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
}