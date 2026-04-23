using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the details of a payment status, including the reason for the status.
/// </summary>
[DataContract]
public class StatusDetails
{
    /// <summary>
    /// The reason for the payment status.
    /// This is a string with a maximum length of 64 characters and must match the regular expression "^[A-Z_]+$".
    /// </summary>
    [JsonPropertyName("reason")]
    [StringLength(64)]
    [RegularExpression("^[A-Z_]+$")]
    public string Reason { get; set; }
}