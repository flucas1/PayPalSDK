using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class UpdateTrackingForOrderTests : TestBase
{
    public UpdateTrackingForOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/UpdateTracking/sample1.json", "Resources/Orders/UpdateTracking/sample2.json", 
        "Resources/Orders/UpdateTracking/sample3.json", "Resources/Orders/UpdateTracking/sample4.json", "Resources/Orders/UpdateTracking/sample5.json", "Resources/Orders/UpdateTracking/sample6.json", 
        "Resources/Orders/UpdateTracking/sample7.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 204 - Patch Tracking Information - Replace the Status of the Tracker.")]
    public async Task UpdateTrackingForOrder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Tracking information updated successfully, and the payer has been notified about the shipment.");
    }
    
    [Fact(DisplayName = "Sample 2 - 204 - Patch Tracking Information - Add Notification for a Shipment.")]
    public async Task UpdateTrackingForOrder_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Tracking information updated successfully, and the payer has been notified about the shipment.");
    }
    
    [Fact(DisplayName = "Sample 3 - 400 - Patch Tracking Information - 400 Bad Request Error - Invalid Request.")]
    public async Task UpdateTrackingForOrder_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().Be("[]");
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", null!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 403 - Patch Tracking Information - 403 Forbidden.")]
    public async Task UpdateTrackingForOrder_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 404 - Patch Tracking Information - 404 Not Found Error - Tracker ID Not Found.")]
    public async Task UpdateTrackingForOrder_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 422 - Patch Tracking Information - 422 UNPROCESSABLE ENTITY Error - Cannot patch cancelled tracker.")]
    public async Task UpdateTrackingForOrder_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 7 - 500 - Patch Tracking Information - 500 Internal Server Error.")]
    public async Task UpdateTrackingForOrder_Sample7()
    {
        var resource = _resources[6];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new OrderUpdateTrackingRequest("5O190127TN364715T", "8MC585209K746392H443844607820", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
}