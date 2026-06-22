using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;
using Tavstal.PayPalSDK.Models.Payments;
using Tavstal.PayPalSDK.Models.Payments.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Payments;

public class FindEligiblePaymentsTests : TestBase
{
    public FindEligiblePaymentsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Payments/EligableList/sample1.json", "Resources/Payments/EligableList/sample2.json", 
        "Resources/Payments/EligableList/sample3.json", "Resources/Payments/EligableList/sample4.json", "Resources/Payments/EligableList/sample5.json", "Resources/Payments/EligableList/sample6.json"]) { }
    
    
    [Fact(DisplayName = "Sample 1 - 200 - Eligible Payment Methods - Exclude listed payment methods")]
    public async Task FindEligiblePayments_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentFindEligibleMethodsRequestBody>();
        body.Should().NotBeNull();
        
        var request = new  PaymentFindEligibleMethodsRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await response.Content.ReadJsonAsync<EligibleMethodResponse>();
        objectResponse.Should().NotBeNull();

        _testOutputHelper.WriteLine("Eligible Payment Methods: " + objectResponse?.EligibleMethods?.Venmo?.CanBeVaulted);
    }
    
    [Fact(DisplayName = "Sample 2 - 400 - This request attempts to get payment methods but the request fails as it has invalid length (3 instead of 2) for customer's country_code.")]
    public async Task FindEligiblePayments_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentFindEligibleMethodsRequestBody>();
        body.Should().NotBeNull();
        
        var request = new  PaymentFindEligibleMethodsRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 3 - 401 - Example for unauthorized request.")]
    public async Task FindEligiblePayments_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentFindEligibleMethodsRequestBody>();
        body.Should().NotBeNull();
        
        var request = new  PaymentFindEligibleMethodsRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 403 - Example for a forbidden request.")]
    public async Task FindEligiblePayments_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentFindEligibleMethodsRequestBody>();
        body.Should().NotBeNull();
        
        var request = new  PaymentFindEligibleMethodsRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 422 - This request attempts to get payment methods but the request fails because the currency code passed doesn't exist.")]
    public async Task FindEligiblePayments_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentFindEligibleMethodsRequestBody>();
        body.Should().NotBeNull();
        
        var request = new  PaymentFindEligibleMethodsRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 500 - Example for a request that fails for reasons internal to the server.")]
    public async Task FindEligiblePayments_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentFindEligibleMethodsRequestBody>();
        body.Should().NotBeNull();
        
        var request = new  PaymentFindEligibleMethodsRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
}