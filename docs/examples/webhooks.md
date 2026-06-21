# Webhooks API Examples

The Webhooks API allows you to create, manage, and verify webhooks for event notifications.

## Create Webhook

Create a webhook to receive event notifications.

```csharp
using Tavstal.PayPalSDK.Models.Webhooks;
using Tavstal.PayPalSDK.Models.Webhooks.Bodies;

// Create webhook
var body = new WebhookCreateRequestBody
{
    Url = "https://example.com/webhook",
    EventTypes =
        [
            new() { Name = "PAYMENT.SALE.COMPLETED" }, new() { Name = "PAYMENT.SALE.DENIED" }
        ]
};

// Create the webhook
var request = new WebhookCreateRequest(body);
var response = await client.SendAsync(request);

// Parse the response
var webhook = await request.GetResponseBodyAsync(response);

Console.WriteLine($"Webhook ID: {webhook?.Id}");
Console.WriteLine($"URL: {webhook?.Url}");
```

## Get Webhook

Retrieve details about a specific webhook.

```csharp
using Tavstal.PayPalSDK.Models.Webhooks;

// Get webhook details
var request = new WebhookGetRequest("WH-123456789");
var response = await client.SendAsync(request);

// Parse the response
var webhook = await request.GetResponseBodyAsync(response);

Console.WriteLine($"Webhook ID: {webhook?.Id}");
Console.WriteLine($"URL: {webhook?.Url}");
```

## List Webhooks

List all webhooks.

```csharp
using Tavstal.PayPalSDK.Models.Webhooks;

// List webhooks
var request = new WebhookListRequest();

var response = await client.SendAsync(request);

// Parse the response
var webhooks = await request.GetResponseBodyAsync(response);

if (webhooks?.Webhooks != null)
{
    foreach (var webhook in webhooks.Webhooks)
    {
        Console.WriteLine($"Webhook ID: {webhook.Id}, URL: {webhook.Url}");
    }
}
```

## Update Webhook

Update an existing webhook.

```csharp
using Tavstal.PayPalSDK.Models.Webhooks;
using Tavstal.PayPalSDK.Models.Webhooks.Bodies;

// Create body
List<UpdateOperation> body =
    [
        new()
        {
            Op = "replace",
            Path = "/url",
            Value = "https://example.com/example_webhook_2"
        }
    ];

// Update the webhook
var request = new WebhookUpdateRequest("WH-123456789", body);
var response = await client.SendAsync(request);

Console.WriteLine("Webhook updated successfully");
```

## Delete Webhook

Delete a webhook.

```csharp
using Tavstal.PayPalSDK.Models.Webhooks;

// Delete the webhook
var request = new WebhookDeleteRequest("WH-123456789");
var response = await client.SendAsync(request);

Console.WriteLine("Webhook deleted successfully");
```

## Verify Webhook Signature

Verify the authenticity of a webhook notification.

```csharp
using Tavstal.PayPalSDK.Models.Webhooks;
using Tavstal.PayPalSDK.Models.Webhooks.Bodies;

// Prepare verification data
var body = new WebhookVerifyRequestBody
{
     TransmissionId  = "69cd13f0-d67a-11e5-baa3-778b53f4ae55",
     TransmissionTime = "2016-02-18T20:01:35Z",
     CertUrl         = "cert_url",
     AuthAlgo        = "SHA256withRSA",
     TransmissionSig = "lmI95Jx3Y9nhR5SJWlHVIWpg4AgFk7n9bCHSRxbrd8A9zrhdu2rMyFrmz+Zjh3s3boXB07VXCXUZy/UFzUlnGJn0wDugt7FlSvdKeIJenLRemUxYCPVoEZzg9VFNqOa48gMkvF+XTpxBeUx/kWy6B5cp7GkT2+pOowfRK7OaynuxUoKW3JcMWw272VKjLTtTAShncla7tGF+55rxyt2KNZIIqxNMJ48RDZheGU5w1npu9dZHnPgTXB9iomeVRoD8O/jhRpnKsGrDschyNdkeh81BJJMH4Ctc6lnCCquoP/GzCzz33MMsNdid7vL/NIWaCsekQpW26FpWPi/tfj8nLA==",
     WebhookId       = "1JE4291016473214C",
     WebhookEvent    = new WebhookEvent
     {
         EventVersion = "",
         ResourceVersion = ""
     }
};

// Verify the webhook
var request = new WebhookVerifyRequest(body);
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine(result?.VerificationStatus == "SUCCESS"
            ? "Webhook signature verified successfully"
            : "Webhook signature verification failed");
```
