using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Common.Payments.Sources;

namespace Tavstal.PayPalSDK.Models.Common.Payments;


/// <summary>
/// Represents a payment source in the PayPal SDK.
/// </summary>
[DataContract]
public class PaymentSource
{
    /// <summary>
    /// Gets or sets the card payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using a card.
    /// </remarks>
    [JsonPropertyName("card")]
    public CardSource? CardSource { get; set; }

    /// <summary>
    /// Gets or sets the token payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using a token.
    /// </remarks>
    [JsonPropertyName("token")]
    public TokenSource? Token { get; set; }

    /// <summary>
    /// Gets or sets the PayPal payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using PayPal.
    /// </remarks>
    [JsonPropertyName("paypal")]
    public PayPalSource? PayPal { get; set; }

    /// <summary>
    /// Gets or sets the Bancontact payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Bancontact.
    /// </remarks>
    [JsonPropertyName("bancontact")]
    public BanContactSource? BanContact { get; set; }

    /// <summary>
    /// Gets or sets the Blik payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Blik.
    /// </remarks>
    [JsonPropertyName("blik")]
    public BlikSource? Blik { get; set; }

    /// <summary>
    /// Gets or sets the EPS payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using EPS.
    /// </remarks>
    [JsonPropertyName("eps")]
    public EpsSource? Eps { get; set; }

    /// <summary>
    /// Gets or sets the GiroPay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using GiroPay.
    /// </remarks>
    [JsonPropertyName("giropay")]
    public GiroPaySource? GiroPay { get; set; }

    /// <summary>
    /// Gets or sets the iDEAL payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using iDEAL.
    /// </remarks>
    [JsonPropertyName("ideal")]
    public IdealSource? Ideal { get; set; }

    /// <summary>
    /// Gets or sets the MyBank payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using MyBank.
    /// </remarks>
    [JsonPropertyName("mybank")]
    public MyBankSource? MyBank { get; set; }

    /// <summary>
    /// Gets or sets the P24 payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using P24.
    /// </remarks>
    [JsonPropertyName("p24")]
    public PTwentyFourSource? PTwentyFour { get; set; }

    /// <summary>
    /// Gets or sets the Sofort payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Sofort.
    /// </remarks>
    [JsonPropertyName("sofort")]
    public SofortSource? Sofort { get; set; }

    /// <summary>
    /// Gets or sets the Trustuly payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Trustuly.
    /// </remarks>
    [JsonPropertyName("trustuly")]
    public TrustulySource? Trustuly { get; set; }

    /// <summary>
    /// Gets or sets the Apple Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Apple Pay.
    /// </remarks>
    [JsonPropertyName("apple_pay")]
    public ApplePaySource? ApplePay { get; set; }
    
    /// <summary>
    /// Gets or sets the Google Pay payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Google Pay.
    /// </remarks>
    [JsonPropertyName("google_pay")]
    public GooglePaySource? GooglePay { get; set; }

    /// <summary>
    /// Gets or sets the Venmo payment source.
    /// </summary>
    /// <remarks>
    /// This field is optional and represents payment details using Venmo.
    /// </remarks>
    [JsonPropertyName("venmo")]
    public VenmoSource? Venmo { get; set; }
}