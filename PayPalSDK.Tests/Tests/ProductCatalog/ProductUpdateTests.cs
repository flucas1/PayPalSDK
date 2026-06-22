using System.Net;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.ProductCatalog;
using Tavstal.PayPalSDK.Tests.Helpers;
using Xunit.Abstractions;

namespace Tavstal.PayPalSDK.Tests.Tests.ProductCatalog;

public class ProductUpdateTests : TestBase
{
    public ProductUpdateTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, ["Resources/Products/Update/sample1.json"]) { }
    
    [Fact(DisplayName = "Sample 1 - 204 - Patch Product")]
    public async Task ProductUpdate_Sample1()
    {
        var resource = _resources[0];
        var client = FakeHttpHelpers.CreateClient(resource.Responder);

        resource.JsonRequest.Should().NotBeNullOrEmpty();
        var body = resource.JsonRequest!.DeserializeJson<List<UpdateOperation>>();
        body.Should().NotBeNull();
        
        var request = new ProductUpdateRequest("72255d4849af8ed6e0df1173", body!);

        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        
        _testOutputHelper.WriteLine("Successfully Updated");
    }
}