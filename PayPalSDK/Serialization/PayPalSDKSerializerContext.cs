using System.Text.Json.Serialization;
using Tavstal.PayPalSDK.Models.Auth;
using Tavstal.PayPalSDK.Models.Common;
using Tavstal.PayPalSDK.Models.Common.Plans;
using Tavstal.PayPalSDK.Models.Invoices;
using Tavstal.PayPalSDK.Models.Orders;
using Tavstal.PayPalSDK.Models.Payments;
using Tavstal.PayPalSDK.Models.ProductCatalog;
using Tavstal.PayPalSDK.Models.Subscriptions;
using Tavstal.PayPalSDK.Models.Webhooks;

namespace Tavstal.PayPalSDK.Serialization
{
    [JsonSourceGenerationOptions(
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    )]

    [JsonSerializable(typeof(AccessToken))]
    [JsonSerializable(typeof(RefreshToken))]

    [JsonSerializable(typeof(InvoiceUpdateRequestBody))]
    [JsonSerializable(typeof(InvoiceSendRequestBody))]
    [JsonSerializable(typeof(InvoiceCreateDraftRequestBody))]
    [JsonSerializable(typeof(InvoiceSendReminderRequestBody))]

    [JsonSerializable(typeof(OrderCaptureRequestBody))]
    [JsonSerializable(typeof(OrderCreateRequestBody))]
    [JsonSerializable(typeof(OrderConfirmRequestBody))]
    [JsonSerializable(typeof(OrderAuthorizeRequestBody))]

    [JsonSerializable(typeof(ReviseRequestBody))]

    [JsonSerializable(typeof(PaymentCaptureRequestBody))]
    [JsonSerializable(typeof(PaymentRefundRequestBody))]
    [JsonSerializable(typeof(PaymentReauthorizeRequestBody))]

    [JsonSerializable(typeof(ProductBody))]

    [JsonSerializable(typeof(PlanCreateRequestBody))]

    [JsonSerializable(typeof(ProvidedReason))]

    [JsonSerializable(typeof(PlanPricingScheme))]
    [JsonSerializable(typeof(List<PlanPricingScheme>))]

    [JsonSerializable(typeof(SubscriptionCreateRequestBody))]
    [JsonSerializable(typeof(SubscriptionCaptureRequestBody))]

    [JsonSerializable(typeof(UpdateOperation))]
    [JsonSerializable(typeof(UpdateOperation[]))]
    [JsonSerializable(typeof(List<UpdateOperation>))]

    [JsonSerializable(typeof(WebhookCreateRequestBody))]

    [JsonSerializable(typeof(WebhokVerifyRequestBody))]

    public partial class PayPalSDKSerializerContext : JsonSerializerContext
    {
    }
}
