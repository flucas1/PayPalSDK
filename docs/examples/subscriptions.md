# Subscriptions API Examples

The Subscriptions API allows you to create and manage billing plans and subscriptions.

## Create Subscription

Create a subscription for a billing plan.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;

// Create subscription
var body = new SubscriptionCreateRequestBody
{
    PlanId = "P-1234567890",
    Subscriber = new Subscriber
    {
        EmailAddress = "subscriber@example.com"
    },
    StartTime = DateTime.UtcNow.AddDays(1).ToString("o")
};

// Create the subscription
var request = new SubscriptionCreateRequest(body);
var response = await client.SendAsync(request);

// Parse the response
var subscription = await request.GetResponseBodyAsync(response);

Console.WriteLine($"Subscription ID: {subscription?.Id}");
Console.WriteLine($"Status: {subscription?.Status}");
```

## Show Subscription

Retrieve details about a specific subscription.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;

// Get subscription details
var request = new SubscriptionShowRequest("I-5GBDL7NLCYDYA");
var response = await client.SendAsync(request);

// Parse the response
var subscription = await request.GetResponseBodyAsync(response);

Console.WriteLine($"Subscription ID: {subscription?.Id}");
Console.WriteLine($"Status: {subscription?.Status}");
Console.WriteLine($"Plan ID: {subscription?.PlanId}");
```

## List Subscriptions

List subscriptions with optional filtering.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;

// List subscriptions
var request = new SubscriptionListRequest();

var response = await client.SendAsync(request);

// Parse the response
var subscriptions = await request.GetResponseBodyAsync(response);

 if (subscriptions?.Subscriptions != null)
     foreach (var sub in subscriptions.Subscriptions)
         Console.WriteLine($"Subscription ID: {sub.Id}, Status: {sub.Status}");
```

## Update Subscription

Update an existing subscription.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;

// Create update request
List<UpdateOperation> body =
    [
        new()
        {
            Op = "replace",
            Path = "/plan/billing_cycles/@sequence==1/pricing_scheme/fixed_price",
            Value = new Money
            {
                CurrencyCode = "USD",
                Value = "50.00"
            }
        }
    ];

// Update the subscription
var request = new SubscriptionUpdateRequest("I-5GBDL7NLCYDYA", body);
var response = await client.SendAsync(request);

Console.WriteLine("Subscription updated successfully");
```

## Revise Subscription

Revise the subscription plan and pricing.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;

// Create revision request
var body = new SubscriptionReviseRequestBody
{
    // Specify what to revise
};

// Revise the subscription
var request = new SubscriptionReviseRequest("I-5GBDL7NLCYDYA", body);
var response = await client.SendAsync(request);

Console.WriteLine("Subscription revised successfully");
```

## Suspend Subscription

Suspend an active subscription.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;

// Suspend the subscription
var request = new SubscriptionSuspendRequest("I-5GBDL7NLCYDYA", "Customer requested suspension");
var response = await client.SendAsync(request);

Console.WriteLine("Subscription suspended successfully");
```

## Cancel Subscription

Cancel a subscription.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;


// Cancel the subscription
var request = new SubscriptionCancelRequest("I-5GBDL7NLCYDYA", "Customer requested cancellation");
var response = await client.SendAsync(request);

Console.WriteLine("Subscription cancelled successfully");
```

## Activate Subscription

Reactivate a suspended or cancelled subscription.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;

// Activate the subscription
var request = new SubscriptionActivateRequest("I-5GBDL7NLCYDYA", "Customer wants to reactivate");
var response = await client.SendAsync(request);

Console.WriteLine("Subscription activated successfully");
```

## Capture Subscription Payment

Manually capture a subscription payment.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Subscriptions.Bodies;

// Create capture request
var body = new SubscriptionCaptureRequestBody
{
    Note = "Charging as the balance reached the limit",
    CaptureType = "OUTSTANDING_BALANCE",
    Amount = new Money
    {
        CurrencyCode = "USD",
        Value = "10.00"
    }
};

// Capture payment
var request = new SubscriptionCaptureRequest("I-5GBDL7NLCYDYA", body);
var response = await client.SendAsync(request);

Console.WriteLine("Subscription payment captured successfully");
```

## List Subscription Transactions

List transactions for a subscription.

```csharp
using Tavstal.PayPalSDK.Models.Subscriptions;

// List subscription transactions
var request = new SubscriptionListTransactionRequest("I-5GBDL7NLCYDYA", "2018-01-21T07:50:20.940Z", "2018-08-21T07:50:20.940Z");

var response = await client.SendAsync(request);

// Parse the response
var transactions = await request.GetResponseBodyAsync(response);

if (transactions?.Transactions != null)
{
    foreach (var transaction in transactions.Transactions)
    {
        Console.WriteLine($"Transaction ID: {transaction.Id}");
        Console.WriteLine($"Amount: {transaction.AmountWithBreakdown?.GrossAmount?.Value}");
    }
}
```

