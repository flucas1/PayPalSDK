using System.Net;
using Tavstal.PayPalSDK.Models.ProductCatalog;
using Tavstal.PayPalSDK.Models.ProductCatalog.Bodies;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.ProductCatalog;

public class ProductCreateTests : TestBase
{
    public ProductCreateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Products/Create/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 201 - Create Product")]
    public async Task ProductCreate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<ProductBody>();
        body.Should().NotBeNull();
        
        var request = new ProductCreateRequest(body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var objectResponse = await response.Content.ReadJsonAsync<ProductBody>();
        objectResponse.Should().NotBeNull();
        
        _testOutputHelper.WriteLine("ID: " + objectResponse!.Id);
        _testOutputHelper.WriteLine("Name: " + objectResponse.Name);
    }
}