using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Orders.Supplementary;

namespace Tavstal.PayPalSDK.Models.Common.Orders;

/// <summary>
/// Represents risk-related information for a PayPal order.
/// </summary>
[DataContract]
public class Risk
{
    /// <summary>
    /// Gets or sets the supplementary customer information associated with the risk assessment.
    /// </summary>
    /// <remarks>
    /// This property contains details about the customer, such as their IP address, 
    /// which may be used for evaluating potential risks.
    /// </remarks>
    [JsonPropertyName("customer")]
    public SupplementaryCustomer Customer { get; set; }
}