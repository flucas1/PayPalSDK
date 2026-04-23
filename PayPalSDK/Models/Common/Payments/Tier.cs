using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Tavstal.PayPalSDK.Models.Common.Payments;

/// <summary>
/// Represents a monetary value with a currency code.
/// </summary>
[DataContract]
public class Tier
{
    /// <summary>
    ///The starting quantity for the tier.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 32 characters.
    /// </remarks>
    [JsonPropertyName("starting_quantity")]
    [StringLength(32)]
    public required string StartingQuantity { get; set; }

    /// <summary>
    ///The ending quantity for the tier. Optional for the last tier.
    /// </summary>
    /// <remarks>
    /// This field is required/optional and has a maximum length of 32 characters.
    /// </remarks>
    [JsonPropertyName("ending_quantity")]
    [StringLength(32)]
    public string EndingQuantity { get; set; }

    /// <summary>
    /// The pricing amount for the tier.
    /// </summary>
    /// <remarks>
    /// This field is required and represents the monetary value of the price.
    /// </remarks>
    [JsonPropertyName("amount")]
    public required Money Amount { get; set; }
}
