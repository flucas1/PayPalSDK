using System.Net;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Models.Orders.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class ReceiveUpdaterOrderTests : TestBase
{
    public ReceiveUpdaterOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/ReceiveUpdated/sample1.json", "Resources/Orders/ReceiveUpdated/sample2.json", 
        "Resources/Orders/ReceiveUpdated/sample3.json", "Resources/Orders/ReceiveUpdated/sample4.json", "Resources/Orders/ReceiveUpdated/sample5.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Discount Code Callback Request - Adding a Discount Code")]
    public async Task ReceiveUpdaterOrder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderUpdateCallbackRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderReceiveUpdateCallback(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
    }
    
    [Fact(DisplayName = "Sample 2 - 200 - Discount Code Callback Request - Adding a Discount Code - No Address")]
    public async Task ReceiveUpdaterOrder_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderUpdateCallbackRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderReceiveUpdateCallback(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
    }
    
    [Fact(DisplayName = "Sample 3 - 200 - Discount Code Callback Request - Removing a Discount Code")]
    public async Task ReceiveUpdaterOrder_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderUpdateCallbackRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderReceiveUpdateCallback(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
    }
    
    [Fact(DisplayName = "Sample 4 - 200 - Shipping Options Callback Request - Shipping Address Only Event")]
    public async Task ReceiveUpdaterOrder_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderUpdateCallbackRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderReceiveUpdateCallback(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
    }
    
    [Fact(DisplayName = "Sample 5 - 200 - Shipping Options Callback Request - Shipping Address and Shipping Options Event")]
    public async Task ReceiveUpdaterOrder_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderUpdateCallbackRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderReceiveUpdateCallback(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var orderResponse = await response.Content.ReadJsonAsync<OrderBody>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Order ID: " + orderResponse!.Id);
        _testOutputHelper.WriteLine("Order Status: " + orderResponse.Status);
    }
}