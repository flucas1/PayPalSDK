using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.PaymentMethodTokens;
using Tavstal.PayPalSDK.Models.PaymentMethodTokens.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.PaymentMethodTokens;

public class CreatePaymentTokenTests : TestBase
{
    public CreatePaymentTokenTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/PaymentMethodTokens/Create/sample1.json", "Resources/PaymentMethodTokens/Create/sample2.json", 
        "Resources/PaymentMethodTokens/Create/sample3.json", "Resources/PaymentMethodTokens/Create/sample4.json", "Resources/PaymentMethodTokens/Create/sample5.json", 
        "Resources/PaymentMethodTokens/Create/sample6.json", "Resources/PaymentMethodTokens/Create/sample7.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 201 - Create Payment Token - PayPal Wallet from Setup Token")]
    public async Task CreatePaymentToken_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentTokenCreateRequestBody>();
        body.Should().NotBeNull();

        var request = new PaymentTokenCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
    }
    
    [Fact(DisplayName = "Sample 2 - 200 - Create Payment Token - Card with Full Request - Idempotent")]
    public async Task CreatePaymentToken_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentTokenCreateRequestBody>();
        body.Should().NotBeNull();

        var request = new PaymentTokenCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
    }
    
    [Fact(DisplayName = "Sample 3 - 400 - Create Payment Token - 400 Invalid Request Error - Empty Request Body")]
    public async Task CreatePaymentToken_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().Be("{}");
        var request = new PaymentTokenCreateRequest(null!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 403 - Create Payment Token - 403 Forbidden Error - Merchant Not Onboarded to Vault")]
    public async Task CreatePaymentToken_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<PaymentTokenCreateRequestBody>();
        body.Should().NotBeNull();
       
        var request = new PaymentTokenCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 404 - Create Payment Token - 404 Not Found Error - Setup Token Does Not Exist")]
    public async Task CreatePaymentToken_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        var body = resource.JsonRequest!.DeserializeJson<PaymentTokenCreateRequestBody>();
        body.Should().NotBeNull();
       
        var request = new PaymentTokenCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 422 - Create Payment Token - 422 Unprocessable Entity Error - Inactive Billing Agreement")]
    public async Task CreatePaymentToken_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        var body = resource.JsonRequest!.DeserializeJson<PaymentTokenCreateRequestBody>();
        body.Should().NotBeNull();
       
        var request = new PaymentTokenCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableContent);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 7 - 500 - Create Payment Token - 500 Internal Server Error")]
    public async Task CreatePaymentToken_Sample7()
    {
        var resource = _resources[6];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        var body = resource.JsonRequest!.DeserializeJson<PaymentTokenCreateRequestBody>();
        body.Should().NotBeNull();
       
        var request = new PaymentTokenCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
}