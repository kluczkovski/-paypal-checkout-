using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalCapture
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("amount")]
        public PayPalAmount amount { get; set; }

        [JsonPropertyName("seller_protection")]
        public PayPalSellerProtection SellerProtection { get; set; }

        [JsonPropertyName("final_capture")]
        public bool FinalCapture { get; set; }

        [JsonPropertyName("disbursement_mode")]
        public string DisbursementMode { get; set; }

        [JsonPropertyName("seller_receivable_breakdown")]
        public PayPalSellerReceivableBreakdown SellerReceivableBreakdown { get; set; }

        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("pdate_time")]
        public DateTime UpdateTime { get; set; }

        [JsonPropertyName("links")]
        public List<PayPalLink> links { get; set; }
    }
}

