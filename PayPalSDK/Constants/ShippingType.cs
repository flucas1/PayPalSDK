namespace Tavstal.PayPalSDK.Constants;

/// <summary>
/// Represents the different types of shipping methods available in the PayPal SDK.
/// </summary>
public class ShippingType
{
    /// <summary>
    /// The payer intends to receive the items at a specified address.
    /// </summary>
    public const string SHIPPING = "SHIPPING";

    /// <summary>
    /// The payer intends to pick up the item(s) from the payee's physical store. Also termed as BOPIS, "Buy Online, Pick-up in Store".
    /// <br/><br/>
    /// Seller protection is provided with this option.
    /// </summary>
    public const string PICKUP_IN_STORE = "PICKUP_IN_STORE";

    /// <summary>
    /// The payer intends to pick up the item(s) from the payee in person. Also termed as BOPIP, "Buy Online, Pick-up in Person".
    /// <br/><br/>
    /// Seller protection is not available, since the payer is receiving the item from the payee in person, and can validate the item prior to payment.
    /// </summary>
    public const string PICKUP_FROM_PERSON = "PICKUP_FROM_PERSON";
}