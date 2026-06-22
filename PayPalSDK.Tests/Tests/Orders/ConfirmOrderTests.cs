using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Models.Orders.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class ConfirmOrderTests : TestBase
{
    public ConfirmOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/Confirm/sample1.json", "Resources/Orders/Confirm/sample2.json",
        "Resources/Orders/Confirm/sample3.json", "Resources/Orders/Confirm/sample4.json", "Resources/Orders/Confirm/sample5.json", "Resources/Orders/Confirm/sample6.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 200 - Confirm Order - PayPal Wallet Resulting in Payer Action Required")]
    public async Task ConfirmOrder_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderConfirmRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderConfirmRequest("5O190127TN364715T", body!);

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

    [Fact(DisplayName = "Sample 2 - 400 - Confirm Order - 400 Bad Request Error - Missing Required Parameter - Payment Source")]
    public async Task ConfirmOrder_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().Be("{}");
        var request = new OrderConfirmRequest("5O190127TN364715T", null!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 3 - 403 - Confirm Order - 403 Forbidden Error -  Invalid PayPal Wallet Vault ID")]
    public async Task ConfirmOrder_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().Be("{}");
        var request = new OrderConfirmRequest("5O190127TN364715T", null!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 4 - 204 - Confirm Order - 404 Not Found Error - Resource Not Found")]
    public async Task ConfirmOrder_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderConfirmRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderConfirmRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        
        _testOutputHelper.WriteLine("No content in response body. Status Code: " + response.StatusCode);
    }
    
    [Fact(DisplayName = "Sample 5 - 422 - Confirm Order - 422 Unprocessable Entity Error -Using Card Vault ID for a PayPal Wallet Payment Source")]
    public async Task ConfirmOrder_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderConfirmRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderConfirmRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 6 - 500 - Confirm Order - 500 Internal Server Error - A system error has occurred")]
    public async Task ConfirmOrder_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);
        
        resource.JsonRequest.Should().Be("{}");
        var request = new OrderConfirmRequest("id", null!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
}