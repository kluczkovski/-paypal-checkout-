using System;
using System.Text.Json.Serialization;

namespace DevEK.Application.PaymentGateway.PayPal.Models
{
	public class PayPalSellerReceivableBreakdown
	{
        [JsonPropertyName("gross_amount")]
        public PayPalAmount gross_amount { get; set; }

        [JsonPropertyName("paypal_fee")]
        public PaypalFee paypal_fee { get; set; }

        [JsonPropertyName("net_amount")]
        public PayPalAmount net_amount { get; set; }
    }
}

