# Product Catalog API Examples

The Product Catalog API allows you to create and manage products in your catalog.

## Create Product

Create a new product in the catalog.

```csharp
using Tavstal.PayPalSDK.Models.ProductCatalog;
using Tavstal.PayPalSDK.Models.ProductCatalog.Bodies;

// Create product
var body = new ProductBody
{
    Name = "Laptop",
    Type = "PHYSICAL",
    Category = "ELECTRONICS",
    Description = "High-performance laptop"
};

// Create the product
var request = new ProductCreateRequest(body);
var response = await client.SendAsync(request);

// Parse the response
var product = await request.GetResponseBodyAsync(response);

Console.WriteLine($"Product ID: {product?.Id}");
Console.WriteLine($"Name: {product?.Name}");
```

## Get Product

Retrieve details about a specific product.

```csharp
using Tavstal.PayPalSDK.Models.ProductCatalog;

// Get product details
var request = new ProductGetRequest("PROD-123456");
var response = await client.SendAsync(request);

// Parse the response
var product = await request.GetResponseBodyAsync(response);

Console.WriteLine($"Product ID: {product?.Id}");
Console.WriteLine($"Name: {product?.Name}");
Console.WriteLine($"Type: {product?.Type}");
```

## List Products

List all products in the catalog.

```csharp
using Tavstal.PayPalSDK.Models.ProductCatalog;

// List products
var request = new ProductListRequest();

var response = await client.SendAsync(request);

// Parse the response
var products = await request.GetResponseBodyAsync(response);

if (products?.Products != null)
{
    foreach (var product in products.Products)
    {
        Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}");
    }
}
```

## Update Product

Update an existing product.

```csharp
using Tavstal.PayPalSDK.Models.ProductCatalog;
using Tavstal.PayPalSDK.Models.ProductCatalog.Bodies;

// Create update request
List<UpdateOperation> body =
[
    new UpdateOperation
    {
        Op = "replace",
        Path = "/description",
        Value = "Premium video streaming service"
    }
];

// Update the product
var request = new ProductUpdateRequest("PROD-123456", body);
var response = await client.SendAsync(request);

Console.WriteLine("Product updated successfully");
```

