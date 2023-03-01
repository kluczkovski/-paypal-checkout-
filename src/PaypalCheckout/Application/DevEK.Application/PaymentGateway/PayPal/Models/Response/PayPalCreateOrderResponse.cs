using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models.Response
{
	public class PayPalCreateOrderResponse
	{
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("links")]
        public List<PayPalLink> links { get; set; }
	}
}

