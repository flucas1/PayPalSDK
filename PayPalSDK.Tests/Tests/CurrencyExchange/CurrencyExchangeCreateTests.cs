using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.CurrencyExchange;
using Tavstal.PayPalSDK.Models.CurrencyExchange.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.CurrencyExchange;

public class CurrencyExchangeCreateTests : TestBase
{
    public CurrencyExchangeCreateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/CurrencyExchange/Create/sample1.json", "Resources/CurrencyExchange/Create/sample2.json", 
        "Resources/CurrencyExchange/Create/sample3.json", "Resources/CurrencyExchange/Create/sample4.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Exchange Rate Quote")]
    public async Task CreateCurrencyExchange_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<CurrencyExchangeCreateRequestBody>();
        body.Should().NotBeNull();

        var request = new CurrencyExchangeCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var objectResponse = await request.GetResponseBodyAsync(response);
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Count: " + objectResponse!.ExchangeQuoteRates.Count);
    }
    
    [Fact(DisplayName = "Sample 2 - 400 - invalid currency amount")]
    public async Task CreateCurrencyExchange_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<CurrencyExchangeCreateRequestBody>();
        body.Should().NotBeNull();

        var request = new CurrencyExchangeCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 3 - 403 - Exchange Currency for currency code.")]
    public async Task CreateCurrencyExchange_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<CurrencyExchangeCreateRequestBody>();
        body.Should().NotBeNull();

        var request = new CurrencyExchangeCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 500 - Exchange Currency for currency code.")]
    public async Task CreateCurrencyExchange_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<CurrencyExchangeCreateRequestBody>();
        body.Should().NotBeNull();

        var request = new CurrencyExchangeCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var objectResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + objectResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + objectResponse.Message);
    }
}