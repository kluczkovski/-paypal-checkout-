using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class Paypal
	{
        [JsonPropertyName("name")]
        public PayPalName Name { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
	}
}

