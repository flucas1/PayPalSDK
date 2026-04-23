using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents the payment terms for an invoice, including the type of term and the due date.
/// </summary>
[DataContract]
public class PaymentTerm
{
    /// <summary>
    /// Gets or sets the type of payment term.
    /// <para>
    /// See <see cref="Tavstal.PayPalSDK.Constants.DueType"/> for possible values.
    /// </para>
    /// </summary>
    [JsonPropertyName("term_type")]
    public string TermType { get; set; }

    /// <summary>
    /// Gets or sets the due date for the payment.
    /// </summary>
    /// <remarks>
    /// The due date must be in the format YYYY-MM-DD.
    /// </remarks>
    [JsonPropertyName("due_date")]
    [StringLength(10)]
    [RegularExpression(@"^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string DueDate { get; set; }
}