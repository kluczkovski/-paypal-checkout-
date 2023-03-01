using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalSellerProtection
	{
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("dispute_categories")]
        public List<string> DisputeCategories { get; set; }
    }
}

