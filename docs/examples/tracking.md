# Tracking API Examples

The Tracking API allows you to add and update shipment tracking information for orders.

## Add Tracking

Add tracking information for a shipment.

```csharp
using Tavstal.PayPalSDK.Models.Tracking;
using Tavstal.PayPalSDK.Models.Tracking.Bodies;

// Create tracking details
var trackingInfo = new Tracker
{
    TransactionId = "ABC123DEF456",
    TrackingNumber = "1Z999AA10123456784",
    Carrier = "FEDEX"
};

// Create the request to add tracking
var body = new TrackingAddRequestBody
{
    Trackers = [trackingInfo]
};

var request = new TrackingAddRequest(body);
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Tracking information added successfully");
Console.WriteLine($"Tracker IDs: {result?.TrackerIdentifiers?.Count}");
```

## List Tracking

Retrieve tracking information for a transaction.

```csharp
using Tavstal.PayPalSDK.Models.Tracking;

// List tracking information for a transaction
var request = new TrackingListRequest(
    transactionId: "ABC123DEF456",
    trackingNumber: "1Z999AA10123456784"
);

var response = await client.SendAsync(request);

// Parse the response
var trackingInfo = await request.GetResponseBodyAsync(response);
Console.Write($"Carrier: {trackingInfo!.Carrier}");
```

## Update Tracking

Update existing tracking information.

```csharp
using Tavstal.PayPalSDK.Models.Tracking;
using Tavstal.PayPalSDK.Models.Tracking.Bodies;

// Create updated tracking information
var updatedTracker = new Tracker
{
    TransactionId = "ABC123DEF456",
    TrackingNumber = "1Z999AA10123456784",
    Carrier = "FEDEX",
    Status = "SHIPPED"
};

// Update the tracking
var request = new TrackingUpdateRequest("tracker-id-123", updatedTracker);
var response = await client.SendAsync(request);

Console.WriteLine("Tracking information updated successfully");
```

