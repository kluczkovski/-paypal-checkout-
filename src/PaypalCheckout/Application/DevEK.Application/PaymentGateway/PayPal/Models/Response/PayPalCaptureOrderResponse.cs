using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models.Response
{
	public class PayPalCaptureOrderResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("payment_source")]
        public PayPalPaymentSource PayPalPaymentSource { get; set; }

        [JsonPropertyName("purchase_units")]
        public List<PayPalPurchaseUnit> PurchaseUnits { get; set; }

        [JsonPropertyName("payer")]
        public PayPalPayer Payer { get; set; }

        [JsonPropertyName("links")]
        public List<PayPalLink> links { get; set; }
	}
}

