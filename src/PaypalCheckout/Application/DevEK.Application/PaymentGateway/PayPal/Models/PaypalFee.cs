using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PaypalFee
	{
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}

