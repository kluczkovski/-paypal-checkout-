using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalPayer
	{
        [JsonPropertyName("name")]
        public PayPalName Name { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("payer_id")]
        public string PayerId { get; set; }
    }
}

