using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalPaymentSource
	{
        [JsonPropertyName("payPal")]
        public Paypal PayPal { get; set; }
	}
}

