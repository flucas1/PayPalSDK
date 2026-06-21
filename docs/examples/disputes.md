# Disputes API Examples

The Disputes API allows you to manage and resolve payment disputes between buyers and sellers.

## Show Dispute Details

Retrieve detailed information about a specific dispute.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;

// Create a request to retrieve dispute details
var request = new DisputeShowDetailsRequest("PP-D-4012");

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var dispute = await request.GetResponseBodyAsync(response);

// Access dispute information
Console.WriteLine($"Dispute ID: {dispute.DisputeId}");
Console.WriteLine($"Status: {dispute.Status}");
Console.WriteLine($"Reason: {dispute.Reason}");
```

## List Disputes

List all disputes for a given time period with optional filtering.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;

// Create a request to list disputes from a specific start time
var request = new DisputeListRequest("2023-07-22T01:34:47.000Z");

// Optionally filter by transaction ID, dispute state, or date range
var requestWithFilters = new DisputeListRequest(
    startTime: "2023-07-22T01:34:47.000Z",
    disputedTransactionId: "ABC-123",
    page: 1,
    pageSize: 20,
    disputeState: "OPEN"
);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var disputes = await request.GetResponseBodyAsync(response);

// Access dispute list information
Console.WriteLine($"Total Items: {disputes?.Items?.Count}");
foreach (var dispute in disputes?.Items ?? [])
{
    Console.WriteLine($"Dispute ID: {dispute.DisputeId}, Status: {dispute.Status}");
}
```

## Make Offer

Submit a monetary offer to resolve a dispute.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Models.Common.Payments;

// Create the request body with offer details
var body = new DisputeMakeOfferRequestBody
{
    Note = "Please accept this offer to resolve the dispute.",
    OfferAmount = new Money
    {
        CurrencyCode = "USD",
        Value = "50.00"
    },
    OfferType = "REFUND"
};

// Create a request to make an offer for the dispute
var request = new DisputeMakeOfferRequest("PP-R-TWP-23605903", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Offer submitted successfully");
```

## Accept Claim

Accept a buyer's dispute claim and process a refund.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Models.Common.Payments;

// Create the request body with claim acceptance details
var body = new DisputeAcceptClaimRequestBody
{
    Note = "Item was not received. Refund accepted.",
    AcceptClaimReason = "BUYER_COMPLAINT",
    RefundAmount = new Money
    {
        CurrencyCode = "USD",
        Value = "100.00"
    }
};

// Create a request to accept the claim
var request = new DisputeAcceptClaimRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Claim accepted successfully");
```

## Provide Evidence

Submit evidence to defend against a dispute.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;
using Tavstal.PayPalSDK.Models.Common.Disputes;

// Create the request body with evidence
var body = new DisputeProvideEvidenceRequestBody
{
    ReturnShippingAddress = new Address
    {
        AddressLineOne = "14,Kimberly st",
        AddressLineTwo = "Open Road North",
        AdminAreaOne = "Gotham City",
        AdminAreaTwo = "Gotham",
        PostalCode = "124566",
        CountryCode = "US"
    },
    ReturnShippingAddressInfo = new ReturnShippingInfo
    {
        SaveToProfile = false,
        Address = new Address
        {
            AddressLineOne = "14,Kimberly st",
            AddressLineTwo = "Open Road North",
            AdminAreaOne = "Gotham City",
            AdminAreaTwo = "Gotham",
            PostalCode = "124566",
            CountryCode = "US"
        }
    }
};

// Create a request to provide evidence
var request = new DisputeProvideEvidenceRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Evidence submitted successfully");
```

## Accept Offer

Accept a seller's offer to resolve a dispute.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body
var body = new DisputeAcceptOfferRequestBody
{
    Note = "I accept the seller's offer to resolve this dispute."
};

// Create a request to accept the offer
var request = new DisputeAcceptOfferRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Offer accepted successfully");
```

## Deny Offer

Reject a seller's offer to resolve a dispute.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body
var body = new DisputeDenyOfferRequestBody
{
    Note = "The offer is not acceptable. The item was never received."
};

// Create a request to deny the offer
var request = new DisputeDenyOfferRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

Console.WriteLine("Offer denied successfully");
```

## Send Message

Send a message in the dispute conversation.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body with message content
var body = new DisputeSendMessageRequestBody
{
    Message = "I have submitted the proof of delivery to this dispute."
};

// Create a request to send a message
var request = new DisputeSendMessageRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Message sent successfully");
```

## Escalate Dispute

Escalate a dispute to a claim for further investigation.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body
var body = new DisputeEscalateRequestBody
{
    Note = "The buyer and seller could not resolve this dispute. Escalating to PayPal."
};

// Create a request to escalate the dispute
var request = new DisputeEscalateRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Dispute escalated successfully");
```

## Appeal Dispute Resolution

Appeal a dispute resolution outcome.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create a request to appeal the dispute
var request = new DisputeAppealRequest("PP-D-27803");

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Appeal submitted successfully");
```

## Settle Dispute

Settle a dispute (sandbox only).

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body with settlement details
var body = new DisputeSettleRequestBody
{
    AdjudicationOutcome = "BUYER_FAVOR"
};

// Create a request to settle the dispute
var request = new DisputeSettleRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Dispute settled successfully");
```

## Acknowledge Return Item

Acknowledge that a returned item has been received.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body
var body = new DisputeAcknowledgeReturnRequestBody
{
    Note = "The returned item has been received and verified."
};

// Create a request to acknowledge return
var request = new DisputeAcknowledgeReturnRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Return acknowledged successfully");
```

## Provide Supporting Information

Submit additional supporting information for a dispute.

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body with supporting information
var body = new DisputeProvideSupportRequestBody
{
    Note = "Test"
};

// Create a request to provide supporting info
var request = new DisputeProvideSupportRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Supporting information submitted successfully");
```

## Update Dispute Status

Update the dispute status by requiring evidence (sandbox only).

```csharp
using Tavstal.PayPalSDK.Models.Disputes;
using Tavstal.PayPalSDK.Models.Disputes.Bodies;

// Create the request body
var body = new DisputeUpdateStatusRequestBody
{
    Action = "BUYER_EVIDENCE"
};

// Create a request to update dispute status
var request = new DisputeUpdateStatusRequest("PP-D-27803", body);

// Send the request to the PayPal API
var response = await client.SendAsync(request);

// Parse the response
var result = await request.GetResponseBodyAsync(response);

Console.WriteLine("Dispute status updated successfully");
```

