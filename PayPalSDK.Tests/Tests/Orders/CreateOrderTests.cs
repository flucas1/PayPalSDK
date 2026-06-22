using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Models.Orders.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class CreateOrderTests : TestBase
{
    public CreateOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/Create/sample1.json", "Resources/Orders/Create/sample2.json", 
        "Resources/Orders/Create/sample3.json", "Resources/Orders/Create/sample4.json", "Resources/Orders/Create/sample5.json", "Resources/Orders/Create/sample6.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Create Order - PayPal Wallet as Payment Source, Resulting in PAYER_ACTION_REQUIRED Response")]
    public async Task CreateOrder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        OrderCreateRequestBody? body = resource.JsonRequest!.DeserializeJson<OrderCreateRequestBody>();
        body.Should().NotBeNull(); 
        var request = new OrderCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
        orderResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in orderResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }

    [Fact(DisplayName = "Sample 2 - 201 - Create and authorize an order for a PayPal wallet vaulted account holder passing a usage pattern indicator using stored credentials (Single Shot).")]
    public async Task CreateOrder_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        OrderCreateRequestBody? body = resource.JsonRequest!.DeserializeJson<OrderCreateRequestBody>();
        body.Should().NotBeNull(); 
        var request = new OrderCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
        orderResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in orderResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 3 - 201 - Create Order - Minimal Request and Response")]
    public async Task CreateOrder_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        OrderCreateRequestBody? body = resource.JsonRequest!.DeserializeJson<OrderCreateRequestBody>();
        body.Should().NotBeNull(); 
        var request = new OrderCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
        orderResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in orderResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 4 - 201 - Create Order - Buy Online Pickup In Store Shipping Type")]
    public async Task CreateOrder_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        OrderCreateRequestBody? body = resource.JsonRequest!.DeserializeJson<OrderCreateRequestBody>();
        body.Should().NotBeNull(); 
        var request = new OrderCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
        orderResponse.Links.Should().NotBeNull();
        _testOutputHelper.WriteLine("Links: ");
        foreach (var link in orderResponse.Links!)
            _testOutputHelper.WriteLine(link.ToString());
    }
    
    [Fact(DisplayName = "Sample 5 - 400 - Create Order - 400 Bad Request Error - Purchase Unit is Empty")]
    public async Task CreateOrder_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        OrderCreateRequestBody? body = resource.JsonRequest!.DeserializeJson<OrderCreateRequestBody>();
        body.Should().NotBeNull(); 
        var request = new OrderCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
        orderResponse.Details.Should().NotBeNull();
        _testOutputHelper.WriteLine("Error Details: ");
        foreach (var detail in orderResponse.Details!)
            _testOutputHelper.WriteLine(detail.ToString());
    }
    
    [Fact(DisplayName = "Sample 6 - 422 - Create Order - 422 Unprocessable Entity Error - Missing Pickup Address")]
    public async Task CreateOrder_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        OrderCreateRequestBody? body = resource.JsonRequest!.DeserializeJson<OrderCreateRequestBody>();
        body.Should().NotBeNull(); 
        var request = new OrderCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
        orderResponse.Details.Should().NotBeNull();
        _testOutputHelper.WriteLine("Error Details: ");
        foreach (var detail in orderResponse.Details!)
            _testOutputHelper.WriteLine(detail.ToString());

    }
}