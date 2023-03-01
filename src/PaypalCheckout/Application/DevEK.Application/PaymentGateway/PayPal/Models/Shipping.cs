using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalShipping
	{
		[JsonPropertyName("address")]
		public PayPalAddress address { get; set; }
	}
}

