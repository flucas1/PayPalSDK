using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;
using Tavstal.PayPalSDK.Models.Common.User;

namespace Tavstal.PayPalSDK.Models.Common.Orders;

/// <summary>
/// Represents the details of a payment authorization, including its status, amount, and related metadata.
/// </summary>
[DataContract]
public class PaymentAuthorization
{
    /// <summary>
    /// Gets or sets the status of the payment authorization.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the details of the status for the payment authorization.
    /// </summary>
    [JsonPropertyName("status_details")]
    public StatusDetails StatusDetails { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the payment authorization.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the invoice ID associated with the payment authorization.
    /// </summary>
    /// <remarks>
    /// This field is optional and can be used for tracking purposes.
    /// </remarks>
    [JsonPropertyName("invoice_id")]
    public string InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the custom ID associated with the payment authorization.
    /// </summary>
    /// <remarks>
    /// This field is optional and can be used for custom tracking purposes.
    /// </remarks>
    [JsonPropertyName("custom_id")]
    public string CustomId { get; set; }

    /// <summary>
    /// Gets or sets the list of related links for the payment authorization.
    /// </summary>
    /// <remarks>
    /// These links provide HATEOAS (Hypermedia as the Engine of Application State) navigation.
    /// </remarks>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount authorized in the payment.
    /// </summary>
    [JsonPropertyName("amount")]
    public Money Amount { get; set; }

    /// <summary>
    /// Gets or sets the network transaction reference for the payment authorization.
    /// </summary>
    /// <remarks>
    /// This field contains details about the network transaction.
    /// </remarks>
    [JsonPropertyName("network_transaction_reference")]
    public NetworkTransactionReference NetworkTransactionReference { get; set; }

    /// <summary>
    /// Gets or sets the seller protection information for the payment authorization.
    /// </summary>
    /// <remarks>
    /// This field provides details about the seller protection status.
    /// </remarks>
    [JsonPropertyName("seller_protection")]
    public SellerProtection SellerProtection { get; set; }

    /// <summary>
    /// Gets or sets the expiration time of the payment authorization.
    /// </summary>
    /// <remarks>
    /// The time is represented as an ISO 8601 string.
    /// </remarks>
    [JsonPropertyName("expiration_time")]
    public string ExpirationTime { get; set; }

    /// <summary>
    /// Gets or sets the creation time of the payment authorization.
    /// </summary>
    /// <remarks>
    /// The time is represented as an ISO 8601 string.
    /// </remarks>
    [JsonPropertyName("create_time")]
    public string CreateTime { get; set; }

    /// <summary>
    /// Gets or sets the last update time of the payment authorization.
    /// </summary>
    /// <remarks>
    /// The time is represented as an ISO 8601 string.
    /// </remarks>
    [JsonPropertyName("update_time")]
    public string UpdateTime { get; set; }

    /// <summary>
    /// Gets or sets the processor response for the payment authorization.
    /// </summary>
    /// <remarks>
    /// This field contains details about the response from the payment processor.
    /// </remarks>
    [JsonPropertyName("processor_response")]
    public ProcessorResponse ProcessorResponse { get; set; }
}