using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalPayments
	{
        [JsonPropertyName("captures")]
        public List<PayPalCapture> Captures { get; set; }
    }
}

