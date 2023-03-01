
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalPurchaseUnit
	{
		[JsonPropertyName("amount")]
		public PayPalAmount amount { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("shipping")]
        public PayPalShipping Shipping { get; set; }

        [JsonPropertyName("payments")]
        public PayPalPayments payments { get; set; }
	}
}

