using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Orders;
using Tavstal.PayPalSDK.Models.Common.Payments.EligibleMethod;

namespace Tavstal.PayPalSDK.Models.Payments.Bodies;

/// <summary>
/// Represents the request body used to find eligible payment methods for a customer.
/// </summary>
[DataContract]
public class PaymentFindEligibleMethodsRequestBody
{
    /// <summary>
    /// Gets or sets the customer information used to evaluate eligible payment methods.
    /// </summary>
    [JsonPropertyName("customer")]
    public EligibleCustomer? Customer { get; set; }
    
    /// <summary>
    /// Gets or sets the purchase units associated with the eligibility request.
    /// </summary>
    [JsonPropertyName("purchase_units")]
    public List<PurchaseUnit>? PurchaseUnits { get; set; }
    
    /// <summary>
    /// Gets or sets optional eligibility preferences used to influence the result.
    /// </summary>
    [JsonPropertyName("preferences")]
    public EligiblePreference? Preferences { get; set; }
}