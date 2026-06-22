using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Models.Orders.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.Orders;

public class AuthorizePaymentForOrderTests : TestBase
{
    public AuthorizePaymentForOrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Orders/AuthorizePayment/sample1.json", "Resources/Orders/AuthorizePayment/sample2.json",
        "Resources/Orders/AuthorizePayment/sample3.json", "Resources/Orders/AuthorizePayment/sample4.json", "Resources/Orders/AuthorizePayment/sample5.json", "Resources/Orders/AuthorizePayment/sample6.json"]) { }
    

    [Fact(DisplayName = "Sample 1 - 201 - Authorize Order - PayPal Wallet as Payment Source")]
    public async Task AuthorizePayment_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderAuthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAuthorizeRequest("5O190127TN364715T", body!);

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
    
    [Fact(DisplayName = "Sample 2 - 200 - Authorize Order - Idempotent Response with PayPal Wallet")]
    public async Task AuthorizePayment_Sample2()
    {
        var resource = _resources[1];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderAuthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAuthorizeRequest("5O190127TN364715T", body!);

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
    
    [Fact(DisplayName = "Sample 3 - 201 - Authorize Order - PayPal Wallet Vault ID")]
    public async Task AuthorizePayment_Sample3()
    {
        var resource = _resources[2];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderAuthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAuthorizeRequest("5O190127TN364715T", body!);

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
    
    [Fact(DisplayName = "Sample 4 - 403 - Authorize Order - 403 Forbidden Error - Charity is not confirmed")]
    public async Task AuthorizePayment_Sample4()
    {
        var resource = _resources[3];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderAuthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAuthorizeRequest("5O190127TN364715T", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        var orderResponse = await response.Content.ReadJsonAsync<ErrorResponse>();
        orderResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("Error Name: " + orderResponse!.Name);
        _testOutputHelper.WriteLine("Error Message: " + orderResponse.Message);
    }
    
    [Fact(DisplayName = "Sample 5 - 422 - Authorize Order - 422 - Payer Action Required")]
    public async Task AuthorizePayment_Sample5()
    {
        var resource = _resources[4];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderAuthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAuthorizeRequest("5O190127TN364715T", body!);

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
    
    [Fact(DisplayName = "Sample 6 - 422 - Authorize Order - 422 Unprocessable Entity Error - Payment Denied")]
    public async Task AuthorizePayment_Sample6()
    {
        var resource = _resources[5];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<OrderAuthorizeRequestBody>();
        body.Should().NotBeNull();
        
        var request = new OrderAuthorizeRequest("5O190127TN364715T", body!);

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