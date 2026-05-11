using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Addressing;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources.Card;

namespace Tavstal.PayPalSDK.Models.Common.Payments.Sources;

/// <summary>
/// Represents a card payment source in the PayPal SDK.
/// </summary>
[DataContract]
public class CardSource
{
    /// <summary>
    /// Gets or sets the card holder's name as it appears on the card.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 300 characters.
    /// </remarks>
    [JsonPropertyName("name")]
    [StringLength(300)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the card number.
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 19 characters.
    /// </remarks>
    [JsonPropertyName("number")]
    [StringLength(19)]
    public string? Number { get; set; }

    /// <summary>
    /// Gets or sets the card security code (CVV).
    /// </summary>
    /// <remarks>
    /// This field is optional and has a maximum length of 4 characters.
    /// </remarks>
    [JsonPropertyName("security_code")]
    [StringLength(4)]
    public string? SecurityCode { get; set; }

    /// <summary>
    /// Gets or sets the card expiry date in the format YYYY-MM.
    /// </summary>
    /// <remarks>
    /// This field is optional and must match the regular expression ^[0-9]{4}-(0[1-9]|1[0-2])$.
    /// </remarks>
    [JsonPropertyName("expiry")]
    [StringLength(7)]
    [RegularExpression("^[0-9]{4}-(0[1-9]|1[0-2])$")]
    public string? Expiry { get; set; }

    /// <summary>
    /// Gets or sets the billing address associated with the card.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents the address details for billing.
    /// </remarks>
    [JsonPropertyName("billing_address")]
    public Address? BillingAddress { get; set; }

    /// <summary>
    /// Gets or sets additional attributes for the card source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents metadata or extra information.
    /// </remarks>
    [JsonPropertyName("attributes")]
    public CardAttributes? Attributes { get; set; }

    /// <summary>
    /// Gets or sets stored credentials for the card source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents saved payment details.
    /// </remarks>
    [JsonPropertyName("stored_credential")]
    public CardStoredCredentials? StoredCredential { get; set; }

    /// <summary>
    /// Gets or sets the vault ID for the card source.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 255 characters, and must match the regular expression ^[0-9a-zA-Z_-]+$.
    /// </remarks>
    [JsonPropertyName("vault_id")]
    [StringLength(255)]
    [RegularExpression("^[0-9a-zA-Z_-]+$")]
    public string? VaultId { get; set; }

    /// <summary>
    /// Gets or sets the single-use token for the card source.
    /// </summary>
    /// <remarks>
    /// This field is optional, has a maximum length of 255 characters, and must match the regular expression ^[0-9a-zA-Z_-]+$.
    /// </remarks>
    [JsonPropertyName("single_use_token")]
    [StringLength(255)]
    [RegularExpression("^[0-9a-zA-Z_-]+$")]
    public string? SingleUseToken { get; set; }

    /// <summary>
    /// Gets or sets the network token for the card source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents tokenized payment details.
    /// </remarks>
    [JsonPropertyName("network_token")]
    public NetworkToken? NetworkToken { get; set; }
}