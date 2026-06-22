using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class UpdateOrderTests : TestBase
{
    public UpdateOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/Update/sample1.json", "Resources/Orders/Update/sample2.json",
        "Resources/Orders/Update/sample3.json", "Resources/Orders/Update/sample4.json", "Resources/Orders/Update/sample5.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 204 - Patch Order - Add Shipping Address")]
    public async Task UpdateOrder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNull();
        List<UpdateOperation>? operations = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        operations.Should().NotBeNull();
        
        var request = new OrderUpdateRequest("5O190127TN364715T", operations!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Order updated successfully.");
    }
    
    [Fact(DisplayName = "Sample 2 - 204 - Patch Order - Replace Amount")]
    public async Task UpdateOrder_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNull();
        List<UpdateOperation>? operations = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        operations.Should().NotBeNull();
        
        var request = new OrderUpdateRequest("5O190127TN364715T", operations!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Order updated successfully.");
    }
    
    [Fact(DisplayName = "Sample 3 - 204 - Patch Order - Add Items and Replace Amount")]
    public async Task UpdateOrder_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNull();
        List<UpdateOperation>? operations = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        operations.Should().NotBeNull();
        
        var request = new OrderUpdateRequest("5O190127TN364715T", operations!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Order updated successfully.");
    }
    
    [Fact(DisplayName = "Sample 4 - 400 - Patch Order - 400 Bad Request Error - Shipping Address Invalid")]
    public async Task UpdateOrder_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().Be("[]");
        var request = new OrderUpdateRequest("5O190127TN364715T", null!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 422 - Patch Order - 422 Unprocessable Entity Error - Payer Patch Not Allowed")]
    public async Task UpdateOrder_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNull();
        List<UpdateOperation>? operations = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        operations.Should().NotBeNull();
        
        var request = new OrderUpdateRequest("5O190127TN364715T", operations!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
}