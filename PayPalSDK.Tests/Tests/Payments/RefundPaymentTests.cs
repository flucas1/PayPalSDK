using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Payments;
using Tavstal.PayPalSDK.Models.Payments.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Payments;

public class RefundPaymentTests : TestBase
{
    public RefundPaymentTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Payments/Refund/sample1.json", "Resources/Payments/Refund/sample2.json", 
        "Resources/Payments/Refund/sample3.json", "Resources/Payments/Refund/sample4.json", "Resources/Payments/Refund/sample5.json", "Resources/Payments/Refund/sample6.json", 
        "Resources/Payments/Refund/sample7.json", "Resources/Payments/Refund/sample8.json", "Resources/Payments/Refund/sample9.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Refunds a captured payment, by ID.")]
    public async Task RefundPayment_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<RefundPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
        objectResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in objectResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 2 - 201 - Refunds a captured payment, by ID.")]
    public async Task RefundPayment_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await response.Content.ReadJsonAsync<RefundPaymentBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Status: " + objectResponse.Status);
        objectResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in objectResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 3 - 400 - This code sample attempts to refund a captured payment, but the request fails because a validation error occurred.")]
    public async Task RefundPayment_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 401 - Example for unauthorized request.\n")]
    public async Task RefundPayment_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 403 - Example for a forbidden request.")]
    public async Task RefundPayment_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 404 - Example for a request to a resource that does not exist.")]
    public async Task RefundPayment_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 7 - 409 - This code sample attempts to refund a captured payment but the request fails because a previous call for the given resource is in progress.")]
    public async Task RefundPayment_Sample7()
    {
        var resource = _resources[6];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 8 - 422 - This code sample attempts to refund a captured payment, but the request fails because the refund amount has exceeded the capture amount.")]
    public async Task RefundPayment_Sample8()
    {
        var resource = _resources[7];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 9 - 500 - Example for a request that fails for reasons internal to the server.")]
    public async Task RefundPayment_Sample9()
    {
        var resource = _resources[8];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentRefundRequestBody>();
        body.Should().NotBeNull();
        
        var request = new PaymentRefundRequest("0K35355239430361V", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
}