using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Models.Orders.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class AddTrackingForOrderTests : TestBase
{
    public AddTrackingForOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/AddTracking/sample1.json", "Resources/Orders/AddTracking/sample2.json", 
        "Resources/Orders/AddTracking/sample3.json", "Resources/Orders/AddTracking/sample4.json", "Resources/Orders/AddTracking/sample5.json", "Resources/Orders/AddTracking/sample6.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 201 - Add Tracking to Order - Carrier Information and Items Breakdown")]
    public async Task AddTrackingForOrder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderTrackingRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAddTrackingRequest("5O190127TN364715T", body!);

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
    
    [Fact(DisplayName = "Sample 2 - 200 - Add Tracking to Order - Idempotent Response")]
    public async Task AddTrackingForOrder_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderTrackingRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAddTrackingRequest("5O190127TN364715T", body!);

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
    
    [Fact(DisplayName = "Sample 3 - 400 - Add Tracking to Order - 400 Bad Request - Missing Required Parameter")]
    public async Task AddTrackingForOrder_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderTrackingRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAddTrackingRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 403 - Add Tracking to Order - 403 Forbidden - No Permission for the Order")]
    public async Task AddTrackingForOrder_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderTrackingRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAddTrackingRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 422 - Add Tracking to Order - 422 Unprocessable Entity Error - Invalid Capture Status.")]
    public async Task AddTrackingForOrder_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderTrackingRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAddTrackingRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 500 - Add Tracking to Order - 500 Internal Server Error")]
    public async Task AddTrackingForOrder_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderTrackingRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAddTrackingRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
}